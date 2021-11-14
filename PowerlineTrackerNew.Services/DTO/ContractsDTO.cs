using System;
using System.Collections.Generic;
using System.Text;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Services.DTO
{
    public class ContractsDTO
    {
        public List<ContractPIRDTO> ContractsPIRDTO { get; set; }
        public List<ContractSMRDTO> ContractsSMRDTO { get; set; }

    }
}
