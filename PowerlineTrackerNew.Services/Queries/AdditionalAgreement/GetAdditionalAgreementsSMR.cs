using System.Collections.Generic;
using TrackerDB;
using TrackerDB.Models;
using System.Linq;

namespace PowerlineTrackerNew.Services.Queries.AdditionalAgreement
{
    public class GetAdditionalAgreementsSMR
    {
        public List<AdditionalAgreementSMR> GetAdditionalAgreements(int ContractID, ContextDB DB)
        {
            return DB.ContractSMRs.FirstOrDefault(c => c.ID == ContractID).AdditionalAgreements.ToList();
        }
    }
}
