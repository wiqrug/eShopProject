using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Services;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly AdminServices adminsServices;

        public CandidateServices candidateServices { get; }

        public AdminsController(AdminServices adminsServices, CandidateServices candidateServices)
        {
            this.adminsServices = adminsServices;
            this.candidateServices = candidateServices;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAdmins()
        {
            try
            {
                return Ok(adminsServices.GetAdmins());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateAdmin(AdminDTO adminDTO)
        {
            try
            {
                adminsServices.CreateAdmin(adminDTO);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("addCandidate")]
        public IActionResult addCandidate(CandidateDTO candidateDTO)
        {
            try
            {
                if (adminsServices.EmailExists(candidateDTO.Email))
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

        //Remove a Candidate
        [Authorize(Roles = "Admin")]
        [HttpDelete("{candidateNumber}")] 
        public IActionResult DeleteCandidate(int candidateNumber)
        {
            try
            {
                bool isDeleted = adminsServices.DeleteCandidate(candidateNumber);

                if (!isDeleted)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        // Show List of Candidates
        [Authorize(Roles = "Admin")]
        [HttpGet("getCandidates")]   
        public IActionResult GetCandidates()
        {
            try
            {

                return Ok(adminsServices.GetCandidates());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }




        [Authorize(Roles = "Admin")]
        [HttpGet("getCandidateByNumber/{candidateNumber}")]
        public IActionResult getCandidateByNumber(int candidateNumber)
        {
            try
            {
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
        
        // Update Candidate
        [Authorize(Roles = "Admin")]
        [HttpPut("updateCandidate/{candidateNumber}")]   
        public IActionResult UpdateCandidate(int candidateNumber, CandidateDTO candidateDTO)
        {
            try
            {
                if (candidateNumber == null)
                {
                    return BadRequest("Candidate number doesnt exist");
                }
                candidateServices.UpdateCandidate(candidateNumber, candidateDTO);

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
