using OfficeOpenXml;
using PowerlineTrackerNew.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackerDB;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Services
{
    public class ContractSMRService : IContractSMRService
    {
        private readonly ContextDB context;

        public ContractSMR GetContractByID(int ID)
        {
            return context.ContractSMRs.FirstOrDefault(_ => _.ID == ID);
        }

        public ContractSMRDTO GetContractSMRDTOByID(int ID)
        {
            ContractSMR contractSMR = context.ContractSMRs.FirstOrDefault(_ => _.ID == ID);
            ContractSMRDTO contractSMRDTO = new ContractSMRDTO
            {
                Number = contractSMR.Number,
                DateOfSigned = contractSMR.DateOfSigned.ToString("dd.MM.yy"),
                DateOfCompleteFirstStage = contractSMR.DateOfCompleteFirstStage.HasValue ? contractSMR.DateOfCompleteFirstStage.Value.ToString("dd.MM.yy") : "",
                DateOfCompleteSecondtStage = contractSMR.DateOfCompleteSecondtStage.HasValue ? contractSMR.DateOfCompleteSecondtStage.Value.ToString("dd.MM.yy") : "",
                ContractSum = contractSMR.ContractSum,
                Status = contractSMR.Status
            };

            return contractSMRDTO;

        }
        public ContractSMRService(ContextDB context)
        {
            this.context = context;
        }

        public List<ContractSMR> GetAllContractsSMR()
        {
            return context.ContractSMRs.ToList();
        }

        public List<ContractSMRDTO> GetAllContractsSMRDto()
        {
            return context.ContractSMRs.
                Select(c => new ContractSMRDTO
                {
                    Number = c.Number,
                    DateOfSigned = c.DateOfSigned.ToString("dd.MM.yy"),
                    DateOfCompleteFirstStage = c.DateOfCompleteFirstStage.HasValue ? c.DateOfCompleteFirstStage.Value.ToString("dd.MM.yy") : "",
                    DateOfCompleteSecondtStage = c.DateOfCompleteSecondtStage.HasValue ? c.DateOfCompleteSecondtStage.Value.ToString("dd.MM.yy") : "",
                    ContractSum = c.ContractSum,
                    Status = c.Status
                }).ToList();
        }

        public void UpdateContractSMR(int ID, ContractSMRDTO newContractSMR)
        {
            ContractSMR oldContractSMR = this.context.ContractSMRs.First(c => c.ID == ID);

            if (newContractSMR.Number != 0)
            {
                oldContractSMR.Number = newContractSMR.Number;
            }
            if (newContractSMR.DateOfSigned != null)
            {
                oldContractSMR.DateOfSigned = DateTime.Parse(newContractSMR.DateOfSigned);
            }
            if (newContractSMR.DateOfCompleteFirstStage != null)
            {
                oldContractSMR.DateOfCompleteFirstStage = DateTime.Parse(newContractSMR.DateOfCompleteFirstStage);
            }
            if (newContractSMR.DateOfCompleteSecondtStage != null)
            {
                oldContractSMR.DateOfCompleteSecondtStage = DateTime.Parse(newContractSMR.DateOfCompleteSecondtStage);
            }
            if (newContractSMR.ContractSum != 0)
            {
                oldContractSMR.ContractSum = newContractSMR.ContractSum;
            }
            if (newContractSMR.Status != newContractSMR.Status)    // не понимаю как правильно отследить изменение поля bool если оно не заполняется в форме
            {
                oldContractSMR.Status = newContractSMR.Status;
            }

            this.context.SaveChanges();
        }

        public void AddContractSMR(ContractSMRDTO newContractSMR)
        {
            this.context.ContractSMRs.Add(new ContractSMR
            {
                Number = newContractSMR.Number,
                DateOfSigned = DateTime.Parse(newContractSMR.DateOfSigned),
                DateOfCompleteFirstStage = DateTime.Parse(newContractSMR.DateOfCompleteFirstStage),
                DateOfCompleteSecondtStage = DateTime.Parse(newContractSMR.DateOfCompleteSecondtStage),
                ContractSum = newContractSMR.ContractSum,
                Status = newContractSMR.Status
            });

            this.context.SaveChanges();
        }

        public void BuildAllContractsSMRExcelReport(ExcelWorksheet worksheet)
        {
            List<ContractSMR> contracts = this.GetAllContractsSMR();

            worksheet.Cells[1, 2].Value = $"Номер договора СМР";
            worksheet.Cells[1, 3].Value = $"Сумма";

            // здесь можно обрабатывать данные(условное форматирование, округление и тд)
            for (int i = 0; i < contracts.Count; i++)
            {
                worksheet.Cells[i + 2, 2].Value = contracts[i].Number;
                worksheet.Cells[i + 2, 3].Value = contracts[i].ContractSum;
            }
        }

        public void Put(int ID, ContractSMRDTO newContractSMR)
        {
            ContractSMR oldContractSMR = this.context.ContractSMRs.First(c => c.ID == ID);

            if (newContractSMR.Number != 0)
            {
                oldContractSMR.Number = newContractSMR.Number;
            }
            if (newContractSMR.DateOfSigned != null)
            {
                oldContractSMR.DateOfSigned = DateTime.Parse(newContractSMR.DateOfSigned);
            }
            if (newContractSMR.DateOfCompleteFirstStage != null)
            {
                oldContractSMR.DateOfCompleteFirstStage = DateTime.Parse(newContractSMR.DateOfCompleteFirstStage);
            }
            if (newContractSMR.DateOfCompleteSecondtStage != null)
            {
                oldContractSMR.DateOfCompleteSecondtStage = DateTime.Parse(newContractSMR.DateOfCompleteSecondtStage);
            }
            if (newContractSMR.ContractSum != 0)
            {
                oldContractSMR.ContractSum = newContractSMR.ContractSum;
            }
            if (newContractSMR.Status != newContractSMR.Status)    // не понимаю как правильно отследить изменение поля bool если оно не заполняется в форме
            {
                oldContractSMR.Status = newContractSMR.Status;
            }

            this.context.SaveChanges();
        }
    }
}
