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

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Exam> Exams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Candidate>().ToTable("Candidates");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Exam>().ToTable("Exams");

            modelBuilder.Entity<Exam>()
              .HasOne(e => e.Certificate)
               .WithMany(c => c.Exams)
               .HasForeignKey(e => e.CertificateID);
        }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CandidateCertificates> CandidateCertificates { get; set; }
    }
}
