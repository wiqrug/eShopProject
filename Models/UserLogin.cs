﻿using System.ComponentModel.DataAnnotations;

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

    public class QuestionsUpdateDto
    {
        public string? Question { get; set; }
        public string? AnswerA { get; set; }
        public string? AnswerB { get; set; }
        public string? AnswerC { get; set; }
        public string? AnswerD { get; set; }
        public string? ImageSrc { get; set; }
        [MaxLength(1)]
        [RegularExpression("(a|b|c|d)", ErrorMessage = "Value must be a,b,c or d")]
        public string? CorrectAnswer { get; set; }
        public string? ExamTitle { get; set; }
    }

    public class CandAndCert
    {
        public int CandidateNumber { get; set; }
        public string CertificateTitle { get; set; }
    }
}
