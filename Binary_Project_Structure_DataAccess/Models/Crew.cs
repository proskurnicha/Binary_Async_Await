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
        public int Id { get; set; }

        [Required]
        public int PilotId { get; set; }

        [Required]
        public Pilot Pilot { get; set; }

        public List<Stewardess> Stewardesses { get; set; }


    }
}
