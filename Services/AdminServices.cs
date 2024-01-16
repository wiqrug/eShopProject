﻿using Microsoft.AspNetCore.Identity;
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

        public void CreateCandidate(CandidateDTO candidateDTO)
        {
            int maxCandidateNumber = context.Candidates.Max(c => (int?)c.CandidateNumber) ?? 1000; // Starting from 1001
            var passwordHasher = new PasswordHasher<Candidate>();
            var encryptedPassword = passwordHasher.HashPassword(new Candidate(), candidateDTO.Password);

            var candidate = new Candidate
            {
                // Assuming CandidateID is set elsewhere or automatically

                // Direct mapping from DTO to Candidate properties
                CandidateNumber = maxCandidateNumber + 1,
                FirstName = candidateDTO.FirstName,
                MiddleName = candidateDTO.MiddleName,
                LastName = candidateDTO.LastName,
                Gender = candidateDTO.Gender,
                NativeLanguage = candidateDTO.NativeLanguage,
                BirthDate = candidateDTO.BirthDate,

                PhotoIDType = candidateDTO.PhotoIDType,
                PhotoIDNumber = candidateDTO.PhotoIDNumber,
                PhotoIDIssueDate = candidateDTO.PhotoIDIssueDate,

                Email = candidateDTO.Email,
                Address = candidateDTO.Address,
                AddressLine2 = candidateDTO.AddressLine2,
                CountryOfResidence = candidateDTO.CountryOfResidence,
                StateOrTerritoryOrProvince = candidateDTO.StateOrTerritoryOrProvince,
                TownOrCity = candidateDTO.TownOrCity,
                PostalCode = candidateDTO.PostalCode,
                LandlineNumber = candidateDTO.LandlineNumber,
                MobileNumber = candidateDTO.MobileNumber,
                Password = encryptedPassword,
                role = Models.User.Role.Candidate,
             
            };

            context.Candidates.Add(candidate);
            context.SaveChanges();
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
