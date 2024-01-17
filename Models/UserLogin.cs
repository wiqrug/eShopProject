namespace Project2.Models
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class CurrentUser
    {
        public string firstName { get; set; }
        public string token { get; set; }
        public int candidatenumber { get; set; }
        
    }

    public class CandidateInfo
    {
        public Candidate candidate { get; set; }
        public int? mark { get; set; }
        public Guid RecordId { get; set; }
    }

    public class ExamUpdateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Time { get; set; }
        public string? CertificateTitle { get; set; }
    }
}
