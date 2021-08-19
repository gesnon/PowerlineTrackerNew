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
    public class ContractPIRController : ControllerBase
    {
        private readonly ILogger<PowerlineController> _logger;
        private readonly ContextDB ContextDB;


        public ContractPIRController(ILogger<ContractPIRController> logger, ContextDB contextDB)
        {
            this.ContextDB = contextDB;
          //  _logger = logger;
        }

        [HttpPut]
        public void Put(int ID, ContractPIRDTO newContractPIR)
        {
            ContractPIR oldContractPIR = this.ContextDB.ContractPIRs.First(c => c.ID == ID);

            if (newContractPIR.Number != 0)
            {
                oldContractPIR.Number = newContractPIR.Number;
            }
            if (newContractPIR.DateOfComplete != null)
            {
                oldContractPIR.DateOfComplete = newContractPIR.DateOfComplete;
            }
            if (newContractPIR.ContractSum != 0)
            {
                oldContractPIR.ContractSum = newContractPIR.ContractSum;
            }
            if (newContractPIR.Closed != oldContractPIR.Closed)    // не понимаю как правильно отследить изменение поля bool если оно не заполняется в форме
            {
                oldContractPIR.Closed = newContractPIR.Closed;
            }

            this.ContextDB.SaveChanges();
        }

        [HttpPost]
        public void Post(ContractPIRDTO newContractPIR)
        {          
            this.ContextDB.ContractPIRs.Add(new ContractPIR
            {
                Number = newContractPIR.Number,
                DateOfSigned = newContractPIR.DateDateOfSigned,
                DateOfComplete = newContractPIR.DateOfComplete,
                ContractSum = newContractPIR.ContractSum,
                Closed = false
            });

            this.ContextDB.SaveChanges();
        }


        public IActionResult GetAllContractsPIRReport()
        {
            GetAllContractsPIRReport report = new GetAllContractsPIRReport(ContextDB); // объявляю сервис
            ExcelBuilder builder = new ExcelBuilder();
            byte[] file = builder.BuildFile(report);
            MemoryStream stream = new MemoryStream(file);

            return File(stream, Constants.ExcelContentType, report.ReportFileName);
        }
    }
}
