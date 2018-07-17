﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;

namespace Binary_Project_Structure_DataAccess.Repositories
{
    public class TicketRepository : Repository<Ticket>
    {
        public async override Task<Ticket> Update(Ticket entity)
        {
            Expression<Func<Ticket, bool>> filter = x => x.Id == entity.Id;
            Ticket ticket = await base.GetById(filter);

            if (ticket == null)
                return null;

            ticket.Price = entity.Price;
            ticket.FlightId = entity.FlightId;
            ticket.Flight = context.Set<Flight>().Where(flight => flight.Id == entity.FlightId).FirstOrDefault();
            return ticket;
        }
    }
}
