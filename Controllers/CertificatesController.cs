using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Services;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly CertificateServices certificateServices;

        public CertificatesController(CertificateServices certificateServices)
        {
            this.certificateServices = certificateServices;
        }
        
        // Show List of Certificates
        [HttpGet]   
        public IActionResult GetCertificates()
        {
            return Ok(certificateServices.GetCertificates());
        }
        
        // Show Certificate
        [HttpGet("{Title}")]   
        public IActionResult GetCertificate(string Title)
        {
           return Ok(certificateServices.GetCertificateByTitle(Title));
        }

        // Create Certificate
        [ServiceFilter(typeof(AuthenticationFilterAdmin))]
        [HttpPost]  
        public IActionResult CreateCertificate(CertificateDTO certificateDTO)
        {
            certificateServices.CreateCertificate(certificateDTO);
            return Ok();
        }

        // Delete Certificate
        [ServiceFilter(typeof(AuthenticationFilterAdmin))]
        [HttpDelete("{Title}")]    
        public IActionResult DeleteCertificate(string Title)
        {
            if (!certificateServices.DeleteCertificate(Title))
            {
                return NotFound("This certificate does not exist!");
            }

            return Ok();
        }

        // Update Certificate
        [ServiceFilter(typeof(AuthenticationFilterAdmin))]
        [HttpPut("{Title}")]   
        public IActionResult UpdateCertificate(string Title, CertificateDTO certificateDTO)
        {
            certificateServices.UpdateCertificate(Title, certificateDTO);
            return Ok();
        }
    }
}
