using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_Shared.DTOs
{
    public class FlightDto
    {
        public int Id { get; set; }

        public string DeparturePoint { get; set; }

        public TimeSpan DepartureTime { get; set; }

        public string ArrivalPoint { get; set; }

        public TimeSpan ArrivalTime { get; set; }

        public List<TicketDto> Tickets { get; set; }
    }
}
