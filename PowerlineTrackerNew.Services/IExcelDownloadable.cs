using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerlineTrackerNew.Services
{
    public interface IExcelDownloadable    
    {
        void BuildExcelWorksheet(ExcelWorksheet worksheet);

    }
}
