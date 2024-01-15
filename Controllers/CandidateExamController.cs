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
        [HttpPost]
        public IActionResult CreateCandidateExam(CandidateExamDTO candidateExamDTO)
        {
            bool success = candidateExamServices.CreateCandidateExam(candidateExamDTO);
            if (!success)
            {
                return BadRequest("The Candidate already took this exam");
            }
            
            return Ok();
        }


        
    }
}
