using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TrackerDB;

namespace PowerlineTrackerNew.Services.Queries.Powerline
{
    public class ContractSmrNotNullQuery 
    {
        public List<TrackerDB.Models.Powerline> Execute(ContextDB DB)
        {
            return DB.Powerlines.Include(_ => _.ConractSMR).Include(_=>_.ContractPIR).Where(_ => _.ConractSMR != null).ToList();
        }
    }
}
