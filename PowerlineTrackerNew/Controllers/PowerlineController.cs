using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class PowerlineController : ControllerBase
    {
        private readonly ILogger<PowerlineController> _logger;
        private readonly IPowerlineService powerlineService;
        private readonly IExcelReportService excelReportService;

        public PowerlineController(ILogger<PowerlineController> logger, IPowerlineService powerlineService, IExcelReportService excelReportService)
        {
            this.powerlineService = powerlineService;
            this.excelReportService = excelReportService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PowerlineDTO> Get()
        {
            return this.powerlineService.GetAllPowerlines();
        }

        [HttpPost]
        public void Post(PowerlineDTO powerline)
        {
            this.powerlineService.AddPowerline(powerline);
        }

        [HttpPut]
        public void Put(int ID, PowerlineDTO newPowerline)
        {
            this.powerlineService.UpdatePowerline(ID, newPowerline);
        }

        [HttpGet]
        public IActionResult ContractPirNotNullReport()
        {
            MemoryStream stream = this.excelReportService.PowerlineContractPirNotNullExcelReport();

            return File(stream, Constants.ExcelContentType, $"Report {DateTime.Today.ToShortDateString()}.xlsx");
        }

        [HttpGet]
        public IActionResult ContractSmrNotNullReport()
        {
            MemoryStream stream = this.excelReportService.PowerlineContractSMRNotNullExcelReport();

            return File(stream, Constants.ExcelContentType, $"Report {DateTime.Today.ToShortDateString()}.xlsx");
        }
    }
}
