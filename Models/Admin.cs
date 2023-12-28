using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Project2.Models.User;

namespace Project2.Models
{
    public class Admin : User
    {
      
        //These properties could be inherited by user, since Admin,Marker and QualityControl,Candidate already have this
        //Reduces Redundancy
        //Enopoihsh me User etsi k allios?
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }



        public Admin():base()
        {
  
        }

    }
}
