using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Project2.Models.User;

namespace Project2.Models
{
    public class UserDto
    {

       

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        public Role role { get; set; }
        public string Password { get; set; }


       





    }
}
