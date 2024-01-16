namespace Project2.Models
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class CurrentUser
    {
        public string email { get; set; }
        public string token { get; set; }
        public int candidatenumber { get; set; }
        
    }


}
