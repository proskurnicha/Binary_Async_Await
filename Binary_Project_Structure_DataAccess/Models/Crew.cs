using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Binary_Project_Structure_DataAccess.Models
{
    public class Crew
    {
        [Required]
        [StringLength(3, MinimumLength = 6, ErrorMessage = "Unacceptable id")]
        public int Id { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 6, ErrorMessage = "Unacceptable PilotId id")]
        public int PilotId { get; set; }

        [Required]
        public Pilot Pilot { get; set; }

        [Required]
        public List<Stewardess> Stewardesses { get; set; }
    }
}
