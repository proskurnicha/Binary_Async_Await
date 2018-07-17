using Binary_Project_Structure_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_DataAccess.Repositories;
using System.Linq;

namespace Binary_Project_Structure_DataAccess.Repositories
{
    public class DepartureRepositoty : Repository<Departure>
    {
        public override Departure Update(Departure entity)
        {
            Func<Departure, bool> filter = x => x.Id == entity.Id;
            Departure departure = base.GetById(filter);

            if (departure == null)
                return null;

            departure.AircraftId = entity.AircraftId;
            departure.Aircraft  = context.Set<Aircraft>().Where(x => x.Id == entity.AircraftId).FirstOrDefault();
            departure.CrewId = entity.CrewId;
            departure.Crew = context.Set<Crew>().Where(x => x.Id == entity.CrewId).FirstOrDefault();
            departure.DepartureTime = entity.DepartureTime;
            departure.FlightId = entity.FlightId;
            departure.Flight = context.Set<Flight>().Where(x => x.Id == entity.FlightId).FirstOrDefault();
            return departure;
        }
    }
}
