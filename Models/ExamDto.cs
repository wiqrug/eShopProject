using System;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class ExamDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Time { get; set; }
        public string CertificateTitle { get; set; }
    }
}