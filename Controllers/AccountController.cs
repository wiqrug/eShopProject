﻿using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Services;

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
            try
            {
                //throw new Exception("Simulated exception"); 

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
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
