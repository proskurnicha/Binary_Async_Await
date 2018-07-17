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

            aircraft.AircraftName = entity.AircraftName;
            aircraft.DateRelease = entity.DateRelease;
            aircraft.Lifetime = entity.Lifetime;
            aircraft.TypeAircraftId = entity.TypeAircraftId;
            aircraft.TypeAircraft = context.Set<TypeAircraft>().Where(x => x.Id == entity.TypeAircraftId).FirstOrDefault();

            return await base.GetById(filter);
        }
    }
}
