using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_DataAccess.Repositories;
namespace Binary_Project_Structure_DataAccess.Repositories
{
    public class AircraftRepository : Repository<Aircraft>
    {
        public override Aircraft Update(Aircraft entity)
        {
            Func<Aircraft, bool> filter = x => x.Id == entity.Id;
            Aircraft aircraft = base.GetById(filter);
            if (aircraft == null)
                return null;
            aircraft.AircraftName = entity.AircraftName;
            aircraft.DateRelease = entity.DateRelease;
            aircraft.Lifetime = entity.Lifetime;
            aircraft.TypeAircraftId = entity.TypeAircraftId;
            aircraft.TypeAircraft = context.Set<TypeAircraft>().Where(x => x.Id == entity.TypeAircraftId).FirstOrDefault();
            return base.GetById(filter);
        }
    }
}
