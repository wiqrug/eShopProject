using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public class Questions
    {

        [Key]
        public Guid QuestionId { get; set; }

        [Required]
        [ForeignKey("Exam")]
        public Guid ExamId { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string AnswerA { get; set; }
        [Required]
        public string AnswerB { get; set; }
        [Required]
        public string AnswerC { get; set; }
        [Required]
        public string AnswerD { get; set; }

        [Required]
        public string ImageSrc { get; set; }

        [Required]
        [RegularExpression("(a|b|c|d)", ErrorMessage = "Value must be a,b,c or d")]
        public string CorrectAnswer { get; set; }
   

        //Navigation property
        public Exam Exam { get; set; }

        public Questions()
        {
            QuestionId = Guid.NewGuid();
        }

        public Questions(Guid examid)
        {
            QuestionId = Guid.NewGuid();
            ExamId = examid;
        }


    }
}
