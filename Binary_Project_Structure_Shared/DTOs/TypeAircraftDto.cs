using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_Shared.DTOs
{
    public class TypeAircraftDto
    {
        public int Id { get; set; }

        public AircraftModelDto AircraftModel { get; set; }

        public int NumberPlaces { get; set; }

        public int CarryingCapacity { get; set; }
    }
}
