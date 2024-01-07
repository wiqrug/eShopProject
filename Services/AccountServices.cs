using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project2.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project2.Services
{
    public class LoginService
    {

        private readonly ApplicationDBContext context;
        public readonly IConfiguration configuration;


        public LoginService(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }


        public object Login([FromBody] User user)
        {
            var candidate = context.Candidates.FirstOrDefault(u => u.Email == user.Email);

            if (candidate == null)
            {
                object errorMessage = "Email or password is not valid";
                return (errorMessage);
            }

            //verify the password
            var passwordHasher = new PasswordHasher<Candidate>();

            var result = passwordHasher.VerifyHashedPassword(new Candidate(), candidate.Password, user.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                object errorMessage = "Wrong Password";
                return (errorMessage);
            }

            /*            if(an einai admin){
                            na kanei tin parakato diadikasia gia admin stoixeia
                            }
                            else{
                                na kanei to idio gia candidate stoixeia
                            }
            */
            var jwt = CreateJWToken(candidate);
            var candidateProfileDTO = new CandidateProfileDTO()
            {
                Email = candidate.Email, //edo vazoume osa stoixeia tou candidate theloume na 
                                         //na exoume sto front

            };

            var response = new
            {
                Token = jwt,
                User = candidateProfileDTO
            };

            return response;
        }


        private string CreateJWToken(Candidate candidate)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("id",  candidate.UserId.ToString()),
                new Claim("role", candidate.role.ToString())
            };

            string strKey = configuration["JwtSettings:Key"]!;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(strKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: configuration["JwtSettings:Issuer"],
                    audience: configuration["JwtSettings:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}