using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.ViewModels
{
    public class UserViewModel
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string Pseudo { get; set; }

        public string? Lastname { get; set; }

        public string? Firstname { get; set; }

        public string? Phone { get; set; }

        public string Role { get; set; }
    }
}
