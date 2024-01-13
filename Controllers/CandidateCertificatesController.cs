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
        private readonly ApplicationDBContext context;

        public CandidateCertificatesController(CandidateCertificatesServices candidateCertificatesServices,ApplicationDBContext context)
        {
            this.candidateCertificatesServices = candidateCertificatesServices;
            this.context = context;
        }

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

        [Authorize(Roles = "Admin, Candidate")]
        [HttpGet("obtained/{candidateNumber}")]
        public IActionResult GetObtainedCertificates(int candidateNumber)
        {
            var obtainedCerts = candidateCertificatesServices.GetObtainedCertificates(candidateNumber);
            Console.WriteLine(obtainedCerts);
            return Ok(obtainedCerts);
            
        }

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

        [Authorize(Roles = "Admin, Candidate")]
        [HttpGet("api/candidate/{candidateNumber}/certificatesExamsHistory")]
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

            //var candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateNumber)!;

            //if (context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateNumber) == null)
            //{
            //    return NotFound("Candidate not found!");
            //}

            //// Searching for certificates of this candidtate
            //var certificates = context.CandidateCertificates
            //                        .Where(x => x.CandidateID == candidate.UserID)
            //                        .Include(x => x.Certificate)  // Eagerly load Certificate
            //                                                      //.ThenInclude(c => c.Exams)    // Eagerly load Exams related to Certificate
            //                        .Select(x => x.Certificate)
            //                        .ToList();


            //var CertificatesMarks = new Dictionary<string, List<Exam>>();

            //foreach (var cert in certificates)
            //{
            //    var examAwardedMarks = context.CandidateExams
            //                .Where(x => x.CandidateID == candidate.UserID)
            //                .Select(x => x.Exam)
            //                .ToList();

            //    CertificatesMarks[cert.TitleOfCertificate] = examAwardedMarks;
            //}

            //return Ok(CertificatesMarks);

            //Needs fix (same does service)

            //[HttpGet("ByDate/{candidate-number}")]
            //public IActionResult GetObtainedCertificatesByDate(int candidateNumber, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
            //{
            //    if (candidateNumber == null)
            //    {
            //        return BadRequest();
            //    }
            //    else
            //    {
            //        var obtainedCertsByDate = candidateCertificatesServices.GetObtainedCertificatesByDate(candidateNumber, startDate, endDate);
            //        return Ok(obtainedCertsByDate);
            //    }
            //}
        }
    }
}
