using OfficeOpenXml;
using PowerlineTrackerNew.Services.DTO;
using PowerlineTrackerNew.Services.ENUMS;
using System;
using System.Collections.Generic;
using TrackerDB.Models;
using TrackerDB.Models.ENUMS;

namespace PowerlineTrackerNew.Services
{
    public interface IPowerlineService
    {
        List<Powerline> ContractPirNotNullQuery();
        List<Powerline> ContractSmrNotNullQuery();
        List<PowerlineDTO> GetAllPowerlines();
        ContractsDTO GetContractsDTO(Status status, ContractType contractType, DateTime startDate, DateTime endDate);
        void BuildContractSmrNotNullExcelReport(ExcelWorksheet worksheet);
        void BuildContractPirNotNullExcelReport(ExcelWorksheet worksheet);
        void AddPowerline(PowerlineDTO powerlineDTO);
        void UpdatePowerline(int ID, PowerlineDTO newPowerline);
    }
}