﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project2.Services;

#nullable disable

namespace Project2.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CandidateCertificates", b =>
                {
                    b.Property<Guid>("RecordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssessmentResultLabel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssessmentTestCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("CandidateID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CandidateScore")
                        .HasColumnType("int");

                    b.Property<Guid>("CertificateID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<float?>("PercentageScore")
                        .HasColumnType("real");

                    b.HasKey("RecordID");

                    b.HasIndex("CandidateID");

                    b.HasIndex("CertificateID");

                    b.ToTable("CandidateCertificates", (string)null);
                });

            modelBuilder.Entity("Certificate", b =>
                {
                    b.Property<Guid>("CertificateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExaminationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaximumScore")
                        .HasColumnType("int");

                    b.Property<int>("Prices")
                        .HasColumnType("int");

                    b.Property<DateTime>("ScoreReportDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TitleOfCertificate")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CertificateID");

                    b.ToTable("Certificates", (string)null);
                });

            modelBuilder.Entity("Project2.Models.CandidateExam", b =>
                {
                    b.Property<Guid>("CandidateExamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CandidateID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExamID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<DateTime>("TakenAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CandidateExamID");

                    b.HasIndex("CandidateID");

                    b.HasIndex("ExamID");

                    b.ToTable("CandidateExams", (string)null);
                });

            modelBuilder.Entity("Project2.Models.Exam", b =>
                {
                    b.Property<Guid>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AwardedMarks")
                        .HasColumnType("int");

                    b.Property<Guid>("CertificateID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExamDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PossibleMarks")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExamId");

                    b.HasIndex("CertificateID");

                    b.ToTable("Exams", (string)null);
                });

            modelBuilder.Entity("Project2.Models.Questions", b =>
                {
                    b.Property<Guid>("questionsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnswerA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("questions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("questionsID");

                    b.HasIndex("ExamId");

                    b.ToTable("Questions", (string)null);
                });

            modelBuilder.Entity("Project2.Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("Users", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Candidate", b =>
                {
                    b.HasBaseType("Project2.Models.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CandidateNumber")
                        .HasColumnType("int");

                    b.Property<string>("CountryOfResidence")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LandlineNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NativeLanguage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("PhotoIDIssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhotoIDNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhotoIDType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("StateOrTerritoryOrProvince")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TownOrCity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.ToTable("Candidates", (string)null);
                });

            modelBuilder.Entity("Project2.Models.Admin", b =>
                {
                    b.HasBaseType("Project2.Models.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("Project2.Models.Marker", b =>
                {
                    b.HasBaseType("Project2.Models.User");

                    b.ToTable("Markers", (string)null);
                });

            modelBuilder.Entity("Project2.Models.QualityControl", b =>
                {
                    b.HasBaseType("Project2.Models.User");

                    b.ToTable("QualityControls", (string)null);
                });

            modelBuilder.Entity("CandidateCertificates", b =>
                {
                    b.HasOne("Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Certificate", "Certificate")
                        .WithMany()
                        .HasForeignKey("CertificateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Certificate");
                });

            modelBuilder.Entity("Project2.Models.CandidateExam", b =>
                {
                    b.HasOne("Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project2.Models.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("Project2.Models.Exam", b =>
                {
                    b.HasOne("Certificate", "Certificate")
                        .WithMany("Exams")
                        .HasForeignKey("CertificateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Certificate");
                });

            modelBuilder.Entity("Project2.Models.Questions", b =>
                {
                    b.HasOne("Project2.Models.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("Candidate", b =>
                {
                    b.HasOne("Project2.Models.User", null)
                        .WithOne()
                        .HasForeignKey("Candidate", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project2.Models.Admin", b =>
                {
                    b.HasOne("Project2.Models.User", null)
                        .WithOne()
                        .HasForeignKey("Project2.Models.Admin", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project2.Models.Marker", b =>
                {
                    b.HasOne("Project2.Models.User", null)
                        .WithOne()
                        .HasForeignKey("Project2.Models.Marker", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project2.Models.QualityControl", b =>
                {
                    b.HasOne("Project2.Models.User", null)
                        .WithOne()
                        .HasForeignKey("Project2.Models.QualityControl", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Certificate", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("Project2.Models.Exam", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
