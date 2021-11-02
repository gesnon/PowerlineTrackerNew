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
                DateDateOfSigned = c.DateOfSigned.ToString("dd.MM.yy"),
                DateOfComplete = c.DateOfComplete.ToString("dd.MM.yy"),
                ContractSum = c.ContractSum,
                Closed = c.Closed
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
            if (newContractPIR.Closed != oldContractPIR.Closed)    // не понимаю как правильно отследить изменение поля bool если оно не заполняется в форме
            {
                oldContractPIR.Closed = newContractPIR.Closed;
            }

            this.context.SaveChanges();
        }

        public void AddContractPIR(ContractPIRDTO newContractPIR)
        {
            this.context.ContractPIRs.Add(new ContractPIR
            {
                Number = newContractPIR.Number,
                DateOfSigned = DateTime.Parse(newContractPIR.DateDateOfSigned),
                DateOfComplete = DateTime.Parse(newContractPIR.DateOfComplete),
                ContractSum = newContractPIR.ContractSum,
                Closed = false
            });

            this.context.SaveChanges();
        }
    }
}
