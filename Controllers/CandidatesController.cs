using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Project2.Services;
using static AuthenticationFilter;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateServices candidateServices;
        private readonly ActionExecutingContext context;

        public CandidatesController(CandidateServices candidateServices, ActionExecutingContext context)
        {
            this.candidateServices = candidateServices;
            this.context = context;
        }

        // Create Candidate
        [Authorize(Roles = "Admin, Candidate")]
        [HttpPost]  
        public IActionResult CreateCandidate(CandidateDTO candidateDTO)
        {
            if (candidateServices.EmailExists(candidateDTO.Email))
            {
                return BadRequest("This email address is already in use");
            }
            candidateServices.CreateCandidate(candidateDTO);
            return Ok();
        }

        // Update Candidate
        [Authorize(Roles = "Admin, Candidate")]
        [HttpPut("{candidateNumber}")]   
        public IActionResult UpdateCandidate(int candidateNumber, CandidateDTO candidateDTO)
        {
            if (candidateNumber == null)
            {
                return BadRequest("Candidate doesnt exist");
            }
            candidateServices.UpdateCandidate(candidateNumber, candidateDTO);

            return Ok();
        }

        public class CurrentUser
        {
            public string email { get; set; }
            public string token { get; set; }
            public int candidatenumber { get; set; }
        }

        [Authorize(Roles = "Candidate")]
        [HttpGet("{candidateNumber}")]
        public IActionResult getCandidateByNumber(int candidateNumber)
        {

            string? cookie = context.HttpContext.Request.Cookies["currentUser"];
            CurrentUser parsedCookie = JsonConvert.DeserializeObject<CurrentUser>(cookie);
            int candNum = parsedCookie.candidatenumber;
            if (candidateNumber !=  candNum)
            {
                return Unauthorized("No no no, you can't see someone else's personal info");
            }
            var candidate = candidateServices.GetCandidateById(candidateNumber);
            if (candidate == null)
            {
                return NotFound("Candidate is not found");
            }
            else
            {
                return Ok(candidate);
            }
        }

    }
}
