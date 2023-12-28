using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using System.Runtime.ConstrainedExecution;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project2.Services
{
    public class CandidateCertificatesServices
    {
        private readonly ApplicationDBContext context;

        public CandidateCertificatesServices(ApplicationDBContext context)
        {
            this.context = context;
        }

        /*        public List<Certificate> GetObtainedCertificates(int candidateNumber)
                {
                    Candidate candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateNumber);
                    Dictionary<Certificate, int> ExamsPassed = new Dictionary<Certificate, int>();
                    List<Certificate> ObtainedCerts = new List<Certificate>();


                    var boughtCertificates = context.CandidateCertificates.Where(x => x.CandidateID == candidate.UserID).Select(x => x.Certificate);
                    //var boughtCertificates = from candcert in context.CandidateCertificates where candcert.CandidateID == candidate.UserID select candcert.Certificate;
                    List<Certificate> boughtCertificatesList = boughtCertificates.ToList();


                    for (int i = 0; i < boughtCertificatesList.Count(); i++)
                    {
                        for (int j = 0; j < boughtCertificatesList[i].Exams.Count; j++)
                        {
                            if (boughtCertificatesList[i].Exams[j].AwardedMarks > 50)
                            {
                                ExamsPassed[boughtCertificatesList[i]]++;
                                if (ExamsPassed[boughtCertificatesList[i]] == boughtCertificatesList[i].Exams.Count)
                                {
                                    ObtainedCerts.Add(boughtCertificatesList[i]);
                                }
                            }
                        }

                    }
                    return ObtainedCerts;
                }
        */

        public List<Certificate> GetObtainedCertificates(int candidateNumber)
        {
            // Fetching the candidate
            Candidate candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateNumber);
            if (candidate == null)
            {
                // If the candidate is not found, return an empty list
                return new List<Certificate>();
            }

            Dictionary<Certificate, int> ExamsPassed = new Dictionary<Certificate, int>();
            List<Certificate> ObtainedCerts = new List<Certificate>();

            // Modify the query to use eager loading correctly
            var boughtCertificates = context.CandidateCertificates
                                            .Where(x => x.CandidateID == candidate.UserID)
                                            .Include(x => x.Certificate)  // Eagerly load Certificate
                                            .ThenInclude(c => c.Exams)    // Eagerly load Exams related to Certificate
                                            .Select(x => x.Certificate)
                                            .ToList();

            foreach (var certificate in boughtCertificates)
            {
                int passedExamsCount = 0;

                foreach (var exam in certificate.Exams)
                {
                    if (exam.AwardedMarks > 50)
                    {
                        passedExamsCount++;
                    }
                }

                if (passedExamsCount == certificate.Exams.Count)
                {
                    ObtainedCerts.Add(certificate);
                }
            }

            return ObtainedCerts;
        }

        public List<Certificate> GetUnobtainedCertificates(int candidateNumber)
        {

            Candidate candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateNumber);
            if (candidate == null)
            {

                return new List<Certificate>();
            }


            List<Certificate> UnobtainedCertificates = new List<Certificate>();

            var boughtCertificates = context.CandidateCertificates
                                            .Where(x => x.CandidateID == candidate.UserID)
                                            .Include(x => x.Certificate)  // Eagerly load Certificate
                                            .ThenInclude(c => c.Exams)    // Eagerly load Exams related to Certificate
                                            .Select(x => x.Certificate)
                                            .ToList();

            foreach (var certificate in boughtCertificates)
            {
                foreach (var exam in certificate.Exams)
                {
                    if (exam.AwardedMarks < 50)
                    {
                        UnobtainedCertificates.Add(certificate);

                    }
                }
            }
            return UnobtainedCertificates;
        }

        public bool CreateCandidateCertificate(CandidateCertificatesDTO candidateCertificatesDTO)
        {
            var candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateCertificatesDTO.CandidateNumber);
            var certificate = context.Certificates.FirstOrDefault(x => x.TitleOfCertificate == candidateCertificatesDTO.TitleOfCertificate);

            if (candidate == null || certificate == null)
            {
                return false; // Or throw an exception
            }

            CandidateCertificates enrollment = new CandidateCertificates
            {
                Candidate = candidate,
                Certificate = certificate,
                CandidateID = candidate.UserID,
                CertificateID = certificate.CertificateID,
                CandidateScore = null,
                PercentageScore = null,
                AssessmentTestCode = "",
                AssessmentResultLabel = ""
            };

            context.CandidateCertificates.Add(enrollment);
            context.SaveChanges();
            return true;
        }
    }
}


/*foreach (var exam in cert.Exams)
{
    if (exam.AwardedMarks > 50) //lathos. theloume na exei perasei OLA ta exams, oxi mono ena gia na mas kanei .Add(cert)
    {
        certs.Add(cert);
    }
}*/