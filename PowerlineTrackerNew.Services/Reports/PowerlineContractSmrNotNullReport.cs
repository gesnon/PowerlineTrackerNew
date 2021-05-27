namespace PowerlineTrackerNew.Services.Reports
{
    using OfficeOpenXml;
    using Models;
    using Queries.Powerline;
    using System.Collections.Generic;
    using System;

    public class PowerlineContractSmrNotNullReport : IExcelReport
    {
        public string ReportFileName { get; set; } = "Report.xlsx";

        public void BuildExcelWorksheet(ExcelWorksheet worksheet)
        {
            ContractSmrNotNullQuery query = new ContractSmrNotNullQuery();
            List<Powerline> powerlines = query.Execute();

            this.ReportFileName = $"Report {DateTime.Today.ToShortDateString()}"; // тут можно изменить название файла

            // здесь можно обрабатывать данные(условное форматирование, округление и тд)
            for (int i = 0; i < powerlines.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = $"ID: {powerlines[i].ID} ";
                worksheet.Cells[i + 2, 2].Value = $"Наименование объекта: {powerlines[i].Name}";
                worksheet.Cells[i + 2, 3].Value = $"Номер договора ПИР: {powerlines[i].ContractPIR}";
                worksheet.Cells[i + 2, 3].Value = $"Номер договора СМР: {powerlines[i].ConractSMR}";
                worksheet.Cells[i + 2, 3].Value = $"Служебные записки: {powerlines[i].InternalNotes[0].Theme}";
            }
        }
    }
}
