using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_DataAccess.Models
{
    public class Ticket
    {
        [Required]
        [StringLength(3, MinimumLength = 6, ErrorMessage = "Unacceptable id")]
        public int Id { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 6, ErrorMessage = "Unacceptable Flight id")]
        public int FlightId { get; set; }

        [Required]
        public Flight Flight { get; set; }
    }
}
