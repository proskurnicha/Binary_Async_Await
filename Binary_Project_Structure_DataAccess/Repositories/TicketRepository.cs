using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;

namespace Binary_Project_Structure_DataAccess.Repositories
{
    public class TicketRepository : Repository<Ticket>
    {
        public override Ticket Update(Ticket entity)
        {
            Func<Ticket, bool> filter = x => x.Id == entity.Id;
            Ticket ticket = base.GetById(filter);

            if (ticket == null)
                return null;

            ticket.Price = entity.Price;
            ticket.FlightId = entity.FlightId;
            ticket.Flight = context.Set<Flight>().Where(flight => flight.Id == entity.FlightId).FirstOrDefault();
            return ticket;
        }
    }
}
