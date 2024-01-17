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

        public bool DeleteAdmin(Guid userId)
        {
            var admin = context.Admins.FirstOrDefault(x => x.UserId == userId);

            if (admin == null)
            {
                return false;
            }

            context.Admins.Remove(admin);
            context.SaveChanges();

            return true;
        }

        public void UpdateAdmin(Guid userId, AdminDTO adminDTO)
        {

            var admin = context.Admins.FirstOrDefault(x => x.UserId == userId);
            if (admin == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(adminDTO.FirstName))
            {
                admin.FirstName = adminDTO.FirstName;
            }
            if (!string.IsNullOrWhiteSpace(adminDTO.LastName))
            {
                admin.LastName = adminDTO.LastName;
            }
            if (!string.IsNullOrWhiteSpace(adminDTO.Address))
            {
                admin.Address = adminDTO.Address;
            }
            if (!string.IsNullOrWhiteSpace(adminDTO.MobileNumber))
            {
                admin.MobileNumber = adminDTO.MobileNumber;
            }
            if (!string.IsNullOrWhiteSpace(adminDTO.Password))
            {
                admin.Password = adminDTO.Password;
            }
            if (!string.IsNullOrWhiteSpace(adminDTO.Email))
            {
                admin.Email = adminDTO.Email;
            }
            context.SaveChanges();
        }
    }
}
