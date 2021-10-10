using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerDB.Models
{
    public class AdditionalAgreement
    {
        public int Number { get; set; }

        public DateTime DateOfSigned { get; set; }

        public decimal NewSumm { get; set; }

        public int ID { get; set; }

        public int ContractID { get; set; }
    }
}
