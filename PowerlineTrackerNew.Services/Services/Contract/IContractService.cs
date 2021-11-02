using OfficeOpenXml;
using PowerlineTrackerNew.Services.DTO;
using System;
using System.Collections.Generic;

namespace PowerlineTrackerNew.Services
{
    public interface IContractService
    {
        List<ContractsEnd> GetContractsNeededCloseQuery(DateTime date);

        void BuildAllContractsEndsExcelReport(ExcelWorksheet worksheet, DateTime date);
    }
}