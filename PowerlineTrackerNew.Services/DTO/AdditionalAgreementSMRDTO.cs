using System;
using System.Collections.Generic;
using System.Text;

namespace PowerlineTrackerNew.Services.DTO
{
    public class AdditionalAgreementSMRDTO
    {
        public int Number { get; set; }
        public DateTime DateOfSigned { get; set; }
        public DateTime? NewCloseFirstStage { get; set; }
        public DateTime? NewCloseSecondtStage { get; set; }
        public decimal NewSumm { get; set; }
        public int ContractID { get; set; }
        public int ID { get; set; }
    }
}
