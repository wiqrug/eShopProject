using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;

namespace Project2.Services
{
    
    public class AdminServices
    {
        private readonly ApplicationDBContext context;

        public AdminServices(ApplicationDBContext context)
        {
            this.context = context;
        }

        
        public List<Admin> GetAdmins()
        {
            var admins = context.Admins.ToList();
            return admins;
        }

        public void CreateAdmin(AdminDTO admin)
        {
            var passwordHasherAdmin = new PasswordHasher<Admin>();
            var encryptedPassword = passwordHasherAdmin.HashPassword(new Admin(), admin.Password);

            var ad = new Admin 
            { 
                FirstName = admin.FirstName,
                Address = admin.Address,
                Email = admin.Email,
                LastName = admin.LastName,
                MobileNumber = admin.MobileNumber,
                Password = encryptedPassword,
                role = User.Role.Admin
            };
            context.Admins.Add(ad);
            context.SaveChanges();
        }
        public bool EmailExists(string email)
        {
            var emailCount = context.Users.Count(u => u.Email == email);
            return emailCount > 0;
        }        

        public bool DeleteCandidate(int candidateNumber)
        {
            var candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateNumber);

            if (candidate == null)
            {
                return false;
            }

            context.Candidates.Remove(candidate);
            context.SaveChanges();

            return true;
        }
        public List<Candidate> GetCandidates()
        {
            var candidates = context.Candidates.ToList();
            return candidates;

        }
     
    }
}
