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

        public CandidatesController(CandidateServices candidateServices)
        {
            this.candidateServices = candidateServices;
        }

        [HttpGet]   // Show List of Candidates
        public IActionResult GetCandidates()
        {
            return Ok(candidateServices.GetCandidates());
        }

        //[HttpGet("{id}")]   // Show Candidate
        //public IActionResult GetCandidate(int id)
        //{
        //    var candidate = context.Candidates.Find(id);

        //    if (candidate == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(candidate);
        //}

        [HttpPost]  // Create Candidate
        public IActionResult CreateCandidate(CandidateDTO candidateDTO)
        {
            candidateServices.CreateCandidate(candidateDTO);
            return Ok();
        }

        //[HttpDelete("{id}")]    // Delete Candidate
        //public IActionResult DeleteCandidate(int id)
        //{
        //    var candidate = context.Candidates.Find(id);

        //    if (candidate == null)
        //    {
        //        return NotFound();
        //    }

        //    context.Candidates.Remove(candidate);
        //    context.SaveChanges();

        //    return Ok(candidate);
        //}

        [HttpPut("{candidateNumber}")]   // Update Candidate
        public IActionResult UpdateCandidate(string candidateNumber, CandidateDTO candidateDTO)
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
