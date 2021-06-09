using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerlineTrackerNew.Services;
using PowerlineTrackerNew.Services.Infrastructure;
using PowerlineTrackerNew.Services.Reports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrackerDB;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PowerlineController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

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
            //List<Powerline> testPowerlines = new List<Powerline>
            //{
            //    new Powerline{Name="testName 1",ContractPIR = new ContractPIR{Number=1,ContractSum=100000 }, ConractSMR = new ContractSMR{Number=2,ContractSum=200000 } },
            //    new Powerline{Name="testName 2",ContractPIR = new ContractPIR{Number=3,ContractSum=100000 }},
            //    new Powerline{Name="testName 3",ContractPIR = new ContractPIR{Number=5,ContractSum=100000 }, ConractSMR = new ContractSMR{Number=6,ContractSum=200000 } }
            //};

            //this.ContextDB.AddRange(testPowerlines);
            //this.ContextDB.SaveChanges();

             return ContextDB.Powerlines.ToList();

        }

        [HttpGet]
        public IActionResult ContractPirNotNullReport()    
        {
            PowerlineContractPirNotNullReport report = new PowerlineContractPirNotNullReport(); // объявляю сервис
            ExcelBuilder builder = new ExcelBuilder(); 
            byte[] file =  builder.BuildFile(report);
            MemoryStream stream = new MemoryStream(file);

            return File(stream, Constants.ExcelContentType, report.ReportFileName);
        }

        [HttpGet]
        public IActionResult ContractSmrNotNullReport()
        {
            PowerlineContractSmrNotNullReport report = new PowerlineContractSmrNotNullReport(); // объявляю сервис
            ExcelBuilder builder = new ExcelBuilder();
            byte[] file = builder.BuildFile(report);
            MemoryStream stream = new MemoryStream(file);

            return File(stream, Constants.ExcelContentType, report.ReportFileName);
        }
    }
}
