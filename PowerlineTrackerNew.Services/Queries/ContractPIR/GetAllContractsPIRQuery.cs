using System.Collections.Generic;
using TrackerDB;
using System.Linq;

namespace PowerlineTrackerNew.Services.Queries.ContractPIR
{
    class GetAllContractsPIRQuery
    {
        public List<TrackerDB.Models.ContractPIR> Execute(ContextDB DB)
        {
            return DB.ContractPIRs.ToList();

        }
    }
}
