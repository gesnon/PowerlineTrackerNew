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
    [Route("[controller]")]
    public class ContractPIRController : ControllerBase
    {
        private readonly ILogger<ContractPIRController> logger;
        private readonly IExcelReportService excelReportService;
        private readonly IContractPIRService contractPIRService;
        private readonly IPowerlineService powerlineService;

        public ContractPIRController(ILogger<ContractPIRController> logger, IExcelReportService excelReportService, IContractPIRService contractPIRService, IPowerlineService powerlineService)
        {
            this.logger = logger;
            this.excelReportService = excelReportService;
            this.contractPIRService = contractPIRService;
            this.powerlineService = powerlineService;
            //  _logger = logger;
        }

        [HttpGet("{status}")]
        public IEnumerable<ContractPIRDTO> Get(Status status)
        {
            return  this.powerlineService.GetFiltredContracts(status, ContractType.PIR).ContractsPIRDTO;
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
