using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_DataAccess.Models
{
    public class Departure
    {
        [Required]
        [StringLength(3, MinimumLength = 6, ErrorMessage = "Unacceptable id")]
        public int Id { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 6, ErrorMessage = "Unacceptable Flight id")]
        public int FlightId { get; set; }

        [Required]
        public Flight Flight { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 6, ErrorMessage = "Unacceptable Crew id")]
        public int CrewId { get; set; }

        [Required]
        public Crew Crew { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 6, ErrorMessage = "Unacceptable  Aircraft id")]
        public int AircraftId { get; set; }

        [Required]
        public Aircraft Aircraft { get; set; }
    }
}
