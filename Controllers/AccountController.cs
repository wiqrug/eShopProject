using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project2.Models;
using Project2.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ApplicationDBContext context;

        public AccountController(IConfiguration configuration, ApplicationDBContext context)
        {
            this.configuration = configuration;
            this.context = context;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] CandidateDTO candidateDTO)
        {
            var emailCount = context.Users.Count(u => u.Email == candidateDTO.Email);
            if (emailCount > 0)
            {
                ModelState.AddModelError("Email", "This Email address is alread used");
                return BadRequest(ModelState);
            }

            //encrypt the password
            var passwordHasher = new PasswordHasher<Candidate>();
            var encryptedPassword = passwordHasher.HashPassword(new Candidate(), candidateDTO.Password);

            Candidate candidate = new Candidate()
            {
                Email = candidateDTO.Email,
                Password = encryptedPassword,
                FirstName = candidateDTO.FirstName,
                LastName = candidateDTO.LastName

            };

            context.Users.Add(candidate);
            context.SaveChanges();

            var jwt = CreateJWToken(candidate);

            CandidateProfileDTO candidateProfileDTO = new CandidateProfileDTO()
            {
                Email = candidateDTO.Email,
                FirstName = candidateDTO.FirstName,
                LastName = candidateDTO.LastName
            };

            var response = new
            {
                Token = jwt,
                User = candidateProfileDTO
            };

            return Ok(response);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User user)
        {
            var candidate = context.Candidates.FirstOrDefault(u => u.Email == user.Email);

            if (candidate == null)
            {
                ModelState.AddModelError("Error", "Email or password is not valid");
                return BadRequest(ModelState);
            }

            //verify the password
            var passwordHasher = new PasswordHasher<Candidate>();

            var result = passwordHasher.VerifyHashedPassword(new Candidate(), candidate.Password, user.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("Password", "Wrong Password");
                return BadRequest(ModelState);
            }

            var jwt = CreateJWToken(candidate);
            var candidateProfileDTO = new CandidateProfileDTO()
            {
                Email = candidate.Email,


            };

            var response = new
            {
                Token = jwt,
                User = candidateProfileDTO
            };

            return Ok(response);
        }


        [Authorize]
        [HttpGet("AuthorizeAuthenticatedCandidates")]
        public IActionResult AuthorizeAuthenticatedCandidates()
        {
            return Ok("Authorized candidate");
        }

        [Authorize(Roles = "admin")]
        [HttpGet("AuthorizeAdmin")]
        public IActionResult AuthorizeAdmin()
        {
            return Ok("Authorized Admin");
        }


        private string CreateJWToken(Candidate candidate)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("id",  ""+candidate.UserID),
                //new Claim("role","" +  Models.User.Role.Candidate)
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
