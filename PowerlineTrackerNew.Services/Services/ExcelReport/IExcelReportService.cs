using System;
using System.IO;

namespace PowerlineTrackerNew.Services
{
    public interface IExcelReportService
    {
        MemoryStream GetAllContractsEndsExcelReport(DateTime date);
        MemoryStream GetAllContractsPIRExcelReport();
        MemoryStream GetAllContractsSMRExcelReport();
        MemoryStream PowerlineContractPirNotNullExcelReport();
        MemoryStream PowerlineContractSMRNotNullExcelReport();
    }
}