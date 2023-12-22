using Project2.Models;

namespace Project2.Services
{
    public class CertificateServices
    {
        private readonly ApplicationDBContext context;

        public CertificateServices(ApplicationDBContext context)
        {
            this.context = context;
        }

        public List<Certificate> GetCertificates()
        {
            var certificates = context.Certificates.ToList();
            return certificates;
        }

        public Certificate GetCertificateByTitle(string TitleOfCertificate)
        {
            var certificate = context.Certificates.FirstOrDefault(x => x.TitleOfCertificate == TitleOfCertificate);
            return certificate;
        }

        public void CreateCertificate(CertificateDTO certificateDTO)
        {
            var certificate = new Certificate
            {
                // Assuming CertificateID is set elsewhere or automatically

                // Direct mapping from DTO to Certificate properties
                TitleOfCertificate = certificateDTO.TitleOfCertificate,
                AssessmentTestCode = certificateDTO.AssessmentTestCode,
                ExaminationDate = certificateDTO.ExaminationDate,
                ScoreReportDate = certificateDTO.ScoreReportDate,
                MaximumScore = certificateDTO.MaximumScore
            };

            context.Certificates.Add(certificate);
            context.SaveChanges();
        }

        public void UpdateCertificate(string TitleOfCertificate, CertificateDTO certificateDTO)
        {
            //if candidateNumber exists in Candidates.candidate Number, then assign it to var candidate
            //var candidate = context.Candidates.FirstOrDefault(candidateNumber);

            var certificate = context.Certificates.FirstOrDefault(x => x.TitleOfCertificate == TitleOfCertificate);

            //If null should return error 
            //Protash: na ginei IActionResult to function kai na gurnaei katey8eian notfound klp
            //kai ston controller 8a grafoume
            //return certificateServices.UpdateCertificate(TitleOfCertificate, certificateDTO);
            //if (certificate == null)
            //{
                //NotFound("There is no certificate with that title");
            //}

            // Update candidate properties with values from candidateDTO
            certificate.TitleOfCertificate = certificateDTO.TitleOfCertificate;
            certificate.AssessmentTestCode = certificateDTO.AssessmentTestCode;
            certificate.ExaminationDate = certificateDTO.ExaminationDate;
            certificate.ScoreReportDate = certificateDTO.ScoreReportDate;
            certificate.MaximumScore = certificateDTO.MaximumScore;

            context.SaveChanges();

        }

        public bool DeleteCertificate(string TitleOfCertificate)
        {
            var certificate = context.Certificates.FirstOrDefault(x => x.TitleOfCertificate == TitleOfCertificate);

            if (certificate == null)
            {
                return false;
            }

            context.Certificates.Remove(certificate);
            context.SaveChanges();

            return true;
        }
    }
}
