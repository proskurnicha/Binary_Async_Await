using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_DataAccess.Repositories;
namespace Binary_Project_Structure_DataAccess.Repositories
{
    public class AircraftRepository : Repository<Aircraft>
    {
        public async override Task<Aircraft> Update(Aircraft entity)
        {
            Expression<Func<Aircraft, bool>> filter = x => x.Id == entity.Id;
            Aircraft aircraft = await base.GetById(filter);

            if (aircraft == null)
                return null;

            context.Set<Aircraft>().FirstOrDefault(filter).AircraftName = entity.AircraftName;
            context.Set<Aircraft>().FirstOrDefault(filter).DateRelease = entity.DateRelease;
            context.Set<Aircraft>().FirstOrDefault(filter).Lifetime = entity.Lifetime;
            context.Set<Aircraft>().FirstOrDefault(filter).TypeAircraftId = entity.TypeAircraftId;
            context.Set<Aircraft>().FirstOrDefault(filter).TypeAircraft = entity.TypeAircraft;
            await context.SaveChangesAsync();
            return await base.GetById(filter);
        }
    }
}
