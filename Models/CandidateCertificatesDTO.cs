using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class CandidateCertificatesDTO
    {

        [Required]
        public int CandidateNumber { get; set; }
        [Required]
        public string TitleOfCertificate { get; set; }


    }
}
