using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_Shared.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public int FlightId { get; set; }
    }
}
