using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class CandidateCertificatesDTO
    {
        public int CandidateNumber { get; set; }
        public string Title { get; set; }

        public int Mark {  get; set; }
    }
}
