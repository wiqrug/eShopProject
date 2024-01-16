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

        //get all
        [Authorize(Roles="Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(candidateCertificatesServices.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        //create candCert
        [Authorize(Roles = "Admin, Candidate")]
        [HttpPost]
        public IActionResult CreateEnrollment(CandidateCertificatesDTO candidateCertificatesDTO)
        {
            try
            {
                bool success = candidateCertificatesServices.CreateCandidateCertificate(candidateCertificatesDTO);

                if (!success)
                {
                    return BadRequest("Candidate or Certificate does not exist.");
                }

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        //get Obtained(paid) Certif
        [Authorize(Roles = "Admin, Candidate")]
        [HttpGet("obtained/{candidateNumber}")]
        public IActionResult GetObtainedCertificates(int candidateNumber)
        {
            try
            {
                var obtainedCerts = candidateCertificatesServices.GetObtainedCertificates(candidateNumber);
                Console.WriteLine(obtainedCerts);
                return Ok(obtainedCerts);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        //get paid Certif but not passed
        [Authorize(Roles = "Admin, Candidate")]
        [HttpGet("unobtained/{candidateNumber}")]
        public IActionResult GetUnobtainedCertificates(int candidateNumber)
        {
            try
            {
                if (candidateNumber == null)
                {
                    return BadRequest("The candidateNumber does not exist!");
                }
                else
                {

                    var UnobtainedCertificates = candidateCertificatesServices.GetUnobtainedCertificates(candidateNumber);
                    return Ok(UnobtainedCertificates);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        //get all unpaid Cert
        [Authorize(Roles = "Admin, Candidate")]
        [HttpGet("available/{candidateNumber}")]
        public IActionResult GetAvailableCertificates(int candidateNumber)
        {
            try
            {
                if (candidateNumber == null)
                {
                    return BadRequest("The candidateNumber does not exist!");
                }
                else
                {
                    var availableCertificates = candidateCertificatesServices.GetAvailableCertificates(candidateNumber);
                    return Ok(availableCertificates);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        //get marksPerCertPerExam
        [Authorize(Roles = "Admin, Candidate")]
        [HttpGet("candidate/{candidateNumber}/certificatesExamsHistory")]
        public IActionResult GetMarksPerExamPerCertificate(int? candidateNumber)
        {
            try
            {
                if (candidateNumber == null)
                {
                    return BadRequest("The candidateNumber does not exist!");
                }
                else
                {
                    var x = candidateCertificatesServices.GetMarksPerExamPerCertificate(candidateNumber);
                    return Ok(x);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
            
        }
        //get all certs with all their cands
        [Authorize(Roles = "Admin")]
        [HttpGet("Certificates/{id}")]
        public IActionResult GetCandidatesByCert(Guid id)
        {
            try
            {
                var certs = candidateCertificatesServices.GetCandidatesByCert(id);
                return Ok(certs);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
