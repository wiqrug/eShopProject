using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Services;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateCertificatesController : ControllerBase
    {
        private readonly CandidateCertificatesServices candidateCertificatesServices;

        public CandidateCertificatesController(CandidateCertificatesServices candidateCertificatesServices)
        {
            this.candidateCertificatesServices = candidateCertificatesServices;
        }

        [HttpPost]
        public IActionResult CreateEnrollment(CandidateCertificatesDTO candidateCertificatesDTO)
        {
            bool success = candidateCertificatesServices.CreateCandidateCertificate(candidateCertificatesDTO);

            if (!success)
            {
                return BadRequest("Candidate or Certificate does not exist.");
            }

            return Ok();
        }




        [HttpGet("obtained/{candidateNumber}")]
        public IActionResult GetObtainedCertificates(int candidateNumber)
        {
            if(candidateNumber == null)
            {
                return BadRequest();
            }
            else
            {
                
                var obtainedCerts = candidateCertificatesServices.GetObtainedCertificates(candidateNumber);
                return Ok(obtainedCerts);
            }
        }

        [HttpGet("unobtained/{candidateNumber}")]
        public IActionResult GetUnobtainedCertificates(int candidateNumber)
        {
            if (candidateNumber == null)
            {
                return BadRequest();
            }
            else
            {

                var UnobtainedCertificates = candidateCertificatesServices.GetUnobtainedCertificates(candidateNumber);
                return Ok(UnobtainedCertificates);
            }

        }

        [HttpGet("available/{candidateNumber}")]

        public IActionResult GetAvailableCertificates(int candidateNumber)
        {
            if (candidateNumber == null)
            {
                return BadRequest();
            }
            else
            {
                var availableCertificates = candidateCertificatesServices.GetAvailableCertificates(candidateNumber);
                return Ok(availableCertificates);
            }

        }


        [HttpGet("CertificateCounts")]
        public IActionResult GetCertificateCounts([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var certificateCounts = candidateCertificatesServices.GetCertificateCountsByDateRange(startDate, endDate);
            return Ok(certificateCounts);
        }
    }
}
