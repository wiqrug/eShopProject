//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using static Project2.Models.User;

//namespace Project2.Models
//{
//    public class Admin : User
//    {
//        [Key]
//        public Guid AdminID { get; set; }
//        public string FirstName { get; set;}
//        public string LastName { get; set;}
//        public string Email { get; set;}
//        public string Address { get; set; }
//        public string MobileNumber { get; set; }
//        [ForeignKey("User")]
//        public Guid UserID { get; set; }

//        public Admin()
//        {
//            // Initialize the CandidateID with a new GUID
//            AdminID = Guid.NewGuid();
//            base.role = Role.Admin;
//        }

//    }
//}
