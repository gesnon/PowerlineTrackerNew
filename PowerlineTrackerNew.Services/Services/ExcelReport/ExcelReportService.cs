using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PowerlineTrackerNew.Services
{
    public class ExcelReportService : IExcelReportService
    {
        private readonly IContractService contractService;
        private readonly IContractPIRService contractPIRService;
        private readonly IContractSMRService contractSMRService;
        private readonly IPowerlineService powerlineService;        

        public ExcelReportService(IContractService contractService, IContractPIRService contractPIRService, IContractSMRService contractSMRService, IPowerlineService powerlineService)
        {
            this.contractService = contractService;
            this.contractPIRService = contractPIRService;
            this.contractSMRService = contractSMRService;
            this.powerlineService = powerlineService;
        }

        public MemoryStream GetAllContractsEndsExcelReport(DateTime date)
        {
            byte[] reportBytes = BuildFile((ExcelWorksheet worksheet) => contractService.BuildAllContractsEndsExcelReport(worksheet, date));

            return GetFileStream(reportBytes);
        }

        public MemoryStream GetAllContractsPIRExcelReport()
        {
            byte[] reportBytes = BuildFile((ExcelWorksheet worksheet) => contractPIRService.BuildAllContractsPIRExcelReport(worksheet));

            return GetFileStream(reportBytes);
        }

        public MemoryStream GetAllContractsSMRExcelReport()
        {
            byte[] reportBytes = BuildFile((ExcelWorksheet worksheet) => contractSMRService.BuildAllContractsSMRExcelReport(worksheet));

            return GetFileStream(reportBytes);
        }

        public MemoryStream PowerlineContractPirNotNullExcelReport()
        {
            byte[] reportBytes = BuildFile((ExcelWorksheet worksheet) => powerlineService.BuildContractPirNotNullExcelReport(worksheet));

            return GetFileStream(reportBytes);
        }

        public MemoryStream PowerlineContractSMRNotNullExcelReport()
        {
            byte[] reportBytes = BuildFile((ExcelWorksheet worksheet) => powerlineService.BuildContractSmrNotNullExcelReport(worksheet));

            return GetFileStream(reportBytes);
        }

        private MemoryStream GetFileStream(byte[] file)
        {
            return new MemoryStream(file);
        }

        private byte[] BuildFile(Action<ExcelWorksheet> query)
        {
            string tempDir = Path.GetTempPath();
            var tempFile = Path.Combine(tempDir, Guid.NewGuid() + ".xlsx");

            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report"); // Добавляет в эксель новый лист c названием "Report"
                query.Invoke(worksheet);
                var xlFile = GetFileInfo(tempFile);
                package.SaveAs(xlFile);
            }

            byte[] file = new byte[0];

            if (File.Exists(tempFile))
            {
                file = File.ReadAllBytes(tempFile);
                File.Delete(tempFile);
            }

            return file;
        }

        private FileInfo GetFileInfo(string file, bool deleteIfExists = true)
        {
            var fi = new FileInfo(file);
            if (deleteIfExists && fi.Exists)
            {
                fi.Delete();
            }

            return fi;
        }
    }
}
