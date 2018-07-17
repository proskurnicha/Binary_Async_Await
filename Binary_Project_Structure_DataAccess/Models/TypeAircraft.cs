using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_DataAccess.Models
{
    public class TypeAircraft
    {
        [Required]
        [StringLength(3, MinimumLength = 6, ErrorMessage = "Unacceptable id")]
        public int Id { get; set; }

        [Required]
        [Range(1, 15, ErrorMessage = "Unacceptable aircraft model")]
        public AircraftModel AircraftModel { get; set; }

        [Required]
        [Range(10, 1000, ErrorMessage = "Unacceptable number places")]
        public int NumberPlaces { get; set; }

        [Required]
        [Range(1000, Int32.MaxValue, ErrorMessage = "Unacceptable carrying capacity")]
        public int CarryingCapacity { get; set; }
    }
}
