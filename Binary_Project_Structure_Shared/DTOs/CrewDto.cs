using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_Shared.DTOs
{
    public class CrewDto
    {
        public int Id { get; set; }
        
        public int PilotId { get; set; }

        public List<StewardessDto> Stewardesses { get; set; }
    }
}
