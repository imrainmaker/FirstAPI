﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO
{
    public class UserAddDTO
    {
        public UserAddDTO(string email, string password, string pseudo, string checkPassword)
        {
            Email = email;
            Password = password;
            Pseudo = pseudo;
            CheckPassword = checkPassword;
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Pseudo { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=!]).{8,25}$")]
        public string Password { get; set; }

        [Compare("Password")]
        public string CheckPassword { get; set; }

    }
}
