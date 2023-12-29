using static Project2.Models.User;

namespace Project2.Models
{
    public class UserProfileDto
    {
        public string Email { get; set; } 
        public Role role { get; set; }
    }
}
