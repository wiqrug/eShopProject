using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public class Exam
    {
        [Required]
        [Key]
        public Guid ExamId { get; set; }
        public string ExamDescription { get; set; }
        public int? AwardedMarks { get; set; }
        public int PossibleMarks { get; set; }

        //public Certificate Certificate { get; set; }


        [Required]
        [ForeignKey("Certificate")]
        public Guid CertificateID { get; set; }


        public  Certificate Certificate { get; set; }

        public Exam()
        {
            CertificateID = new Guid();
        }


    }
}