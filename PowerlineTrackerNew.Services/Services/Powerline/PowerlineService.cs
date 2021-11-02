using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using PowerlineTrackerNew.Services.DTO;
using PowerlineTrackerNew.Services.ENUMS;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackerDB;
using TrackerDB.Models;
using TrackerDB.Models.ENUMS;

namespace PowerlineTrackerNew.Services
{
    public class PowerlineService : IPowerlineService
    {
        private readonly ContextDB context;

        public PowerlineService(ContextDB context)
        {
            this.context = context;
        }

        public List<PowerlineDTO> GetAllPowerlines()
        {
            return context.Powerlines.Include(_ => _.ContractPIR).Include(_ => _.ConractSMR).
                Select(c => new PowerlineDTO
                {
                    Name = c.Name,
                    ContractPIRNumber = c.ContractPIR != null ? c.ContractPIR.Number.ToString() : " ",
                    ContractSMRNumber = c.ConractSMR != null ? c.ConractSMR.Number.ToString() : " ",
                    Comments = c.Comments
                }).ToList();
        }

        public void AddPowerline(PowerlineDTO powerlineDTO)
        {
            this.context.Powerlines.Add(new Powerline { Name = powerlineDTO.Name });
            this.context.SaveChanges();
        }

        public void UpdatePowerline(int ID, PowerlineDTO newPowerline)
        {
            Powerline OldPOwerline = this.context.Powerlines.First(p => p.ID == ID);

            if (newPowerline.Name != null)
            {
                OldPOwerline.Name = newPowerline.Name;
            }
            if (newPowerline.Comments != null)
            {
                OldPOwerline.Comments = newPowerline.Comments;

            }

            this.context.SaveChanges();

        }

        public List<Powerline> ContractPirNotNullQuery()
        {
            return this.context.Powerlines.Include(_ => _.ConractSMR).Include(_ => _.ContractPIR).Where(_ => _.ContractPIR != null).ToList();
        }

        public List<Powerline> ContractSmrNotNullQuery()
        {
            return this.context.Powerlines.Include(_ => _.ConractSMR).Include(_ => _.ContractPIR).Where(_ => _.ConractSMR != null).ToList();
        }

        public ContractsDTO GetContractsDTO(Status status, ContractType contractType, DateTime startDate, DateTime endDate)
        {
            ContractsDTO newContracts = new ContractsDTO();

            List<ContractPIRDTO> contractPIRDTOs = new List<ContractPIRDTO>();

            var queryPIR = this.context.ContractPIRs.AsQueryable();

            var querySMR = this.context.ContractSMRs.AsQueryable();

            if (contractType == ContractType.PIR)
            {
                if (status == Status.Closed)
                {
                    queryPIR = queryPIR.Where(_ => _.Closed == true);
                }
                if (status == Status.Open)
                {
                    queryPIR = queryPIR.Where(_ => _.Closed == false);
                }
                if (startDate != null)
                {
                    queryPIR = queryPIR.Where(_ => _.DateOfComplete >= startDate);
                }
                if (endDate != null)
                {
                    queryPIR = queryPIR.Where(_ => _.DateOfComplete <= endDate);
                }
            }

            if (contractType == ContractType.SMR)
            {
                if (status == Status.Closed)
                {
                    querySMR = querySMR.Where(_ => _.Status == Status.ClosedSecondStage);
                }
                if (status == Status.Open)
                {
                    queryPIR = queryPIR.Where(_ => _.Closed == false);
                }
                if (startDate != null)
                {
                    queryPIR = queryPIR.Where(_ => _.DateOfComplete >= startDate);
                }
                if (endDate != null)
                {
                    queryPIR = queryPIR.Where(_ => _.DateOfComplete <= endDate);
                }
            }

            return null;
        }

        public void BuildContractPirNotNullExcelReport(ExcelWorksheet worksheet)
        {
            List<Powerline> powerlines = this.ContractPirNotNullQuery();

            worksheet.Cells[1, 2].Value = $"Наименование объекта";
            worksheet.Cells[1, 3].Value = $"Номер договора ПИР";
            worksheet.Cells[1, 4].Value = $"Номер договора СМР";

            // здесь можно обрабатывать данные(условное форматирование, округление и тд)
            for (int i = 0; i < powerlines.Count; i++)
            {
                worksheet.Cells[i + 2, 2].Value = powerlines[i].Name;
                worksheet.Cells[i + 2, 3].Value = powerlines[i].ContractPIR.Number;
                worksheet.Cells[i + 2, 4].Value = powerlines[i].ConractSMR?.Number;
            }
        }

        public void BuildContractSmrNotNullExcelReport(ExcelWorksheet worksheet)
        {
            List<Powerline> powerlines = this.ContractSmrNotNullQuery();

            // здесь можно обрабатывать данные(условное форматирование, округление и тд)
            worksheet.Cells[1, 2].Value = $"Наименование объекта";
            worksheet.Cells[1, 3].Value = $"Номер договора ПИР";
            worksheet.Cells[1, 4].Value = $"Номер договора СМР";

            for (int i = 0; i < powerlines.Count; i++)
            {
                //  worksheet.Cells[i + 2, 1].Value = $"ID: {powerlines[i].ID} ";
                worksheet.Cells[i + 2, 2].Value = powerlines[i].Name;
                worksheet.Cells[i + 2, 3].Value = powerlines[i].ContractPIR?.Number;
                worksheet.Cells[i + 2, 4].Value = powerlines[i].ConractSMR.Number;
                //  worksheet.Cells[i + 2, 3].Value = $"Служебные записки: {powerlines[i].InternalNotes[0].Theme}";
            }
        }
    }
}
