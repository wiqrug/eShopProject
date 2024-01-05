using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public class Questions
    {


      public  string questions {  get; set; } 
       public string AnswerA {  get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }
        [Required]
        [ForeignKey("Exam")]
        public Guid ExamID { get; set; }

        public Exam Exam { get; set; }  

            
    }
}
