using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public class CertificateDTO
    {

  
        [StringLength(200)] 
        public string Title { get; set; }

        [StringLength(150)]
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImageSrc { get; set; }


    }
}
