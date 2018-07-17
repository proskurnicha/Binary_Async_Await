using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_DataAccess.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Binary_Project_Structure_DataAccess.Repositories
{
    public class FlightRepository : Repository<Flight>
    {
        public async override Task<List<Flight>> GetAll()
        {
            return await context.Set<Flight>().Include(s => s.Tickets).ToListAsync();
        }

        public async override Task<Flight> Update(Flight entity)
        {
            Expression<Func<Flight, bool>> filter = x => x.Id == entity.Id;
            Flight flight = await base.GetById(filter);

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
