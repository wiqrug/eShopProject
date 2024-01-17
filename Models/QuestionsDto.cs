using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project2.Models
{
    public class QuestionsDto
    {
        public string Question { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string ImageSrc { get; set; }
        [MaxLength(1)]
        [RegularExpression("(a|b|c|d)", ErrorMessage = "Value must be a,b,c or d")]
        public string CorrectAnswer { get; set; }
        public Guid ExamId { get; set; }
    }
}
