using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_DataAccess.Models
{
    public class Aircraft
    {
        [Required]
        [Range(1, 999, ErrorMessage = "Unacceptable id")]
        public int Id { get; set; }

        [Required]
        public string AircraftName { get; set; }

        [Required]
        [Range(1, 999, ErrorMessage = "Unacceptable TypeAircraft id")]
        public int TypeAircraftId { get; set; }

        public TypeAircraft TypeAircraft { get; set; }

        public DateTime DateRelease { get; set; }

        public TimeSpan Lifetime { get; set; }
    }
}
