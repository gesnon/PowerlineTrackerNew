using OfficeOpenXml;
using PowerlineTrackerNew.Services.DTO;
using PowerlineTrackerNew.Services.ENUMS;
using System;
using System.Collections.Generic;
using TrackerDB.Models.ENUMS;

namespace PowerlineTrackerNew.Services
{
    public interface IContractService
    {
        List<ContractsEnd> GetContractsNeededCloseQuery(DateTime date);

        void BuildAllContractsEndsExcelReport(ExcelWorksheet worksheet, DateTime date);

        ContractsDTO GetContractsDTO(Status status, ContractType contractType, DateTime? startDate = null, DateTime? endDate = null);
    }
}