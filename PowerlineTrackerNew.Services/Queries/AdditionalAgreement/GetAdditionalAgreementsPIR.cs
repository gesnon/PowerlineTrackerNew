using System.Collections.Generic;
using TrackerDB;
using TrackerDB.Models;
using System.Linq;

namespace PowerlineTrackerNew.Services.Queries.AdditionalAgreement
{
    public  class GetAdditionalAgreementsPIR
    {
        public List<AdditionalAgreementPIR> GetAdditionalAgreements (int ContractID, ContextDB DB)
        {
            return DB.ContractPIRs.FirstOrDefault(c => c.ID == ContractID).AdditionalAgreements.ToList();
        }
    }
}
