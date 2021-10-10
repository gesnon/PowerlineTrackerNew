using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerDB.Models
{
    public class ContractPIR
    {

        public int Number { get; set; }

        public DateTime DateOfSigned { get; set; }

        public DateTime DateOfComplete { get; set; }

        public decimal ContractSum { get; set; }

        public bool Closed { get; set; }

        public List<AdditionalAgreementPIR> AdditionalAgreements { get; set; }

        public int ID { get; set; }
    }
}