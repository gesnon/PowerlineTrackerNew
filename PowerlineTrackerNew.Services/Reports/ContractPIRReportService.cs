using OfficeOpenXml;
using PowerlineTrackerNew.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerlineTrackerNew.Services.Reports
{
    public class ContractPIRReportService : IExcelDownloadable
    {
        public void BuildExcelWorksheet(ExcelWorksheet worksheet)
        {
            List<ContractPIR> ContractsPIR = new List<ContractPIR> {
                new ContractPIR {Number=1111, ContractSum=1000000, DateOfComplete= new DateTime(2021,1,1), DateOfSigned = new DateTime(2021,2,2), ID=1},
                new ContractPIR {Number=2222, ContractSum=2000000, DateOfComplete= new DateTime(2021,1,1), DateOfSigned = new DateTime(2021,2,2), ID=2}};

            for (int i = 0; i < ContractsPIR.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = $"ID: {ContractsPIR[i].ID} ";
                worksheet.Cells[i + 2, 2].Value = $"Номер договора: {ContractsPIR[i].Number}";
                worksheet.Cells[i + 2, 3].Value = $"Дата начала договора: {ContractsPIR[i].DateOfSigned}";
                worksheet.Cells[i + 2, 3].Value = $"Дата окончания договора: {ContractsPIR[i].DateOfComplete}";
                worksheet.Cells[i + 2, 3].Value = $"Сумма договора: {ContractsPIR[i].ContractSum}";
            }
        }
    }
}
