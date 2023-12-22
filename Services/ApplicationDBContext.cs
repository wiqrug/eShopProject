using Microsoft.EntityFrameworkCore;
using Project2.Models;

namespace Project2.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CandidateCertificates> CandidateCertificates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table configurations
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Candidate>().ToTable("Candidates");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Certificate>().ToTable("Certificates");
            modelBuilder.Entity<CandidateCertificates>().ToTable("CandidateCertificates");

            modelBuilder.Entity<Candidate>()
                 .HasIndex(c => c.CandidateNumber)
                 .IsUnique(); // Ensures CandidateNumber is unique within Candidate

            // Configure the relationship
            modelBuilder.Entity<CandidateCertificates>()
                .HasOne<Candidate>(cc => cc.Candidate) // Specifies that CandidateCertificates is related to Candidate
                .WithMany() // You can specify a collection property in Candidate if you have one
                .HasForeignKey(cc => cc.CandidateNumber) // Use CandidateNumber as the foreign key
                .IsRequired();
        }
    }
}
