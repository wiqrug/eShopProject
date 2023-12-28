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
                return NotFound("Candidate or Certificate does not exist.");
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
        public IActionResult GetUnoptainedCertificates(int candidateNumber)
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
    }
}
