using Microsoft.EntityFrameworkCore;


namespace Project2.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CandidateCertificates> CandidateCertificates { get; set; }
    }
}
