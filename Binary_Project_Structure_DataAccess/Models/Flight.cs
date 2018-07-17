using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Binary_Project_Structure_DataAccess.Models
{
    public class Flight
    {
        [Required]
        [Range(1, 999, ErrorMessage = "Unacceptable id")]
        public int Id { get; set; }

        [Required]
        public string DeparturePoint { get; set; }

        [Required]
        public TimeSpan DepartureTime { get; set; }

        [Required]
        public string ArrivalPoint { get; set; }

        [Required]
        public TimeSpan ArrivalTime { get; set; }

        [Required]
        public List<Ticket> Tickets { get; set; }
    }
}
