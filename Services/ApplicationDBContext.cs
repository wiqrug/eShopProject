using Microsoft.EntityFrameworkCore;
using Project2.Models;


namespace Project2.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        //public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Candidate>().ToTable("Candidates");
        }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CandidateCertificates> CandidateCertificates { get; set; }
    }
}
