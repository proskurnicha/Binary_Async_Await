using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_Shared.DTOs
{
    public class DepartureDto
    {
        public int Id { get; set; }

        public int FlightId { get; set; }

        public DateTime DepartureTime { get; set; }

        public int CrewId { get; set; }

        public int AircraftId { get; set; }
    }
}
