using System;
using System.Collections.Generic;
using System.Text;

namespace PowerlineTrackerNew.Services.DTO
{
    public class AdditionalAgreementPIRDTO
    {
        public int Number { get; set; }
        public DateTime DateOfSigned { get; set; }
        public DateTime? NewCloseDate { get; set; }
        public decimal NewSumm { get; set; }
        public int ContractID { get; set; }
        public int ID { get; set; }
    }
}
