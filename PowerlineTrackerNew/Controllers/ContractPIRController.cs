﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerlineTrackerNew.Services;
using PowerlineTrackerNew.Services.Infrastructure;
using PowerlineTrackerNew.Services.Reports;
using System.IO;
using TrackerDB;

namespace PowerlineTrackerNew.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ContractPIRController : ControllerBase
    {
        private readonly ILogger<PowerlineController> _logger;
        private readonly ContextDB ContextDB;


        public ContractPIRController(ILogger<ContractPIRController> logger, ContextDB contextDB)
        {
            this.ContextDB = contextDB;
          //  _logger = logger;
        }


        public IActionResult GetAllContractsPIRReport()
        {
            GetAllContractsPIRReport report = new GetAllContractsPIRReport(ContextDB); // объявляю сервис
            ExcelBuilder builder = new ExcelBuilder();
            byte[] file = builder.BuildFile(report);
            MemoryStream stream = new MemoryStream(file);

            return File(stream, Constants.ExcelContentType, report.ReportFileName);
        }
    }
}
