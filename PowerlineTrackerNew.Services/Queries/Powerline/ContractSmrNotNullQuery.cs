using System.Collections.Generic;
using System.Linq;

namespace PowerlineTrackerNew.Services.Queries.Powerline
{
    public class ContractSmrNotNullQuery : BaseQuery
    {
        public List<TrackerDB.Models.Powerline> Execute()
        {
            return this.DBContext.Powerlines.Where(_ => _.ConractSMR != null).ToList();
        }
    }
}
