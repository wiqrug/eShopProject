using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class CandidateExam
    {
        [Key]
        public Guid CandidateExamId { get; set; }

        [Required]
        [ForeignKey("Candidate")]
        public Guid CandidateId { get; set; }

        [Required]
        [ForeignKey("Exam")]
        public Guid ExamId { get; set; }

        private int _examMark;
        public int ExamMark
        {
            get
            {
                return this._examMark;
            }
            set
            {
                this._examMark = value;
                TakenAt = DateTime.Now;
            }
        }
        
        public DateTime TakenAt { get; set; }
       
        public Candidate Candidate { get; set; }
        public Exam Exam { get; set; }

        public CandidateExam()
        {
            CandidateExamId = Guid.NewGuid();
        }
    }
}
