using System;
using System.Collections.Generic;
using System.Text;
using TrackerDB.Models;
using TrackerDB.Models.ENUMS;

namespace PowerlineTrackerNew.Services.DTO
{
    public class ContractPIRDTO
    {
        public int Number { get; set; }
        public string DateOfSigned { get; set; }
        public string DateOfComplete { get; set; }
        public decimal ContractSum { get; set; }
        public Status Status { get; set; }

        public List<AdditionalAgreement> AdditionalAgreements { get; set; }

    }
}
