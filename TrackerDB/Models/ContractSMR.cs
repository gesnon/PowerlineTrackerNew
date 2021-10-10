using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrackerDB.Models.ENUMS;

namespace TrackerDB.Models
{
    public class ContractSMR
    {
        public int Number { get; set; }
        public DateTime DateOfSigned { get; set; }

        public DateTime? DateOfCompleteFirstStage { get; set; }

        public DateTime? DateOfCompleteSecondtStage { get; set; }

        public Status Status { get; set; }

        public decimal ContractSum { get; set; }

        public List<AdditionalAgreementSMR> AdditionalAgreements { get; set; }

        public int ID { get; set; }
               
    }
}