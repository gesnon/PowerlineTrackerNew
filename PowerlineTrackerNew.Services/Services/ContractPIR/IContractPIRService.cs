using OfficeOpenXml;
using PowerlineTrackerNew.Services.DTO;
using System.Collections.Generic;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Services
{
    public interface IContractPIRService
    {
        public List<ContractPIR> GetAllContractsPIR();
        public void BuildAllContractsPIRExcelReport(ExcelWorksheet worksheet);
        public List<ContractPIRDTO> GetAllContractsPIRDTO();
        public void UpdateContractPIR(int ID, ContractPIRDTO newContractPIR);
        public void AddContractPIR(ContractPIRDTO newContractPIR);

        public ContractPIR GetContractByID(int ID);

        public ContractPIRDTO GetContractPIRDTOByID(int ID);
    }
}