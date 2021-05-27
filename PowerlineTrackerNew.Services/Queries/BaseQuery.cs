using System.Collections.Generic;
namespace PowerlineTrackerNew.Services.Queries
{
    public class BaseQuery
    {
        public List<Models.Powerline> Context { get; set; } // тут потом будет DbContext                  
    }
}
