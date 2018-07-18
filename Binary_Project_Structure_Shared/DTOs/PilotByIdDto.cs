using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Project_Structure_Shared.DTOs
{
    public class PilotByIdDto
    {
        public int Id { get; set; }

        public int CrewId { get; set; }

        public DateTime BirthDate { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Exp { get; set; }
    }
}
