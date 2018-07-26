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

        public async override Task<Flight> GetById(Expression<Func<Flight, bool>> filter)
        {
            Flight query = await context.Set<Flight>().Include(s => s.Tickets).FirstOrDefaultAsync(filter);

            if (query == null)
                return null;

            return query;
        }


        public async override Task<Flight> Update(Flight entity)
        {
            Expression<Func<Flight, bool>> filter = x => x.Id == entity.Id;
            Flight flight = await base.GetById(filter);

            if (flight == null)
                return null;

            context.Set<Flight>().Include(s => s.Tickets).FirstOrDefault(filter).ArrivalPoint = entity.ArrivalPoint;
            context.Set<Flight>().Include(s => s.Tickets).FirstOrDefault(filter).ArrivalTime = entity.ArrivalTime;
            context.Set<Flight>().Include(s => s.Tickets).FirstOrDefault(filter).DeparturePoint = entity.DeparturePoint;
            context.Set<Flight>().Include(s => s.Tickets).FirstOrDefault(filter).DepartureTime = entity.DepartureTime;
            //if (entity.Tickets != null)
            //{
            //    TicketRepository ticketRepository = new TicketRepository();
            //    foreach (var ticket in entity.Tickets)
            //    {
            //        Ticket ticketInDb = context.Set<Ticket>().FirstOrDefault(x => x.Id == ticket.Id);
            //        if (ticketInDb == null)
            //        {
            //            await ticketRepository.Create(ticketInDb);
            //        }
            //        await ticketRepository.Update(ticketInDb);
            //    }
            //}

            await context.SaveChangesAsync();
            return flight;
        }
    }
}
