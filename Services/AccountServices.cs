using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Project2.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project2.Services
{
    public class AccountServices
    {
        private ApplicationDBContext context;
        private readonly IPasswordHasher<Candidate> passwordHasher;
        private readonly IConfiguration configuration;
        
        public AccountServices(ApplicationDBContext context, IPasswordHasher<Candidate> passwordHasher, IConfiguration configuration)
        {
            this.context = context;
            this.passwordHasher = passwordHasher;
            this.configuration = configuration;
        }

        public (bool Success, string Token, CandidateProfileDTO User) Login(User user)
        {
            var candidate = context.Candidates.FirstOrDefault(u => u.Email == user.Email);

            if (candidate == null)
            {
                return (false, null, null);
            }

            var result = passwordHasher.VerifyHashedPassword(new Candidate(), candidate.Password, user.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return (false, null, null);
            }

            var jwt = CreateJWToken(candidate);
            var candidateProfileDTO = new CandidateProfileDTO
            {
                Email = candidate.Email,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName
            };

            return (true, jwt, candidateProfileDTO);
        }




        private string CreateJWToken(Candidate candidate)
        {
            if (candidate == null)
            {
                throw new ArgumentNullException(nameof(candidate), "Candidate cannot be null.");
            }

            var claims = new List<Claim>
    {
        new Claim("id", candidate.UserId.ToString()),
        // Add other claims as needed
    };

            string strKey = configuration["JwtSettings:Key"];
            if (string.IsNullOrEmpty(strKey))
            {
                throw new InvalidOperationException("JWT Key is not set in the configuration.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(strKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var issuer = configuration["JwtSettings:Issuer"];
            var audience = configuration["JwtSettings:Audience"];

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //    private string CreateJWToken(Candidate candidate)
        //    {
        //        var claims = new[]
        //        {
        //    new Claim(JwtRegisteredClaimNames.Sub, candidate.Email),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    // Add other claims as needed
        //};

        //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyHere")); // Replace with your actual secret key
        //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //        var token = new JwtSecurityToken(
        //            issuer: "YourIssuer", // Replace with your issuer
        //            audience: "YourAudience", // Replace with your audience
        //            claims: claims,
        //            expires: DateTime.Now.AddHours(1), // Token expiration time
        //            signingCredentials: creds);

        //        return new JwtSecurityTokenHandler().WriteToken(token);
        //    }

    }
}
