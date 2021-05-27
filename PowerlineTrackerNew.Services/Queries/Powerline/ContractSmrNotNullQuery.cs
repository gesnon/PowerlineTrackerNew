using System.Collections.Generic;
using System.Linq;

namespace PowerlineTrackerNew.Services.Queries.Powerline
{
    public class ContractSmrNotNullQuery : BaseQuery
    {
        public List<Models.Powerline> Execute()
        {
            return this.Context.Where(_ => _.ConractSMR != null).ToList();
        }
    }
}
