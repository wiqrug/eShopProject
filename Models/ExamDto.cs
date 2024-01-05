using System;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class ExamDto
    {
        public string ExamDescription { get; set; }
        public int? AwardedMarks { get; set; }
        public int PossibleMarks { get; set; }
        public Guid CertificateID { get; set; } // Assuming this is needed to link Exam to Certificate
        [Required]
        public string Title { get; set; }
        public int Time { get; set; }
        
    }
}