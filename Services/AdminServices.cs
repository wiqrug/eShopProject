using Microsoft.AspNetCore.Mvc;
using Project2.Models;

namespace Project2.Services
{
    //Admin should be able to do Candidates CRUD
    public class AdminServices
    {
        private readonly ApplicationDBContext context;

        public AdminServices(ApplicationDBContext context)
        {
            this.context = context;
        }

        //Following code is to test if we are able to add admin and get admin
        public List<Admin> GetAdmins()
        {
            var admins = context.Admins.ToList();
            return admins;
        }

        public void CreateAdmin(AdminDTO admin)
        {
            var ad = new Admin { FirstName = admin.FirstName,
                Address = admin.Address, Email = admin.Email,
                LastName = admin.LastName,
                MobileNumber = admin.MobileNumber,
                Password = admin.Password,
                role = User.Role.Admin
            };
            context.Admins.Add(ad);
            context.SaveChanges();
        }

        public bool isAdmin(string email, string password)
        {
            var user = context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

            // Check if a user was found and if the user is an Admin
            return user != null && user.role == User.Role.Admin;
        }

        public bool DeleteCandidate(int candidateNumber)
        {
            var candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateNumber);
            //var candidate = context.Candidates.Find(id);

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

        //Additional check if candidate exists or no
        public Candidate GetCandidateById(int candidateNumber)
        {
            var candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateNumber);
            return candidate;
        }
     
    }
}
