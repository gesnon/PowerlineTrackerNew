using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TrackerDB;

namespace PowerlineTrackerNew.Services.Queries.Powerline
{
    public class ContractPirNotNullQuery
    {
        public List<TrackerDB.Models.Powerline> Execute(ContextDB DB)
        {
            return DB.Powerlines.Include(_ => _.ContractPIR).Include(_ => _.ConractSMR).Where(_ => _.ContractPIR != null).ToList();

        }
    }
}
