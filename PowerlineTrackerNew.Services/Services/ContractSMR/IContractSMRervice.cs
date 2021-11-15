using OfficeOpenXml;
using PowerlineTrackerNew.Services.DTO;
using System.Collections.Generic;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Services
{
    public interface IContractSMRService
    {
        public List<ContractSMR> GetAllContractsSMR();
        public void BuildAllContractsSMRExcelReport(ExcelWorksheet worksheet);
        public List<ContractSMRDTO> GetAllContractsSMRDto();
        public void UpdateContractSMR(int ID, ContractSMRDTO newContractSMR);
        public void AddContractSMR(ContractSMRDTO newContractSMR);

        public ContractSMR GetContractByID(int ID);

        public ContractSMRDTO GetContractSMRDTOByID(int ID);
    }
}