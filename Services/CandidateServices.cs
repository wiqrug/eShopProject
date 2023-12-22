namespace Project2.Services
{
    public class CandidateServices
    {
        private readonly ApplicationDBContext context;

        public CandidateServices(ApplicationDBContext context)
        {
            this.context = context;
        }



        public void CreateCandidate(CandidateDTO candidateDTO)
        {
            int maxCandidateNumber = context.Candidates.Max(c => (int?)c.CandidateNumber) ?? 1000; // Starting from 1001
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
                Password = candidateDTO.Password,
                role =Models.User.Role.Candidate,
            };

            context.Candidates.Add(candidate);
            context.SaveChanges();
        }

        public void UpdateCandidate(int? candidateNumber,CandidateDTO candidateDTO)
        {
            //Make user able to change whatever he wants 

            // x=y?t=1:t=2;

            var candidate = context.Candidates.FirstOrDefault(x => x.CandidateNumber==candidateNumber);

            // Update candidate properties with values from candidateDTO
            candidate.FirstName = candidateDTO.FirstName;
            candidate.MiddleName = candidateDTO.MiddleName;
            candidate.LastName = candidateDTO.LastName;
            candidate.Gender = candidateDTO.Gender;
            candidate.NativeLanguage = candidateDTO.NativeLanguage;
            candidate.BirthDate = candidateDTO.BirthDate;

            candidate.PhotoIDType = candidateDTO.PhotoIDType;
            candidate.PhotoIDNumber = candidateDTO.PhotoIDNumber;
            candidate.PhotoIDIssueDate = candidateDTO.PhotoIDIssueDate;

            candidate.Email = candidateDTO.Email;
            candidate.Address = candidateDTO.Address;
            candidate.AddressLine2 = candidateDTO.AddressLine2;
            candidate.CountryOfResidence = candidateDTO.CountryOfResidence;
            candidate.StateOrTerritoryOrProvince = candidateDTO.StateOrTerritoryOrProvince;
            candidate.TownOrCity = candidateDTO.TownOrCity;
            candidate.PostalCode = candidateDTO.PostalCode;

            candidate.LandlineNumber = candidateDTO.LandlineNumber;
            candidate.MobileNumber = candidateDTO.MobileNumber;

            context.SaveChanges();

        }

 
    }
}
