namespace PowerlineTrackerNew.Services.Reports
{
    using OfficeOpenXml;
    using Queries.Powerline;
    using System.Collections.Generic;
    using System;
    using TrackerDB.Models;
    using TrackerDB;

    public class PowerlineContractPirNotNullReport : IExcelReport
    {
        private readonly ContextDB ContextDB;                          // эта строка добавляется при подключении базы данных     
        public PowerlineContractPirNotNullReport(ContextDB contextDB)
        {
            this.ContextDB = contextDB;
        }

        public string ReportFileName { get; set; } = "Report.xlsx";

        public void BuildExcelWorksheet(ExcelWorksheet worksheet)
        {
            ContractPirNotNullQuery query = new ContractPirNotNullQuery();

            List<Powerline> powerlines = query.Execute(ContextDB);

            this.ReportFileName = $"Report {DateTime.Today.ToShortDateString()}"; // тут можно изменить название файла

            worksheet.Cells[1, 2].Value = $"Наименование объекта";
            worksheet.Cells[1, 3].Value = $"Номер договора ПИР";
            worksheet.Cells[1, 4].Value = $"Номер договора СМР";

            // здесь можно обрабатывать данные(условное форматирование, округление и тд)
            for (int i = 0; i < powerlines.Count; i++)
            {
                worksheet.Cells[i + 2, 2].Value =  powerlines[i].Name;
                worksheet.Cells[i + 2, 3].Value = powerlines[i].ContractPIR.Number;
                worksheet.Cells[i + 2, 4].Value = powerlines[i].ConractSMR?.Number;
            }
        }
    }
}
