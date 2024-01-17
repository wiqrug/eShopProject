using Microsoft.AspNetCore.Authorization;
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
            try
            {
                return Ok(certificateServices.GetCertificates());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
        
        // Show Certificate with Title
        [HttpGet("{Title}")]   
        public IActionResult GetCertificate(string Title)
        {
            try
            {
                return Ok(certificateServices.GetCertificateByTitle(Title));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        // Create Certificate
        [Authorize(Roles = "Admin")]
        [HttpPost]  
        public IActionResult CreateCertificate(CertificateDTO certificateDTO)
        {
            try
            {
                certificateServices.CreateCertificate(certificateDTO);
                return Ok("Certificate created");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        // Delete Certificate
        [Authorize(Roles = "Admin")]
        [HttpDelete("{Title}")]    
        public IActionResult DeleteCertificate(string Title)
        {
            try
            {
                if (!certificateServices.DeleteCertificate(Title))
                {
                    return NotFound("This certificate does not exist!");
                }

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        // Update Certificate
        [Authorize(Roles = "Admin")]
        [HttpPut("{Title}")]   
        public IActionResult UpdateCertificate(string Title, CertificateDTO certificateDTO)
        {
            try
            {
                certificateServices.UpdateCertificate(Title, certificateDTO);
                return Ok("Certificate updated");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
