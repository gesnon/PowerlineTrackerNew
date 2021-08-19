using System;
using System.Collections.Generic;
using System.Text;

namespace PowerlineTrackerNew.Services.DTO
{
    public class ContractSMRDTO
    {
        public int Number { get; set; }
        public DateTime DateDateOfSigned { get; set; }
        public DateTime DateOfCompleteFirstStage { get; set; }
        public DateTime DateOfCompleteSecondtStage { get; set; }
        public decimal ContractSum { get; set; }
        public bool ClosedFirstStage { get; set; }
        public bool ClosedSecondStage { get; set; }

    }
}
