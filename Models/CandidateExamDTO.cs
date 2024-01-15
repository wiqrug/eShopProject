using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class CandidateExamDTO
    {
        
           
        
        public Guid CandidateId { get; set; }
                      
        public Guid ExamId { get; set; }

        public int ExamMark { get; set; }





    }
}
