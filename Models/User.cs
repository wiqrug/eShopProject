using Azure.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project2.Models
{
    public class User
    {
        [Key]
        
       
        public Guid UserId { get; private set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public Role role { get; set; }
        [JsonIgnore]
        [Required]
        [StringLength(300)]
        public string Password { get; set; }
   
        public User()
        {
            UserId = Guid.NewGuid();
        }



        public enum Role
        {
            Admin,
            Candidate,
            QC,
            Marker
        }


    }
}
