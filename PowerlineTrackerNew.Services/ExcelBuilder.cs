﻿using OfficeOpenXml;
using System;
using System.IO;

namespace PowerlineTrackerNew.Services
{
    public class ExcelBuilder
    {
        public byte[] BuildFile(IExcelDownloadable fillWorksheet)
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

            if (System.IO.File.Exists(tempFile))
            {
                file = System.IO.File.ReadAllBytes(tempFile);
                System.IO.File.Delete(tempFile);
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