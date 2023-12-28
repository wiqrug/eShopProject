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
            candidateCertificatesServices.CreateCandidateCertificate(candidateCertificatesDTO);
            return Ok();
        }




        [HttpGet("{candidateNumber}")]
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
    }
}
