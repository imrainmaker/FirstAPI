using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO
{
    public class UserProfilDTO
    {
        [Required]
        [MaxLength(100)]
        public string Pseudo { get; set; }

        [MaxLength(100)]
        public string? Lastname { get; set; }

        [MaxLength(100)]
        public string? Firstname { get; set; }
    }
}
