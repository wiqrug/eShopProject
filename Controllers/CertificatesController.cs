//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//using Project2.Services;

//namespace Project2.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CertificatesController : ControllerBase
//    {
//        private readonly ApplicationDBContext context;

//        public CertificatesController(ApplicationDBContext context)
//        {
//            this.context = context;
//        }

//        [HttpGet]   // Show List of Certificates
//        public IActionResult GetCertificates()
//        {
//            var certificates = context.Certificates.ToList();

//            return Ok(certificates);
//        }

//        // Prepei na kanoume print ta certificates vasismena stin ID
//        //[HttpGet("{id}")]   // Show Certificate
//        //public IActionResult GetCertificate(int id)
//        //{
//        //    var certificate = context.Certificates.Find(id);

//        //    if (certificate == null)
//        //    {
//        //        return NotFound();
//        //    }
//        //    return Ok(certificate);
//        //}

//        [HttpPost]  // Create Certificate
//        public IActionResult CreateCertificate(CertificateDTO certificateDTO)
//        {
//            Certificate certificate = new Certificate()
//            {
//                CertificateTitle = certificateDTO.CertificateTitle,
//                CandidateFullName = certificateDTO.CandidateFullName,
//                AssessmentTestCode = certificateDTO.AssessmentTestCode,
//                ExaminationDateTime = certificateDTO.ExaminationDateTime,
//                ScoreReportDate = certificateDTO.ScoreReportDate,
//                //-------------------------------------------------------------
//                CandidateScore = certificateDTO.CandidateScore,
//                MaximumScore = certificateDTO.MaximumScore,
//                PercentageScore = certificateDTO.PercentageScore,
//                AssessmentResultLabel = certificateDTO.AssessmentResultLabel,
//                //-------------------------------------------------------------
//                Description = certificateDTO.Description
//            };

//            context.Certificates.Add(certificate);
//            context.SaveChanges();

//            return Ok(certificate);
//        }

//        [HttpDelete("{id}")]    // Delete Certificate
//        public IActionResult DeleteContact(int id)
//        {
//            var certificate = context.Certificates.Find(id);

//            if (certificate == null)
//            {
//                return NotFound();
//            }

//            context.Certificates.Remove(certificate);
//            context.SaveChanges();

//            return Ok(certificate);
//        }

//        [HttpPut("{id}")]   // Update Certificate
//        public IActionResult UpdateCertificate(int id, CertificateDTO certificateDTO)
//        {
//            var certificate = context.Certificates.Find(id);

//            if (certificate == null)
//            {
//                return NotFound();
//            }

//            certificate.CertificateTitle = certificateDTO.CertificateTitle;
//            certificate.CandidateFullName = certificateDTO.CandidateFullName;
//            certificate.AssessmentTestCode = certificateDTO.AssessmentTestCode;
//            certificate.ExaminationDateTime = certificateDTO.ExaminationDateTime;
//            certificate.ScoreReportDate = certificateDTO.ScoreReportDate;
//            //---------------------------------------------------------------------------
//            certificate.CandidateScore = certificateDTO.CandidateScore;
//            certificate.MaximumScore = certificateDTO.MaximumScore;
//            certificate.PercentageScore = certificateDTO.PercentageScore;
//            certificate.AssessmentResultLabel = certificateDTO.AssessmentResultLabel;
//            //---------------------------------------------------------------------------
//            certificate.Description = certificateDTO.Description;

//            context.SaveChanges();

//            return Ok(certificate);
//        }
//    }
//}
