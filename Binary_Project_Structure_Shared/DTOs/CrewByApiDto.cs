using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Project_Structure_Shared.DTOs
{
    public class CrewByApiDto
    {
        public int Id;
        public List<PilotByIdDto> Pilot;
        public List<StewardessByApiDto> Stewardess { get; set; }
    }
}
