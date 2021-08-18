﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerlineTrackerNew.Services;
using PowerlineTrackerNew.Services.DTO;
using PowerlineTrackerNew.Services.Infrastructure;
using PowerlineTrackerNew.Services.Reports;
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
        private readonly ContextDB ContextDB;                             // эта строка добавляется при подключении базы данных

        public PowerlineController(ILogger<PowerlineController> logger, ContextDB contextDB)
        {
            this.ContextDB = contextDB;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Powerline> Get()
        {
            List<Powerline> testPowerlines = new List<Powerline>
            {
                new Powerline{Name="testName 1",ContractPIR = new ContractPIR{Number=1,ContractSum=100000, DateOfComplete = new System.DateTime(2021,06,14) }, ConractSMR = new ContractSMR{Number=2,ContractSum=200000, DateOfCompleteFirstStage= new System.DateTime(2021,06,15) } },
                new Powerline{Name="testName 2",ContractPIR = new ContractPIR{Number=3,ContractSum=100000 }},
                new Powerline{Name="testName 4",ConractSMR = new ContractSMR{Number=6,ContractSum=600000, DateOfCompleteSecondtStage= new System.DateTime(2021,06,13) }},
                new Powerline{Name="testName 3",ContractPIR = new ContractPIR{Number=5,ContractSum=100000 }, ConractSMR = new ContractSMR{Number=6,ContractSum=200000 } }
            };

            this.ContextDB.Powerlines.AddRange(testPowerlines);
            this.ContextDB.SaveChanges();

            return ContextDB.Powerlines.ToList();

        }

        [HttpPost]
        public void Post(PowerlineDTO powerline)
        {
            this.ContextDB.Powerlines.Add(new Powerline { Name = powerline.Name });
            this.ContextDB.SaveChanges();
        }

        [HttpPut]
        public void Put(int ID, PowerlineDTO powerline)
        {
            Powerline OldPOwerline = this.ContextDB.Powerlines.First(p => p.ID == ID);

            OldPOwerline.Name = powerline.Name;

            OldPOwerline.Comments = powerline.Comments;

            this.ContextDB.SaveChanges();

        }

        [HttpGet]
        public IActionResult ContractPirNotNullReport()
        {
            PowerlineContractPirNotNullReport report = new PowerlineContractPirNotNullReport(ContextDB); // объявляю сервис
            ExcelBuilder builder = new ExcelBuilder();
            byte[] file = builder.BuildFile(report);
            MemoryStream stream = new MemoryStream(file);

            return File(stream, Constants.ExcelContentType, report.ReportFileName);
        }

        [HttpGet]
        public IActionResult ContractSmrNotNullReport()
        {
            PowerlineContractSmrNotNullReport report = new PowerlineContractSmrNotNullReport(ContextDB); // объявляю сервис
            ExcelBuilder builder = new ExcelBuilder();
            byte[] file = builder.BuildFile(report);
            MemoryStream stream = new MemoryStream(file);

            return File(stream, Constants.ExcelContentType, report.ReportFileName);
        }
    }
}
