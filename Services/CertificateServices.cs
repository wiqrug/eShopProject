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

        public void CreateCertificate(CertificateDTO certificateDTO)
        {
            var certificate = new Certificate
            {
                // Assuming CertificateID is set elsewhere or automatically

                // Direct mapping from DTO to Certificate properties
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
            certificate.Title = certificateDTO.Title;
            certificate.Description = certificateDTO.Description;
            certificate.Price = certificateDTO.Price;
            certificate.ImageSrc = certificateDTO.ImageSrc;

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
