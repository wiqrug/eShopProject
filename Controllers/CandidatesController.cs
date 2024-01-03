using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.Services;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateServices candidateServices;
        private readonly ILogger<CandidatesController> logger; // Add logger

        public CandidatesController(CandidateServices candidateServices, ILogger<CandidatesController> logger)
        {
            this.candidateServices = candidateServices;
            this.logger = logger;
        }

        [HttpPost]  // Create Candidate
        public IActionResult CreateCandidate(CandidateDTO candidateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    logger.LogError($"Invalid model state: {string.Join(", ", errors)}");
                    return BadRequest(new { message = "Invalid data provided", details = errors });
                }

                candidateServices.CreateCandidate(candidateDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError($"An error occurred in CreateCandidate: {ex.Message}");
                return StatusCode(500, "An internal error occurred"); // Generic error for unhandled exceptions
            }
        }



        [HttpPut("{candidateNumber}")]   // Update Candidate
        public IActionResult UpdateCandidate(int candidateNumber, CandidateDTO candidateDTO)
        {
            if (candidateNumber == null)
            {
                return BadRequest("Candidate number doesnt exist");
            }
            candidateServices.UpdateCandidate(candidateNumber, candidateDTO);

            return Ok();
        }
    }
}
