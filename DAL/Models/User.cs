using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class User
    {
        public User()
        {

        }
        public User(string email, string password, string pseudo, string? lastname, string? firstname, string? phone, string role = "user")
        {
            Email = email;
            Password = password;
            Pseudo = pseudo;
            Lastname = lastname;
            Firstname = firstname;
            Phone = phone;
            Role = role;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=!]).{8,25}$")]
        public string Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string Pseudo { get; set; }

        [MaxLength(100)]
        public string? Lastname { get; set; }

        [MaxLength(100)]
        public string? Firstname { get; set; }
        public string? Phone { get; set; }

        [Required]
        public string Role { get; set; }
    }
}