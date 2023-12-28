using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class CandidateExam
    {
        [Key]
        public Guid CandidateExamID { get; set; }

        [ForeignKey("Candidate")]
        public Guid CandidateID { get; set; }

        [ForeignKey("Exam")]
        public Guid ExamID { get; set; }

        public int Mark { get;set; }

        public DateTime TakenAt { get; set; }

        public Candidate Candidate { get; set; }
        public Exam Exam { get; set; }

        public CandidateExam()
        {
            CandidateExamID = Guid.NewGuid();
            TakenAt = DateTime.Now;
        }
    }
}
