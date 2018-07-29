using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_DataAccess.Models
{
    public class TypeAircraft
    {
        public int Id { get; set; }

        [Required]
        public AircraftModel AircraftModel { get; set; }

        [Required]
        public int NumberPlaces { get; set; }

        [Required]
        public int CarryingCapacity { get; set; }
    }
}
