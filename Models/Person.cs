using Azure.Identity;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class Person
    {
        
        public enum Role
        {
            Admin,
            Candidate,
            QC,
            Marker
        }
        public Guid PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role role { get; set; }
    }
}
