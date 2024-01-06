using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Project2.Models
{
    public class Exam
    {
        
        [Key]
        public Guid ExamId { get; set; }

        [Required]
        [ForeignKey("Certificate")]
        public Guid CertificateId { get; set; }

        [Required]
        [StringLength(50)]
        [DistinctValues(ErrorMessage = "Values must be distinct")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Time {  get; set; }  



        //Navigation properties
        public ICollection<Questions> Questions { get; set; }

        public  Certificate Certificate { get; set; }

        //Constructor
        //Delete this later
        //Added CertificateID = certificateId and also argument in the constructor
        public Exam(Guid certificateId)
        {
            ExamId = Guid.NewGuid();
            CertificateId = certificateId;
        }

        //Added empty constructor
        public Exam() {
            ExamId = Guid.NewGuid();
        }

    }
}