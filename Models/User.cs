using Azure.Identity;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        public Role role { get; set; }
        public string Password { get; set; } 
        public User(Guid userID)
        {
            UserID = Guid.NewGuid();  

        }
        public User() { }


        public enum Role
        {
            Admin,
            Candidate,
            QC,
            Marker
        }


    }
}
