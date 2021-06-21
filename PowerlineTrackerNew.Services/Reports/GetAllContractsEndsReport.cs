using OfficeOpenXml;
using PowerlineTrackerNew.Services.DTO;
using PowerlineTrackerNew.Services.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using TrackerDB;

namespace PowerlineTrackerNew.Services.Reports
{
    public class GetAllContractsEndsReport : IExcelReport
    {
        private readonly ContextDB ContextDB;                          // эта строка добавляется при подключении базы данных     
        public GetAllContractsEndsReport(ContextDB contextDB)
        {
            this.ContextDB = contextDB;
        }

        public string ReportFileName { get; set; } = "Report.xlsx";

        public void BuildExcelWorksheet(ExcelWorksheet worksheet)
        {
            GetContractsNeededCloseQuery query = new GetContractsNeededCloseQuery();

            List<ContractsEnd> contracts = query.Execute(ContextDB, new DateTime(2021,08,01));

            this.ReportFileName = $"Report {DateTime.Today.ToShortDateString()}.xlsx"; // тут можно изменить название файла

            worksheet.Cells[1, 2].Value = $"Номер договора ";
            worksheet.Cells[1, 3].Value = $"Тип Договора";
            worksheet.Cells[1, 4].Value = $"Дата закрытия";

            // здесь можно обрабатывать данные(условное форматирование, округление и тд)
            for (int i = 0; i < contracts.Count; i++)
            {
                worksheet.Cells[i + 2, 2].Value = contracts[i].Number;
                worksheet.Cells[i + 2, 3].Value = contracts[i].Type;
                worksheet.Cells[i + 2, 4].Value = contracts[i].DateOfComplete.ToShortDateString();
            }
        }
    }
}

