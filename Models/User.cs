using Azure.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project2.Models
{
    public class User
    {
        [Key]
        [JsonIgnore]
        public Guid UserID { get; private set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        public Role role { get; set; }
        [Required]
        [StringLength(300)]
        public string Password { get; set; }
        //[Required]
        //[StringLength(30)]
        //public string FirstName { get; set; }
        //[Required]
        //[StringLength(30)]
        //public string LastName { get; set; }
        //public string Address { get; set; }
        
        //public string MobileNumber { get; set; }


        //possibly wrong code
        //public User(Guid userID)
        //{
        //    UserID = Guid.NewGuid();
        //}

        //Maybe this is a better implementation of the constructor, because we dont really need to have arguments in the ctor
        public User()
        {
            UserID = Guid.NewGuid();
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
