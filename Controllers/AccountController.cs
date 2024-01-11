using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        
        private readonly AccountServices accountServices;

        public AccountController(IConfiguration configuration, AccountServices accountServices)
        {
            this.configuration = configuration;
            this.accountServices = accountServices;
        }

        
        [HttpPost("login")]
        public IActionResult Login(UserLogin userLogin)
        {

            var (success, token, user) = accountServices.Login(userLogin);

            if (!success)
            {
                ModelState.AddModelError("Error", "Email or password is not valid");
                return BadRequest(ModelState);
            }

            var response = new
            {
                Token = token,
                User = user
            };

            return Ok(response);
        }
    }
}
