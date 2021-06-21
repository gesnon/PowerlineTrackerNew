using OfficeOpenXml;
using PowerlineTrackerNew.Services.Queries.ContractSMR;
using System;
using System.Collections.Generic;
using TrackerDB;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Services.Reports
{
    public class GetAllContractsSMRReport : IExcelReport
    {
        private readonly ContextDB ContextDB;                          // эта строка добавляется при подключении базы данных     
        public GetAllContractsSMRReport(ContextDB contextDB)
        {
            this.ContextDB = contextDB;
        }

        public string ReportFileName { get; set; } = "Report.xlsx";

        public void BuildExcelWorksheet(ExcelWorksheet worksheet)
        {
            GetAllContractsSMRQuery query = new GetAllContractsSMRQuery();

            List<ContractSMR> contracts = query.Execute(ContextDB);

            this.ReportFileName = $"Report {DateTime.Today.ToShortDateString()}.xlsx"; // тут можно изменить название файла

            worksheet.Cells[1, 2].Value = $"Номер договора СМР";
            worksheet.Cells[1, 3].Value = $"Сумма";

            // здесь можно обрабатывать данные(условное форматирование, округление и тд)
            for (int i = 0; i < contracts.Count; i++)
            {
                worksheet.Cells[i + 2, 2].Value = contracts[i].Number;
                worksheet.Cells[i + 2, 3].Value = contracts[i].ContractSum;
            }
        }
    }
}
