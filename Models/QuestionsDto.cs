using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project2.Models
{
    public class QuestionsDto
    {
        public Guid ExamId { get; set; }
        public string Question { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string ImageSrc { get; set; }
        public string CorrectAnswer { get; set; }

    }
}
