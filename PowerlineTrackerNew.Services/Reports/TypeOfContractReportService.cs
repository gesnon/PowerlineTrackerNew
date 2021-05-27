using OfficeOpenXml;
using PowerlineTrackerNew.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerlineTrackerNew.Services.Reports
{
    public class TypeOfContractReportService : IExcelReport
    {
        public void BuildExcelWorksheet(ExcelWorksheet worksheet)
        {
            List<TypeOfContract> typesOFContract = new List<TypeOfContract> { new TypeOfContract { ID = 1, Name = "NameOne" }, new TypeOfContract { ID = 2, Name = "NameTwo" }, new TypeOfContract { ID = 3, Name = "NameThree" } };

            for (int i = 0; i < typesOFContract.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = $"ID: {typesOFContract[i].ID} ";
                worksheet.Cells[i + 2, 2].Value = $"Наименование: {typesOFContract[i].Name}";
            }
        }
    }
}
