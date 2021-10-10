using System;
using System.Collections.Generic;
using System.Text;
using TrackerDB.Models;

namespace PowerlineTrackerNew.Services.DTO
{
    public class ContractPIRDTO
    {
        public int Number { get; set; }
        public string DateDateOfSigned { get; set; }
        public string DateOfComplete { get; set; }
        public decimal ContractSum { get; set; }
        public bool Closed { get; set; }

        public List<AdditionalAgreement> AdditionalAgreements { get; set; }

    }
}
