using Binary_Project_Structure_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_DataAccess.Repositories;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Binary_Project_Structure_DataAccess.Repositories
{
    public class DepartureRepositoty : Repository<Departure>
    {
        public async override Task<Departure> Update(Departure entity)
        {
            Expression<Func<Departure, bool>> filter = x => x.Id == entity.Id;
            Departure departure = await base.GetById(filter);

            if (departure == null)
                return null;

            context.Set<Departure>().FirstOrDefault(filter).AircraftId = entity.AircraftId;
            context.Set<Departure>().FirstOrDefault(filter).Aircraft  = context.Set<Aircraft>().Where(x => x.Id == entity.AircraftId).FirstOrDefault();
            context.Set<Departure>().FirstOrDefault(filter).CrewId = entity.CrewId;
            context.Set<Departure>().FirstOrDefault(filter).Crew = context.Set<Crew>().Where(x => x.Id == entity.CrewId).FirstOrDefault();
            context.Set<Departure>().FirstOrDefault(filter).DepartureTime = entity.DepartureTime;
            context.Set<Departure>().FirstOrDefault(filter).FlightId = entity.FlightId;
            context.Set<Departure>().FirstOrDefault(filter).Flight = context.Set<Flight>().Where(x => x.Id == entity.FlightId).FirstOrDefault();
            await context.SaveChangesAsync();
            return departure;
        }
    }
}
