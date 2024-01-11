using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project2.Services;

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
        [ServiceFilter(typeof(AuthenticationFilterBoth))]
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
        [ServiceFilter(typeof(AuthenticationFilterBoth))]
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
    }
}
