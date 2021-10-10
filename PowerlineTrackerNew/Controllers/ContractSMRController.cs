using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerlineTrackerNew.Services;
using PowerlineTrackerNew.Services.DTO;
using PowerlineTrackerNew.Services.Infrastructure;
using PowerlineTrackerNew.Services.Reports;
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
        private readonly ILogger<PowerlineController> _logger;
        private readonly ContextDB ContextDB;


        public ContractSMRController(ILogger<ContractSMRController> logger, ContextDB contextDB)
        {
            this.ContextDB = contextDB;
            //  _logger = logger;
        }

        public IEnumerable<ContractSMRDTO> Get()
        {

            //this.ContextDB.SaveChanges();

            return ContextDB.ContractSMRs.
                Select(c => new ContractSMRDTO
                {
                    Number = c.Number,
                    DateOfSigned = c.DateOfSigned.ToString("dd.MM.yy"),
                    DateOfCompleteFirstStage = c.DateOfCompleteFirstStage.HasValue ? c.DateOfCompleteFirstStage.Value.ToString("dd.MM.yy") : "",
                    DateOfCompleteSecondtStage = c.DateOfCompleteSecondtStage.HasValue ? c.DateOfCompleteSecondtStage.Value.ToString("dd.MM.yy") : "",
                    ContractSum = c.ContractSum,
                    Status=c.Status
                }).ToList();

        }

        [HttpPut]
        public void Put(int ID, ContractSMRDTO newContractSMR)
        {
            ContractSMR oldContractSMR = this.ContextDB.ContractSMRs.First(c => c.ID == ID);

            if (newContractSMR.Number != 0)
            {
                oldContractSMR.Number = newContractSMR.Number;
            }
            if (newContractSMR.DateOfSigned != null)
            {
                oldContractSMR.DateOfSigned = DateTime.Parse(newContractSMR.DateOfSigned);
            }
            if (newContractSMR.DateOfCompleteFirstStage != null)
            {
                oldContractSMR.DateOfCompleteFirstStage = DateTime.Parse(newContractSMR.DateOfCompleteFirstStage);
            }
            if (newContractSMR.DateOfCompleteSecondtStage != null)
            {
                oldContractSMR.DateOfCompleteSecondtStage = DateTime.Parse(newContractSMR.DateOfCompleteSecondtStage);
            }
            if (newContractSMR.ContractSum != 0)
            {
                oldContractSMR.ContractSum = newContractSMR.ContractSum;
            }
            if (newContractSMR.Status != newContractSMR.Status)    // не понимаю как правильно отследить изменение поля bool если оно не заполняется в форме
            {
                oldContractSMR.Status = newContractSMR.Status;            }
 

            this.ContextDB.SaveChanges();
        }

        [HttpPost]
        public void Post(ContractSMRDTO newContractSMR)
        {
            this.ContextDB.ContractSMRs.Add(new ContractSMR
            {
                Number = newContractSMR.Number,
                DateOfSigned = DateTime.Parse(newContractSMR.DateOfSigned),
                DateOfCompleteFirstStage = DateTime.Parse(newContractSMR.DateOfCompleteFirstStage),
                DateOfCompleteSecondtStage = DateTime.Parse(newContractSMR.DateOfCompleteSecondtStage),
                ContractSum = newContractSMR.ContractSum,
                Status=newContractSMR.Status
            });

            this.ContextDB.SaveChanges();
        }


        public IActionResult GetAllContractsSMRReport()
        {
            GetAllContractsSMRReport report = new GetAllContractsSMRReport(ContextDB); // объявляю сервис
            ExcelBuilder builder = new ExcelBuilder();
            byte[] file = builder.BuildFile(report);
            MemoryStream stream = new MemoryStream(file);

            return File(stream, Constants.ExcelContentType, report.ReportFileName);
        }
    }
}
