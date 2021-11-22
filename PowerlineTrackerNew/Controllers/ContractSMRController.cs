using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerlineTrackerNew.Services;
using PowerlineTrackerNew.Services.DTO;
using PowerlineTrackerNew.Services.ENUMS;
using PowerlineTrackerNew.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TrackerDB;
using TrackerDB.Models;
using TrackerDB.Models.ENUMS;

namespace PowerlineTrackerNew.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractSMRController : ControllerBase
    {
        private readonly ILogger<ContractSMRController> logger;
        private readonly IContractSMRService contractSMRService;
        private readonly IExcelReportService excelReportService;
        private readonly IPowerlineService powerlineService;

        public ContractSMRController(ILogger<ContractSMRController> logger, IContractSMRService contractSMRService, IExcelReportService excelReportService, IPowerlineService powerlineService)
        {
            this.logger = logger;
            this.contractSMRService = contractSMRService;
            this.excelReportService = excelReportService;
            this.powerlineService = powerlineService;
            //  _logger = logger;
        }

        [HttpGet("{status}")]
        public IEnumerable<ContractSMRDTO> Get(Status status)
        {
            return this.powerlineService.GetFiltredContracts(status, ContractType.SMR).ContractsSMRDTO;
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
