using Microsoft.EntityFrameworkCore;
using Project2.Models;

namespace Project2.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<CandidateExam> CandidateExams { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CandidateCertificates> CandidateCertificates { get; set; }
        public DbSet<Marker> Markers { get; set; }

        public DbSet<QualityControl> QualityControls { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call the base method

            // Configure tables
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Candidate>().ToTable("Candidates");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Exam>().ToTable("Exams");
            modelBuilder.Entity<CandidateExam>().ToTable("CandidateExams");
            modelBuilder.Entity<Certificate>().ToTable("Certificates");
            modelBuilder.Entity<CandidateCertificates>().ToTable("CandidateCertificates");
            modelBuilder.Entity<Marker>().ToTable("Markers");
            modelBuilder.Entity<QualityControl>().ToTable("QualityControls");


        //    Configure the relationship between Exam and Certificate
            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Certificate)
                .WithMany(c => c.Exams)
                .HasForeignKey(e => e.CertificateID)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure other relationships as necessary
            // For example, if you have a relationship between Candidate and CandidateExam
            modelBuilder.Entity<CandidateExam>()
                .HasOne(ce => ce.Candidate)
                .WithMany()
                .HasForeignKey(ce => ce.CandidateID);

            // Similarly, configure relationships for CandidateCertificates
            modelBuilder.Entity<CandidateCertificates>()
                .HasOne(cc => cc.Candidate)
                .WithMany()
                .HasForeignKey(cc => cc.CandidateID);
            modelBuilder.Entity<CandidateCertificates>()
                .HasOne(cc => cc.Certificate)
                .WithMany()
                .HasForeignKey(cc => cc.CertificateID);

            // Add any additional relationship configurations here
        }
    }
}
