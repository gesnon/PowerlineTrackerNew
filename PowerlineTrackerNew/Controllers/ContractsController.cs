using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerlineTrackerNew.Services;
using PowerlineTrackerNew.Services.Infrastructure;
using System;
using System.IO;

namespace PowerlineTrackerNew.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ContractsController : ControllerBase
    {
        private readonly ILogger<PowerlineController> _logger;
        private readonly IExcelReportService excelReportService;

        public ContractsController(ILogger<ContractPIRController> logger, IExcelReportService excelReportService)
        {
            this.excelReportService = excelReportService;
            //  _logger = logger;
        }            

        public IActionResult GetContractsNeededClose(DateTime date)
        {
            MemoryStream stream = this.excelReportService.GetAllContractsEndsExcelReport(date);

            return File(stream, Constants.ExcelContentType, $"Report {DateTime.Today.ToShortDateString()}.xlsx");
        }
    }
}
