using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Project2.Models.User;

namespace Project2.Models
{
    public class Admin : User
    {

        

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        public string Address { get; set; }

        public string MobileNumber { get; set; }


        public Admin():base()
        {
  
        }

    }
}
