using OfficeOpenXml;
using PowerlineTrackerNew.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerDB;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Services
{
    public class ContractPIRService : IContractPIRService
    {
        private readonly ContextDB context;

        public ContractPIR GetContractByID(int ID)
        {
            return context.ContractPIRs.FirstOrDefault(_ => _.ID == ID);
        }

        public ContractPIRDTO GetContractPIRDTOByID(int ID)
        {
            ContractPIR contractPIR = context.ContractPIRs.FirstOrDefault(_ => _.ID == ID);
            ContractPIRDTO contractPIRDTO = new ContractPIRDTO
            {
                Number = contractPIR.Number,
                DateOfSigned = contractPIR.DateOfSigned.ToString("dd.MM.yy"),
                DateOfComplete = contractPIR.DateOfComplete.ToString("dd.MM.yy"),
                ContractSum = contractPIR.ContractSum,
                Status = contractPIR.Status
            };
            return contractPIRDTO;
        }

        public ContractPIRService(ContextDB context)
        {
            this.context = context;
        }

        public List<ContractPIR> GetAllContractsPIR()
        {
            return context.ContractPIRs.ToList();
        }

        public void BuildAllContractsPIRExcelReport(ExcelWorksheet worksheet)
        {
            List<ContractPIR> contracts = this.GetAllContractsPIR();

            worksheet.Cells[1, 2].Value = $"Номер договора ПИР";
            worksheet.Cells[1, 3].Value = $"Сумма";

            // здесь можно обрабатывать данные(условное форматирование, округление и тд)
            for (int i = 0; i < contracts.Count; i++)
            {
                worksheet.Cells[i + 2, 2].Value = contracts[i].Number;
                worksheet.Cells[i + 2, 3].Value = contracts[i].ContractSum;

            }
        }

        public List<ContractPIRDTO> GetAllContractsPIRDTO()
        {
            return this.context.ContractPIRs.Select(c => new ContractPIRDTO
            {
                Number = c.Number,
                DateOfSigned = c.DateOfSigned.ToString("dd.MM.yy"),
                DateOfComplete = c.DateOfComplete.ToString("dd.MM.yy"),
                ContractSum = c.ContractSum,
                Status = TrackerDB.Models.ENUMS.Status.Closed
            }).ToList();
        }

        public void UpdateContractPIR(int ID, ContractPIRDTO newContractPIR)
        {
            ContractPIR oldContractPIR = this.context.ContractPIRs.First(c => c.ID == ID);

            if (newContractPIR.Number != 0)
            {
                oldContractPIR.Number = newContractPIR.Number;
            }
            if (newContractPIR.DateOfComplete != null)
            {
                oldContractPIR.DateOfComplete = DateTime.Parse(newContractPIR.DateOfComplete);
            }
            if (newContractPIR.ContractSum != 0)
            {
                oldContractPIR.ContractSum = newContractPIR.ContractSum;
            }
            if (newContractPIR.Status != oldContractPIR.Status)    // не понимаю как правильно отследить изменение поля bool если оно не заполняется в форме
            {
                oldContractPIR.Status = newContractPIR.Status;
            }

            this.context.SaveChanges();
        }

        public void AddContractPIR(ContractPIRDTO newContractPIR)
        {
            this.context.ContractPIRs.Add(new ContractPIR
            {
                Number = newContractPIR.Number,
                DateOfSigned = DateTime.Parse(newContractPIR.DateOfSigned),
                DateOfComplete = DateTime.Parse(newContractPIR.DateOfComplete),
                ContractSum = newContractPIR.ContractSum,
                Status = TrackerDB.Models.ENUMS.Status.Open
            });

            this.context.SaveChanges();
        }
    }
}
