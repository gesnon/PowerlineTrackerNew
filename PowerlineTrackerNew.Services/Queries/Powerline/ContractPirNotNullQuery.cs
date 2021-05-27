using System.Collections.Generic;
using System.Linq;

namespace PowerlineTrackerNew.Services.Queries.Powerline
{
    public class ContractPirNotNullQuery : BaseQuery
    {
        public List<Models.Powerline> Execute()
        {
            return this.Context.Where(_ => _.ContractPIR != null).ToList();
        }
    }
}
