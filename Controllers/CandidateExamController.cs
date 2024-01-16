using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

                return Ok();
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
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }


    }
}
