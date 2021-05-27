using OfficeOpenXml;
using System;
using System.IO;

namespace PowerlineTrackerNew.Services
{
    public class ExcelBuilder
    {
        public byte[] BuildFile(IExcelReport fillWorksheet)            // сначала создается временный файл, в него записывается необходимый отчет, потом этот файл преобразуется в байты в передаётся для создания постоянного файла, а временный файл удаляется
        {
            string tempDir = Path.GetTempPath();
            var tempFile = Path.Combine(tempDir, Guid.NewGuid() + ".xlsx");

            using (var package = new ExcelPackage())
            {              
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report"); // Добавляет в эксель новый лист c названием "Report"
                fillWorksheet.BuildExcelWorksheet(worksheet);
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

        private FileInfo GetFileInfo(string file, bool deleteIfExists = true) //
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
