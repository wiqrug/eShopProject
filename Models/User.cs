using Azure.Identity;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class User
    {
        public User(string username, string password, Guid userID)
        {
            UserID = Guid.NewGuid();  //Isos na min xreiazetai
            Username = username;
            Password = password;
        }

        public enum Role
        {
            Admin,
            Candidate,
            QC,
            Marker
        }
        [Key]
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role role { get; set; }
    }
}
