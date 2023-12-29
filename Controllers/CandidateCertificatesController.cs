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



        [HttpGet("CertificateCounts")]
        public IActionResult GetCertificateCounts([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var certificateCounts = candidateCertificatesServices.GetCertificateCountsByDateRange(startDate, endDate);
            return Ok(certificateCounts);
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

        [HttpGet("ByDate/{candidateNumber}")]
        public IActionResult GetObtainedCertificatesByDate(int candidateNumber, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            if (candidateNumber == null)
            {
                return BadRequest();
            }
            else
            {
                var obtainedCertsByDate = candidateCertificatesServices.GetObtainedCertificatesByDate(candidateNumber, startDate, endDate);
                return Ok(obtainedCertsByDate);
            }
        }

        [HttpGet("api/Candidate/{candidateNumber}/CertificatesExamsHistory")]
        public IActionResult GetMarksPerExamPerCertificate(int? candidateNumber)
        {
            if (candidateNumber == null)
            {
                return BadRequest("Couldn't find candidate without specifics!");
            }

            // Searching if the candidate exists
            var candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateNumber)!;

            if (context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateNumber) == null)
            {
                return NotFound("Candidate not found!");
            }

            // Searching for certificates of this candidtate
            var certificates = context.CandidateCertificates
                                    .Where(x => x.CandidateID == candidate.UserID)
                                    .Include(x => x.Certificate)  // Eagerly load Certificate
                                                                  //.ThenInclude(c => c.Exams)    // Eagerly load Exams related to Certificate
                                    .Select(x => x.Certificate)
                                    .ToList();


            var CertificatesMarks = new Dictionary<string, List<Exam>>();

            foreach (var cert in certificates)
            {
                var examAwardedMarks = context.CandidateExams
                            .Where(x => x.CandidateID == candidate.UserID)
                            .Select(x => x.Exam)
                            .ToList();

                CertificatesMarks[cert.TitleOfCertificate] = examAwardedMarks;
            }

            return Ok(CertificatesMarks);
        }
    }
}
