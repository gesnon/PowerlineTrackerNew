namespace PowerlineTrackerNew.Services
{
    using OfficeOpenXml;

    public interface IExcelReport   
    {
        void BuildExcelWorksheet(ExcelWorksheet worksheet);
    }
}
