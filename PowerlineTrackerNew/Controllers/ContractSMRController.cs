using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerlineTrackerNew.Services;
using PowerlineTrackerNew.Services.DTO;
using PowerlineTrackerNew.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TrackerDB;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ContractSMRController : ControllerBase
    {
        private readonly ILogger<ContractSMRController> logger;
        private readonly IContractSMRService contractSMRService;
        private readonly IExcelReportService excelReportService;

        public ContractSMRController(ILogger<ContractSMRController> logger, IContractSMRService contractSMRService, IExcelReportService excelReportService)
        {
            this.logger = logger;
            this.contractSMRService = contractSMRService;
            this.excelReportService = excelReportService;
            //  _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ContractSMRDTO> Get()
        {
            return this.contractSMRService.GetAllContractsSMRDto();
        }

        [HttpPut]
        public void Put(int ID, ContractSMRDTO newContractSMR)
        {
            this.contractSMRService.UpdateContractSMR(ID, newContractSMR);
        }

        [HttpPost]
        public void Post(ContractSMRDTO newContractSMR)
        {
            this.contractSMRService.AddContractSMR(newContractSMR);
        }

        public IActionResult GetAllContractsSMRReport()
        {
            MemoryStream stream = this.excelReportService.GetAllContractsSMRExcelReport();

            return File(stream, Constants.ExcelContentType, $"Report {DateTime.Today.ToShortDateString()}.xlsx");
        }
    }
}
