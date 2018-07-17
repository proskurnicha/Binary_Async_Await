using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_DataAccess.Models
{
    public class Stewardess
    {
        [Required]
        [StringLength(3, MinimumLength = 6, ErrorMessage = "Unacceptable id")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime DateBirth { get; set; }
    }
}
