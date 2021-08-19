using System;
using System.Collections.Generic;
using System.Text;

namespace PowerlineTrackerNew.Services.DTO
{
    public class ContractPIRDTO
    {
        public int Number { get; set; }
        public DateTime DateDateOfSigned { get; set; }
        public DateTime DateOfComplete { get; set; }
        public decimal ContractSum { get; set; }
        public bool Closed { get; set; }

    }
}
