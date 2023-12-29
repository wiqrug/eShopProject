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
        public IActionResult Register(UserDto userDto)
        {
            var emailCount = context.Users.Count(u => u.Email == userDto.Email);
            if (emailCount > 0)
            {
                ModelState.AddModelError("Email", "This Email address is alread used");
                return BadRequest(ModelState);
            }

            //encrypt the password
            var passwordHasher = new PasswordHasher<User>();
            var encryptedPassword = passwordHasher.HashPassword(new Models.User(), userDto.Password);

            User user = new User()
            {
                Email = userDto.Email,
                Password = encryptedPassword,
                role=userDto.role

            };

            context.Users.Add(user);
            context.SaveChanges();

            var jwt = CreateJWToken(user);

            UserProfileDto userProfileDto = new UserProfileDto()
            {
                Email=userDto.Email,
                role=userDto.role
            };

            var response = new
            {
                Token = jwt,
                User = userProfileDto
            };

            return Ok(response);
        }

        [HttpPost("Login")]
        public IActionResult Login(string email, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                ModelState.AddModelError("Error", "Email or password is not valid");
                return BadRequest(ModelState);
            }

            //verify the password
            var passwordHasher = new PasswordHasher<User>();

            var result = passwordHasher.VerifyHashedPassword(new User(), user.Password, password);

            if (result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("Password", "Wrong Password");
                return BadRequest(ModelState);
            }

            var jwt = CreateJWToken(user);
            var userProfileDto = new UserProfileDto()
            {
                Email = user.Email,
                role = user.role

            };

            var response = new
            {
                Token = jwt,
                User = userProfileDto
            };

            return Ok(response);
        }


        [Authorize]
        [HttpGet("AuthorizeAuthenticatedUsers")]
        public IActionResult AuthorizeAuthenticatedUSers()
        {
            return Ok("You are authorized client");
        }

        [Authorize(Roles = "admin")]
        [HttpGet("AuthorizeAdmin")]
        public IActionResult AuthorizeAdmin()
        {
            return Ok("You are authorized Admin");
        }


        private string CreateJWToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("id",  ""+user.UserID),
                new Claim("role","" +  Models.User.Role.Admin)
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
