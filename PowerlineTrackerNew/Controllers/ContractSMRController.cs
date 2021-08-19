using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerlineTrackerNew.Services;
using PowerlineTrackerNew.Services.DTO;
using PowerlineTrackerNew.Services.Infrastructure;
using PowerlineTrackerNew.Services.Reports;
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

        [HttpPut]
        public void Put(int ID, ContractSMRDTO newContractSMR)
        {
            ContractSMR oldContractSMR = this.ContextDB.ContractSMRs.First(c => c.ID == ID);

            if (newContractSMR.Number != 0)
            {
                oldContractSMR.Number = newContractSMR.Number;
            }
            if (newContractSMR.DateOfCompleteFirstStage != null)
            {
                oldContractSMR.DateOfCompleteFirstStage = newContractSMR.DateOfCompleteFirstStage;
            }
            if (newContractSMR.DateOfCompleteSecondtStage != null)
            {
                oldContractSMR.DateOfCompleteSecondtStage = newContractSMR.DateOfCompleteSecondtStage;
            }
            if (newContractSMR.ContractSum != 0)
            {
                oldContractSMR.ContractSum = newContractSMR.ContractSum;
            }
            if (newContractSMR.ClosedFirstStage != newContractSMR.ClosedFirstStage)    // не понимаю как правильно отследить изменение поля bool если оно не заполняется в форме
            {
                oldContractSMR.ClosedFirstStage = newContractSMR.ClosedFirstStage;
            }
            if (newContractSMR.ClosedSecondStage != newContractSMR.ClosedSecondStage)    // не понимаю как правильно отследить изменение поля bool если оно не заполняется в форме
            {
                oldContractSMR.ClosedSecondStage = newContractSMR.ClosedSecondStage;
            }

            this.ContextDB.SaveChanges();
        }

        [HttpPost]
        public void Post(ContractSMRDTO newContractSMR)
        {
            this.ContextDB.ContractSMRs.Add(new ContractSMR
            {
                Number = newContractSMR.Number,
                DateOfSigned = newContractSMR.DateDateOfSigned,
                DateOfCompleteFirstStage = newContractSMR.DateOfCompleteFirstStage,
                DateOfCompleteSecondtStage = newContractSMR.DateOfCompleteSecondtStage,
                ContractSum = newContractSMR.ContractSum,
                ClosedFirstStage = false,
                ClosedSecondStage=false
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
