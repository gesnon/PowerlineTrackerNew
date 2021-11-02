using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerlineTrackerNew.Services;
using PowerlineTrackerNew.Services.DTO;
using PowerlineTrackerNew.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;

namespace PowerlineTrackerNew.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ContractPIRController : ControllerBase
    {
        private readonly ILogger<ContractPIRController> logger;
        private readonly IExcelReportService excelReportService;
        private readonly IContractPIRService contractPIRService;

        public ContractPIRController(ILogger<ContractPIRController> logger, IExcelReportService excelReportService, IContractPIRService contractPIRService)
        {
            this.logger = logger;
            this.excelReportService = excelReportService;
            this.contractPIRService = contractPIRService;
            //  _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ContractPIRDTO> Get()
        {

            return this.contractPIRService.GetAllContractsPIRDTO();
        }

        [HttpPut]
        public void Put(int ID, ContractPIRDTO newContractPIR)
        {
            this.contractPIRService.UpdateContractPIR(ID, newContractPIR);
        }

        [HttpPost]
        public void Post(ContractPIRDTO newContractPIR)
        {
            this.contractPIRService.AddContractPIR(newContractPIR);
        }

        public IActionResult GetAllContractsPIRReport()
        {            
            MemoryStream stream = this.excelReportService.GetAllContractsPIRExcelReport();

            return File(stream, Constants.ExcelContentType, $"Report {DateTime.Today.ToShortDateString()}.xlsx");
        }
    }
}
