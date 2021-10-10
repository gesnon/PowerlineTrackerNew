using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerDB.Models
{
    public class AdditionalAgreementSMR: AdditionalAgreement
    {
        public DateTime? NewCloseFirstStage { get; set; }

        public DateTime? NewCloseSecondtStage { get; set; }
    }
}
