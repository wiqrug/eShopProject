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
        private const int passingScore = 50; // Define your passing score

        public CandidateCertificatesServices(ApplicationDBContext context)
        {
            this.context = context;
        }


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

        //We need to have a date that is initialized when the exam is passed
        public CertificateCountResult GetCertificateCountsByDateRange(DateTime startDate, DateTime endDate)
        {
            var result = new CertificateCountResult();

            var certificatesInRange = context.CandidateCertificates
                                             .Where(cc => cc.CreatedAt >= startDate && cc.CreatedAt <= endDate)
                                             .ToList();

            foreach (var certificate in certificatesInRange)
            {
                if (certificate.CandidateScore.HasValue && certificate.CandidateScore.Value >= passingScore)
                {
                    result.PassedCount++;
                }
                else
                {
                    result.FailedCount++;
                }
            }

            return result;
        }
    }
}