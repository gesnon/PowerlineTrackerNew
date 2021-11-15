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
        List<Powerline> ContractPirNotNullQuery();                   // можно удалить
        List<Powerline> ContractSmrNotNullQuery();                   // можно удалить
        List<PowerlineDTO> GetAllPowerlines();
        ContractsDTO GetContractsDTO(Status status, ContractType contractType, DateTime startDate, DateTime endDate);
        void BuildContractSmrNotNullExcelReport(ExcelWorksheet worksheet);             // можно изменить(унифицировать)
        void BuildContractPirNotNullExcelReport(ExcelWorksheet worksheet);            // можно изменить (унифицировать)
        void AddPowerline(PowerlineDTO powerlineDTO);
        void UpdatePowerline(int ID, PowerlineDTO newPowerline);

        ContractsDTO GetFiltredContracts(Status status, ContractType contractType, DateTime? startDate = null, DateTime? endDate = null);
    }
}