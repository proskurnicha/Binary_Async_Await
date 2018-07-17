using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_DataAccess.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Binary_Project_Structure_DataAccess.Repositories
{
    public class FlightRepository : Repository<Flight>
    {
        public override List<Flight> GetAll()
        {
            return context.Set<Flight>().Include(s => s.Tickets).ToList();
        }

        public override Flight Update(Flight entity)
        {
            Func<Flight, bool> filter = x => x.Id == entity.Id;
            Flight flight = base.GetById(filter);

            if (flight == null)
                return null;

            flight.ArrivalPoint = entity.ArrivalPoint;
            flight.ArrivalTime = entity.ArrivalTime;
            flight.DeparturePoint = entity.DeparturePoint;
            flight.DepartureTime = entity.DepartureTime;
            flight.Tickets = entity.Tickets;
            return flight;
        }
    }
}
