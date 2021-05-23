using OfficeOpenXml;
using PowerlineTrackerNew.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerlineTrackerNew.Services.Reports
{
    public class PowerlineReportService : IExcelDownloadable
    {
        public void BuildExcelWorksheet(ExcelWorksheet worksheet)
        {
            List<Powerline> Powerlines = new List<Powerline>
            {
                new Powerline { Name = "test powerline 1", Comments = "test comments 1", ID = 1, ConractSMR = new ContractSMR { Number = 1111 }, ContractPIR = new ContractPIR { Number = 2222 }, InternalNotes = new List<InternalNote> { new InternalNote { Theme = "test internal Note 1" } } },
                new Powerline { Name = "test powerline 2", Comments = "test comments 2", ID = 2, ConractSMR = new ContractSMR { Number = 3333 }, ContractPIR = new ContractPIR { Number = 4444 }, InternalNotes = new List<InternalNote> { new InternalNote { Theme = "test internal Note 2" } } }
            };

            for (int i = 0; i < Powerlines.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = $"ID: {Powerlines[i].ID} ";
                worksheet.Cells[i + 2, 2].Value = $"Наименование объекта: {Powerlines[i].Name}";
                worksheet.Cells[i + 2, 3].Value = $"Номер договора ПИР: {Powerlines[i].ContractPIR}";
                worksheet.Cells[i + 2, 3].Value = $"Номер договора СМР: {Powerlines[i].ConractSMR}";
                worksheet.Cells[i + 2, 3].Value = $"Служебные записки: {Powerlines[i].InternalNotes[0].Theme}";
            }
        }
    }
}
