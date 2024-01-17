using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Project2.Models;
using Project2.Services;

namespace Project2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CandidateExamController : Controller
    {
        private readonly CandidateExamServices candidateExamServices;

        public CandidateExamController(CandidateExamServices candidateExamServices)
        {
            this.candidateExamServices = candidateExamServices;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetCandidateExam()
        {
            try
            {
                return Ok(candidateExamServices.GetCandidateExam());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateCandidateExam(CandidateExamDTO candidateExamDTO)
        {
            try
            {
                bool success = candidateExamServices.CreateCandidateExam(candidateExamDTO);
                if (!success)
                {
                    return BadRequest("The Candidate already took this exam");
                }

                return Ok("CandidateExam created");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{candidateId}")]
        public IActionResult DeleteCandidateExam(Guid candidateId)
        {
            try
            {
                bool success=candidateExamServices.DeleteCandidateExam(candidateId);
                if (!success)
                {
                    return BadRequest("Failed to delete, the candidateId does not exist");
                }
                return Ok("CandidateExam deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{candidateExamId}")]
        public IActionResult UpdateCandidateExam(Guid candidateExamId, CandidateExamDTO candidateExamDTO)
        {
            try
            {
                // Check the presence of the custom header
                if (!Request.Headers.TryGetValue("CustomAuthorizationHeader", out var customHeaderValue) ||
                    customHeaderValue != "4bc0ab7d74b8f63e1e08cbc2ecc7d5f43f42edb9e5dfa46f38397d5e0ad61d08826735f48930a1d6e4a5b3fbd110c83ffa6812647156709f1c478d7a568b3008a60fac4b9eb575b5e86b15801647f62a")
                {
                    return Unauthorized("Invalid or missing custom authorization header, who are u?");
                }

                candidateExamServices.UpdateCandidateExam(candidateExamId, candidateExamDTO);
                
                return Ok("Update was successful");
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine(ex.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }






        




    }
}
