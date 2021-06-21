using System.Collections.Generic;
using TrackerDB;
using System.Linq;

namespace PowerlineTrackerNew.Services.Queries.ContractSMR
{
    class GetAllContractsSMRQuery
    {
        public List<TrackerDB.Models.ContractSMR> Execute(ContextDB DB)
        {
            return DB.ContractSMRs.ToList();

        }
    }
}