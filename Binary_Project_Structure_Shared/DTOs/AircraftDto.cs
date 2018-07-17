using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_Shared.DTOs
{
    public class AircraftDto
    {
        [Range(1, 999, ErrorMessage = "Unacceptable id")]
        public int Id { get; set; }

        [Required]
        public string AircraftName { get; set; }

        [Required]
        [Range(1, 999, ErrorMessage = "Unacceptable id")]
        public int TypeAircraftId { get; set; }
        
        public DateTime DateRelease { get; set; }

        public TimeSpan Lifetime { get; set; }
    }

}
