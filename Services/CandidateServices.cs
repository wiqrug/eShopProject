using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Project2.Models;

namespace Project2.Services
{
    public class CandidateServices
    {
        private readonly ApplicationDBContext context;

        public CandidateServices(ApplicationDBContext context)
        {
            this.context = context;
        }

        public bool EmailExists(string email)
        {
            var emailCount = context.Users.Count(u => u.Email == email);
            return emailCount > 0;
        }

        public void CreateCandidate(CandidateDTO candidateDTO)
        {
            int maxCandidateNumber = context.Candidates.Max(c => (int?)c.CandidateNumber) ?? 1000; 
            var passwordHasher = new PasswordHasher<Candidate>();
            var encryptedPassword = passwordHasher.HashPassword(new Candidate(), candidateDTO.Password);

            var candidate = new Candidate
            {
                                
                CandidateNumber = maxCandidateNumber + 1,
                role = Models.User.Role.Candidate,
                FirstName = candidateDTO?.FirstName,
                MiddleName = candidateDTO?.MiddleName,
                LastName = candidateDTO?.LastName,
                Gender = candidateDTO?.Gender,
                NativeLanguage = candidateDTO?.NativeLanguage,
                BirthDate = candidateDTO?.BirthDate,
                PhotoIDType = candidateDTO?.PhotoIDType,
                PhotoIDNumber = candidateDTO?.PhotoIDNumber,
                PhotoIDIssueDate = candidateDTO?.PhotoIDIssueDate,
                Email = candidateDTO?.Email,
                Password = encryptedPassword,
                Address = candidateDTO? .Address,
                AddressLine2 = candidateDTO?.AddressLine2,
                CountryOfResidence = candidateDTO?.CountryOfResidence,
                StateOrTerritoryOrProvince = candidateDTO?.StateOrTerritoryOrProvince,
                TownOrCity = candidateDTO?.TownOrCity,
                PostalCode = candidateDTO?.PostalCode,
                LandlineNumber = candidateDTO?.LandlineNumber,
                MobileNumber = candidateDTO?.MobileNumber
            };

            context.Candidates.Add(candidate);
            context.SaveChanges();
        }

        public Candidate GetCandidateById(int candidateNumber)
        {
            var candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber == candidateNumber);
            return candidate;
        }


        public void UpdateCandidate(int candidateNumber,CandidateDTO candidateDTO)
        {

            var candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber==candidateNumber);
            if (candidate == null)
            {
                return;
            }

            
            if (!string.IsNullOrWhiteSpace(candidateDTO.FirstName))
            {
                candidate.FirstName = candidateDTO.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.MiddleName))
            {
                candidate.MiddleName = candidateDTO.MiddleName;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.LastName))
            {
                candidate.LastName = candidateDTO.LastName;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.Gender))
            {
                candidate.Gender = candidateDTO.Gender;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.NativeLanguage))
            {
                candidate.NativeLanguage = candidateDTO.NativeLanguage;
            }

            if (candidateDTO.BirthDate != null)
            {
                candidate.BirthDate = candidateDTO.BirthDate;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.PhotoIDType))
            {
                candidate.PhotoIDType = candidateDTO.PhotoIDType;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.PhotoIDNumber))
            {
                candidate.PhotoIDNumber = candidateDTO.PhotoIDNumber;
            }

            if (candidateDTO.PhotoIDIssueDate != null)
            {
                candidate.PhotoIDIssueDate = candidateDTO.PhotoIDIssueDate;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.Email))
            {
                candidate.Email = candidateDTO.Email;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.Password))
            {
                candidate.Password = candidateDTO.Password;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.Address))
            {
                candidate.Address = candidateDTO.Address;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.AddressLine2))
            {
                candidate.AddressLine2 = candidateDTO.AddressLine2;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.CountryOfResidence))
            {
                candidate.CountryOfResidence = candidateDTO.CountryOfResidence;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.StateOrTerritoryOrProvince))
            {
                candidate.StateOrTerritoryOrProvince = candidateDTO.StateOrTerritoryOrProvince;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.TownOrCity))
            {
                candidate.TownOrCity = candidateDTO.TownOrCity;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.PostalCode))
            {
                candidate.PostalCode = candidateDTO.PostalCode;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.LandlineNumber))
            {
                candidate.LandlineNumber = candidateDTO.LandlineNumber;
            }

            if (!string.IsNullOrWhiteSpace(candidateDTO.MobileNumber))
            {
                candidate.MobileNumber = candidateDTO.MobileNumber;
            }
            context.SaveChanges();

        }    
    }
}
