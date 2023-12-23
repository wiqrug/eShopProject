namespace Project2.Services
{
    public class CandidatesCertificatesServices
    {
        private readonly ApplicationDBContext context;

        public CandidatesCertificatesServices(ApplicationDBContext context)
        {
            this.context = context;
        }

        public List<Certificate> GetObtainedCertificates(Candidate candidate)
        {
            List<Certificate> certs = new List<Certificate>();
            var obtainedCertificates = from candcert in context.CandidateCertificates where candcert.CandidateID == candidate.UserID select candcert.Certificate;
            foreach (var cert in obtainedCertificates)
            {
                certs.Add(cert);
            }
            return certs;
        }
    }
}
