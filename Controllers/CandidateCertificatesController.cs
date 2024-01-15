using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //create candCert
        [Authorize(Roles = "Admin, Candidate")]
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
        //get Obtained(paid) Certif
        [Authorize(Roles = "Admin, Candidate")]
        [HttpGet("obtained/{candidateNumber}")]
        public IActionResult GetObtainedCertificates(int candidateNumber)
        {
            var obtainedCerts = candidateCertificatesServices.GetObtainedCertificates(candidateNumber);
            Console.WriteLine(obtainedCerts);
            return Ok(obtainedCerts);
            
        }
        //get paid Certif but not passed
        [Authorize(Roles = "Admin, Candidate")]
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
        //get all unpaid Cert
        [Authorize(Roles = "Admin, Candidate")]
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
        //get marksPerCertPerExam
        [Authorize(Roles = "Admin, Candidate")]
        [HttpGet("candidate/{candidateNumber}/certificatesExamsHistory")]
        public IActionResult GetMarksPerExamPerCertificate(int? candidateNumber)
        {
            if (candidateNumber == null)
            {
                return BadRequest("Couldn't find candidate without specifics!");
            }
            else 
            {
                var x = candidateCertificatesServices.GetMarksPerExamPerCertificate(candidateNumber);
                    return Ok(x);
            }

            
        }
    }
}
