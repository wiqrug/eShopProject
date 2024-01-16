using Microsoft.EntityFrameworkCore;
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

        public Certificate GetCertificateByTitle(string Title)
        {
            var certificate = context.Certificates.FirstOrDefault(x => x.Title == Title);
            return certificate;
        }

        public Certificate GetCandidatesByCertificate(string Title)
        {
            var cert = context.Certificates.Where(x => x.Title == Title).Include(c => c.CandidateCertificates).SingleOrDefault();
            
            return cert;
        }

        public void CreateCertificate(CertificateDTO certificateDTO)
        {
            var certificate = new Certificate
            {
                
                Title = certificateDTO.Title,
                Description = certificateDTO.Description,
                Price = certificateDTO.Price,
                ImageSrc = certificateDTO.ImageSrc
            };

            context.Certificates.Add(certificate);
            context.SaveChanges();
        }

        public void UpdateCertificate(string Title, CertificateDTO certificateDTO)
        {
            var certificate = context.Certificates.FirstOrDefault(x => x.Title == Title);

            if (certificateDTO.Title != null && certificateDTO.Title.Trim() != "")
            {
                certificate.Title = certificateDTO.Title;
            }

            if (certificateDTO.Description != null && certificateDTO.Description.Trim() != "")
            {
                certificate.Description = certificateDTO.Description;
            }

            if (certificateDTO.Price != null)
            {
                certificate.Price = certificateDTO.Price;
            }

            if (certificateDTO.ImageSrc != null && certificateDTO.ImageSrc.Trim() != "")
            {
                certificate.ImageSrc = certificateDTO.ImageSrc;
            }
            context.SaveChanges();

        }

        public bool DeleteCertificate(string Title)
        {
            var certificate = context.Certificates.FirstOrDefault(x => x.Title == Title);

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
