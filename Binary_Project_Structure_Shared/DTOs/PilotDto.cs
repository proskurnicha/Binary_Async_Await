using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_Shared.DTOs
{
    public class PilotDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateBirth { get; set; }

        public int Experience { get; set; }
    }
}
