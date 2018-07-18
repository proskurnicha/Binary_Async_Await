using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_DataAccess.Models
{
    public class Departure
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int FlightId { get; set; }

        [Required]
        public Flight Flight { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public int CrewId { get; set; }

        [Required]
        public Crew Crew { get; set; }

        [Required]
        public int AircraftId { get; set; }

        [Required]
        public Aircraft Aircraft { get; set; }
    }
}
