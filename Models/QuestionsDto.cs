using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project2.Models
{
    public class QuestionsDto
    {

        [Key]
        [JsonIgnore]
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
        [RegularExpression("(a|b|c|d)", ErrorMessage = "Value must be a,b,c or d")]
        public string CorrectAnswer { get; set; }



        public QuestionsDto()
        {
            QuestionId = Guid.NewGuid();
        }


    }
}
