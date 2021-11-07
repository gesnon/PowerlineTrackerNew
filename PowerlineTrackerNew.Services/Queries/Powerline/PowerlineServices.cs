using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using TrackerDB;
using TrackerDB.Models.ENUMS;

namespace PowerlineTrackerNew.Services.Queries.Powerline
{
    public class PowerlineServices
    {
        public void FillTables(FileStream stream, ContextDB contextDB)
        {
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                List<TrackerDB.Models.Powerline> powerlines = new List<TrackerDB.Models.Powerline>();
                List<TrackerDB.Models.ContractPIR> contractsPIR = new List<TrackerDB.Models.ContractPIR>();
                List<TrackerDB.Models.ContractSMR> contractsSMR = new List<TrackerDB.Models.ContractSMR>();

                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count
                for (int row = 142; row <= 192; row++)
                {
                    // Проверка статуса договора ПИР (если есть договор СМР, значит договор ПИР закрыт)
                    Status checkStatusPIR = worksheet.Cells[row, 16].Value == null ? Status.Open : Status.Closed;

                    // Проверка статуса договора СМР (если есть КС-11, значит договор СМР закрыт)
                    Status statusSMR = worksheet.Cells[row, 26].Value == null ? Status.Open : Status.ClosedFirstStage;

                    contractsPIR.Add(new TrackerDB.Models.ContractPIR
                    {
                        Number = int.Parse(worksheet.Cells[row, 6].Text),
                        DateOfSigned = DateTime.ParseExact(worksheet.Cells[row, 7].Text, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                        DateOfComplete = DateTime.ParseExact(worksheet.Cells[row, 8].Text, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                        ContractSum = decimal.Parse(worksheet.Cells[row, 11].Text),
                        Status = checkStatusPIR
                    });

                    if (String.IsNullOrEmpty(worksheet.Cells[row, 16].Text) == false)
                    {
                        contractsSMR.Add(new TrackerDB.Models.ContractSMR
                        {
                            Number = int.Parse(worksheet.Cells[row, 16].Text),
                            DateOfSigned = DateTime.ParseExact(worksheet.Cells[row, 17].Text, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                            DateOfCompleteFirstStage = string.IsNullOrEmpty(worksheet.Cells[row, 18].Text) ? (DateTime?)null : DateTime.ParseExact(worksheet.Cells[row, 18].Text, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                            DateOfCompleteSecondtStage = string.IsNullOrEmpty(worksheet.Cells[row, 19].Text) ? (DateTime?)null : DateTime.ParseExact(worksheet.Cells[row, 19].Text, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                            ContractSum = decimal.Parse(worksheet.Cells[row, 22].Text),
                            Status = statusSMR
                        });

                        powerlines.Add(new TrackerDB.Models.Powerline
                        {
                            Name = worksheet.Cells[row, 3].Text,
                            ConractSMR = contractsSMR[contractsSMR.Count - 1],
                            ContractPIR = contractsPIR[contractsPIR.Count - 1]
                        });
                        contractsSMR.Clear();
                        contractsPIR.Clear();
                    }
                    else
                    {
                        powerlines.Add(new TrackerDB.Models.Powerline
                        {
                            Name = worksheet.Cells[row, 3].Text,
                            ContractPIR = contractsPIR[contractsPIR.Count - 1]
                        });
                        contractsPIR.Clear();
                    }


                }

                contextDB.Powerlines.AddRange(powerlines);
                contextDB.SaveChanges();
            }
        }
    }
}
