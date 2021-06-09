using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerlineTrackerNew.Services.Reports
{
    public class ContractSMRReportService : IExcelReport
    {
        public void BuildExcelWorksheet(ExcelWorksheet worksheet)
        {
            //List<ContractSMR> ContractsSMR = new List<ContractSMR> {
            //    new ContractSMR {Number=1111, DateOfCompleteFirstStage=new DateTime(2021,1,1), DateOfSigned=new DateTime(2021,1,1), DateOfCompleteSecondtStage=new DateTime(2021,1,1), ContractSum= 2000000, ID=1},
            //    new ContractSMR {Number=2222, DateOfCompleteFirstStage=new DateTime(2021,1,1), DateOfSigned=new DateTime(2021,1,1), DateOfCompleteSecondtStage=new DateTime(2021,1,1), ContractSum= 2000000, ID=2} };

            //for (int i = 0; i < ContractsSMR.Count; i++)
            //{
            //    worksheet.Cells[i + 2, 1].Value = $"ID: {ContractsSMR[i].ID} ";
            //    worksheet.Cells[i + 2, 2].Value = $"Номер договора: {ContractsSMR[i].Number}";
            //    worksheet.Cells[i + 2, 3].Value = $"Дата начала договора: {ContractsSMR[i].DateOfSigned}";
            //    worksheet.Cells[i + 2, 3].Value = $"Дата окончания 1 этапа: {ContractsSMR[i].DateOfCompleteFirstStage}";
            //    worksheet.Cells[i + 2, 3].Value = $"Дата окончания 1 этапа: {ContractsSMR[i].DateOfCompleteSecondtStage}";
            //    worksheet.Cells[i + 2, 3].Value = $"Сумма договора: {ContractsSMR[i].ContractSum}";
            //}
        }
    }
}
