using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TrackerDB;

namespace PowerlineTrackerNew.Services.Queries.Powerline
{
    public class GetAllPowerlines

    {
        public List<TrackerDB.Models.Powerline> Execute(ContextDB DB)
        {
            return DB.Powerlines.ToList();
        }
    }
}
