namespace PowerlineTrackerNew.Services.Reports
{
    using OfficeOpenXml; 
    using Queries.Powerline;
    using System.Collections.Generic;
    using System;
    using TrackerDB.Models;

    public class PowerlineContractSmrNotNullReport : IExcelReport
    {
        public string ReportFileName { get; set; } = "Report.xlsx";

        public void BuildExcelWorksheet(ExcelWorksheet worksheet)
        {
            ContractSmrNotNullQuery query = new ContractSmrNotNullQuery();

            List<Powerline> powerlines = query.Execute();

            this.ReportFileName = $"Report {DateTime.Today.ToShortDateString()}.xlsx"; // тут можно изменить название файла

            // здесь можно обрабатывать данные(условное форматирование, округление и тд)

            worksheet.Cells[1, 2].Value = $"Наименование объекта";
            worksheet.Cells[1, 3].Value = $"Номер договора ПИР";
            worksheet.Cells[1, 4].Value = $"Номер договора СМР";

            for (int i = 0; i < powerlines.Count; i++) {
                //  worksheet.Cells[i + 2, 1].Value = $"ID: {powerlines[i].ID} ";
                worksheet.Cells[i + 2, 2].Value =  powerlines[i].Name;
                worksheet.Cells[i + 2, 3].Value =  powerlines[i].ContractPIR.Number;
                worksheet.Cells[i + 2, 4].Value =  powerlines[i].ConractSMR.Number;
              //  worksheet.Cells[i + 2, 3].Value = $"Служебные записки: {powerlines[i].InternalNotes[0].Theme}";
            }
        }
    }
}
