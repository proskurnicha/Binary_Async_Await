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

        public async override Task<Crew> GetById(Expression<Func<Crew, bool>> filter)
        {
            Crew query = await context.Set<Crew> ().Include(s => s.Stewardesses).FirstOrDefaultAsync(filter);

            if (query == null)
                return null;

            return query;
        }

        public async override Task<Crew> Update(Crew entity)
        {
            Expression<Func<Crew, bool>>filter = x => x.Id == entity.Id;
            Crew crew = await base.GetById(filter);

            if (crew == null)
                return null;

            context.Set<Crew>().FirstOrDefault(filter).Id = entity.Id;
            var pilot = await context.Set<Pilot>().FirstOrDefaultAsync(x => x.Id == entity.PilotId);
            context.Set<Crew>().FirstOrDefault(filter).Pilot = pilot;
            context.Set<Crew>().FirstOrDefault(filter).PilotId = entity.PilotId;
            await context.SaveChangesAsync();
            return crew;
        }

        public async override Task<int> AddRange(List<Crew> entities)
        {
            await context.Set<Crew>().AddRangeAsync(entities);
            int result = context.SaveChanges();
            return result ;
        }
    }
}
