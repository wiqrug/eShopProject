using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project2.Services;
using Project2.Models;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateServices candidateServices;

        public CandidatesController(CandidateServices candidateServices)
        {
            this.candidateServices = candidateServices;
        }

        // Create Candidate
        [HttpPost]  
        public IActionResult CreateCandidate(CandidateDTO candidateDTO)
        {
            try
            {
                if (candidateServices.EmailExists(candidateDTO.Email))
                {
                    return BadRequest("This email address is already in use");
                }
                candidateServices.CreateCandidate(candidateDTO);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
        
        // Update Candidate
        [Authorize(Roles = "Candidate")]
        [HttpPut("{candidateNumber}")]   
        public IActionResult UpdateCandidate(int candidateNumber, CandidateDTO candidateDTO)
        {
            try
            {
                string? cookie = Request.Headers["currentUser"];
                CurrentUser? parsedCookie = JsonConvert.DeserializeObject<CurrentUser>(cookie);
                int? candNum = parsedCookie.candidatenumber;
                Console.WriteLine(candNum);
                if (candidateNumber != candNum || candidateNumber == 0)
                {
                    return Unauthorized("No no no, you can't change someone else's personal info");
                }

                candidateServices.UpdateCandidate(candidateNumber, candidateDTO);

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }


        // get candidate by candidateNumber
        [Authorize(Roles = "Candidate")]
        [HttpGet("{candidateNumber}")]
        public IActionResult getCandidateByNumber(int candidateNumber)
        {
            try
            {
                string? cookie = Request.Headers["currentUser"];
                CurrentUser? parsedCookie = JsonConvert.DeserializeObject<CurrentUser>(cookie);
                int? candNum = parsedCookie.candidatenumber;
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
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
                
        }

    }
}
