using OfficeOpenXml;
using PowerlineTrackerNew.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerDB;

namespace PowerlineTrackerNew.Services
{
    public class ContractService : IContractService
    {
        private readonly ContextDB context;

        public ContractService(ContextDB context)
        {
            this.context = context;
        }

        public void BuildAllContractsEndsExcelReport(ExcelWorksheet worksheet, DateTime date)
        {
            List<ContractsEnd> contracts = this.GetContractsNeededCloseQuery(date);

            worksheet.Cells[1, 2].Value = $"Номер договора ";
            worksheet.Cells[1, 3].Value = $"Тип Договора";
            worksheet.Cells[1, 4].Value = $"Дата закрытия";

            // здесь можно обрабатывать данные(условное форматирование, округление и тд)
            for (int i = 0; i < contracts.Count; i++)
            {
                worksheet.Cells[i + 2, 2].Value = contracts[i].Number;
                worksheet.Cells[i + 2, 3].Value = contracts[i].Type;
                worksheet.Cells[i + 2, 4].Value = contracts[i].DateOfComplete.ToShortDateString();
            }
        }

        public List<ContractsEnd> GetContractsNeededCloseQuery(DateTime date)
        {
            List<ContractsEnd> ContractsPIR = this.context.ContractPIRs.Where(_ => _.DateOfComplete < date && _.Closed != true)
                .Select(_ => new ContractsEnd
                {
                    Number = _.Number,
                    DateOfSigned = _.DateOfSigned,
                    Type = "PIR",
                    DateOfComplete = _.DateOfComplete
                }).ToList();

            List<ContractsEnd> ContractsSMRFirstStage = this.context.ContractSMRs.Where(_ => _.DateOfCompleteFirstStage < date && _.Status == TrackerDB.Models.ENUMS.Status.Open)
                .Select(_ => new ContractsEnd
                {
                    Number = _.Number,
                    DateOfSigned = _.DateOfSigned,
                    Type = "FirstStageSMR",
                    DateOfComplete = _.DateOfCompleteFirstStage.Value
                }).ToList();

            List<ContractsEnd> ContractsSMRSecondStage = this.context.ContractSMRs.Where(_ => _.DateOfCompleteSecondtStage.HasValue && _.DateOfCompleteSecondtStage < date && _.Status != TrackerDB.Models.ENUMS.Status.ClosedSecondStage)
                .Select(_ => new ContractsEnd
                {
                    Number = _.Number,
                    DateOfSigned = _.DateOfSigned,
                    Type = "SecondStageSMR",
                    DateOfComplete = _.DateOfCompleteSecondtStage.Value
                }).ToList();

            ContractsPIR.AddRange(ContractsSMRFirstStage);

            ContractsPIR.AddRange(ContractsSMRSecondStage);

            return ContractsPIR;
        }
    }
}
