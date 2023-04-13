using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.ViewModels
{
    public class UserProfilViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Pseudo { get; set; }

        public string? Lastname { get; set; }

        public string? Firstname { get; set; }
    }
}
