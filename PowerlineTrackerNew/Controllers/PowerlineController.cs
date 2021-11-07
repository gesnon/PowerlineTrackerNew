using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PowerlineTrackerNew.Services;
using PowerlineTrackerNew.Services.DTO;
using PowerlineTrackerNew.Services.Infrastructure;
using PowerlineTrackerNew.Services.Queries.Powerline;
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
        public IEnumerable<PowerlineDTO> Get()
        {

            return ContextDB.Powerlines.Include(_ => _.ContractPIR).Include(_ => _.ConractSMR).
                Select(c => new PowerlineDTO { Name = c.Name, ContractPIRNumber = c.ContractPIR != null ? c.ContractPIR.Number.ToString() : " ",
                ContractSMRNumber = c.ConractSMR != null ? c.ConractSMR.Number.ToString() : " ", Comments = c.Comments }).ToList();

        }

        [HttpPost]
        public void Post(PowerlineDTO powerline)
        {
            this.ContextDB.Powerlines.Add(new Powerline { Name = powerline.Name });
            this.ContextDB.SaveChanges();
        }

        [HttpPut]
        public void Put(int ID, PowerlineDTO newPowerline)
        {
            Powerline OldPOwerline = this.ContextDB.Powerlines.First(p => p.ID == ID);

            if (newPowerline.Name != null)
            {
                OldPOwerline.Name = newPowerline.Name;
            }
            if (newPowerline.Comments != null)
            {
                OldPOwerline.Comments = newPowerline.Comments;

            }

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
        
        /*[Route ("FillTables")]*/ [HttpPost]
        public void FillDataBase(IFormFile file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), file.FileName);

            FileStream stream = new FileStream(path, FileMode.Create);

            file.CopyTo(stream);

            PowerlineServices powerlineServices = new PowerlineServices();

            powerlineServices.FillTables(stream, ContextDB);
        }
        

    }
}
