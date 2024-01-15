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
        private const int passingScore = 50;

        public CandidateCertificatesServices(ApplicationDBContext context)
        {
            this.context = context;
        }


        public List<Certificate> GetObtainedCertificates(int candidateNumber)
        {
            
            Candidate candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateNumber);
            if (candidate == null)
            {
                
                return new List<Certificate>();
            }
            List<Certificate> ObtainedCerts = new List<Certificate>();

            
            var boughtCertificates = context.CandidateCertificates
                                            .Where(x => x.CandidateId == candidate.UserId)
                                            .Include(x => x.Certificate)
                                            .ToList();

            foreach (var candidateCertificate in boughtCertificates)
            {
                if (candidateCertificate.Mark >= 50)
                {
                    ObtainedCerts.Add(candidateCertificate.Certificate);
                }
            }
            Console.WriteLine(boughtCertificates);

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
                                           .Where(x => x.CandidateId == candidate.UserId)
                                           .Include(x => x.Certificate)
                                           .ToList();

            foreach (var candidateCertificate in boughtCertificates)
            {
                if (candidateCertificate.Mark < 50)
                {
                    UnobtainedCertificates.Add(candidateCertificate.Certificate);
                }
            }

            return UnobtainedCertificates;
        }


        public bool CreateCandidateCertificate(CandidateCertificatesDTO candidateCertificatesDTO)
        {

            var candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateCertificatesDTO.CandidateNumber);
            var certificate = context.Certificates.FirstOrDefault(x => x.Title == candidateCertificatesDTO.Title);

            var already = context.CandidateCertificates.FirstOrDefault(x => x.CandidateId == candidate.UserId && x.CertificateId == certificate.CertificateId);

            if (candidate == null || certificate == null || already != null)
            {
                return false; 
            }

            CandidateCertificates enrollment = new CandidateCertificates
            {
                Candidate = candidate,
                Certificate = certificate,
                CandidateId = candidate.UserId,
                CertificateId = certificate.CertificateId,
            };

            context.CandidateCertificates.Add(enrollment);
            context.SaveChanges();
            return true;
        }


        public List<Certificate> GetAvailableCertificates(int candidateNumber)
        {
            // Fetching the candidate
            Candidate candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateNumber);
            if (candidate == null)
            {

                return new List<Certificate>();
            }

            var boughtCertificates = context.CandidateCertificates
                                            .Where(x => x.CandidateId == candidate.UserId)
                                            .Include(x => x.Certificate)  // Eagerly load Certificate
                                            .Select(x => x.Certificate)
                                            .ToList();

            var allCertificatesId = context.Certificates
                                   .ToList();
            var availCert = allCertificatesId.Except(boughtCertificates).ToList();
            return availCert;

        }



        public List<Exam> GetMarksPerExamPerCertificate(int? candidateNumber)
        {
            var candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateNumber)!;

            if (candidate == null)
            {
                return new List<Exam>();
            }

            
            var certificates = context.CandidateCertificates
                                    .Where(x => x.CandidateId == candidate.UserId)
                                    .Include(x => x.Certificate)
                                    //.ThenInclude(c => c.Exams)
                                    .Select(x => x.Certificate)
                                    .ToList();



            List<Exam> CertificatesMarks = new List<Exam>();

            foreach (var cert in certificates)
            {
                var examAwardedMarks = context.CandidateExams
                            .Where(x => x.CandidateId == candidate.UserId && x.Exam.CertificateId == cert.CertificateId)
                            .Select(x => x.Exam)
                            .ToList();

                CertificatesMarks = examAwardedMarks;
            }

            return CertificatesMarks;
        }


        


        
       

    }
}