using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerlineTrackerNew.Services;
using PowerlineTrackerNew.Services.DTO;
using PowerlineTrackerNew.Services.ENUMS;
using PowerlineTrackerNew.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using TrackerDB.Models.ENUMS;

namespace PowerlineTrackerNew.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ContractsController : ControllerBase
    {
        private readonly ILogger<PowerlineController> _logger;
        private readonly IExcelReportService excelReportService;
        private readonly IContractService contractService;

        public ContractsController(ILogger<ContractPIRController> logger, IExcelReportService excelReportService, IContractService contractService)
        {
            this.excelReportService = excelReportService;
            this.contractService = contractService;

            //  _logger = logger;
        }            

        public IActionResult GetContractsNeededClose(DateTime date)
        {
            MemoryStream stream = this.excelReportService.GetAllContractsEndsExcelReport(date);

            return File(stream, Constants.ExcelContentType, $"Report {DateTime.Today.ToShortDateString()}.xlsx");
        }

        public ContractsDTO GetFiltredContracts(Status status, ContractType contractType)
        {
           return contractService.GetContractsDTO(status, contractType);
        }
    }
}
