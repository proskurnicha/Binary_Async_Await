using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Binary_Project_Structure_DataAccess.Repositories
{
    public class CrewRepository : Repository<Crew>
    {
        public override List<Crew> GetAll()
        {
            return context.Set<Crew>().Include(s => s.Stewardesses).ToList();
        }

        public override Crew Update(Crew entity)
        {
            Func<Crew, bool> filter = x => x.Id == entity.Id;
            Crew crew = base.GetById(filter);

            if (crew == null)
                return null;

            crew.PilotId = entity.PilotId;
            var query = context.Set<Pilot>().Where(x => x.Id == entity.PilotId);

            crew.Pilot = context.Set<Pilot>().Where(x => x.Id == entity.PilotId).FirstOrDefault();
            crew.Stewardesses = entity.Stewardesses;
            return crew;
        }
    }
}
