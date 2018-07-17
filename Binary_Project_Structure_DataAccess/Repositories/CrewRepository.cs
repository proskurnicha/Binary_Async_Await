using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Binary_Project_Structure_DataAccess.Repositories
{
    public class CrewRepository : Repository<Crew>
    {
        public async override Task<List<Crew>> GetAll()
        {
            return await context.Set<Crew>().Include(s => s.Stewardesses).ToListAsync();
        }

        public async override Task<Crew> Update(Crew entity)
        {
            Expression<Func<Crew, bool>>filter = x => x.Id == entity.Id;
            Crew crew = await base.GetById(filter);

            if (crew == null)
                return null;

            crew.PilotId = entity.PilotId;
            var query = await context.Set<Pilot>().FirstOrDefaultAsync(x => x.Id == entity.PilotId);

            crew.Pilot = await context.Set<Pilot>().FirstOrDefaultAsync(x => x.Id == entity.PilotId);

            crew.Stewardesses = entity.Stewardesses;
            return crew;
        }
    }
}
