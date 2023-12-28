namespace Project2.Models
{
    public class QualityControl : User
    {
        //QualityControl is the same as admin (as a model) but he has access only to get methods 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
    }
}
