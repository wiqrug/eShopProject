using Azure.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project2.Models
{
    public class User
    {
        [Key]
        [JsonIgnore]
        //We have setter because the framework needs it
        //TODO: Merge common properties of Admin and Candidate
        public Guid UserId { get; private set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public Role role { get; set; }
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
