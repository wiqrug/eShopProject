using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class CertificateDTO
    {

        [Required]
        [StringLength(200)] // Adjust the length based on your requirements
        public string TitleOfCertificate { get; set; }

        [Required]
        [StringLength(50)]
        public string AssessmentTestCode { get; set; }

        [Required]
        public DateTime ExaminationDate { get; set; }

        [Required]
        public DateTime ScoreReportDate { get; set; }

        [Required]
        public int MaximumScore { get; set; }


    }
}
