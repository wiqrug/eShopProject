using Microsoft.AspNetCore.Http;
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

        [ServiceFilter(typeof(AuthenticationFilterAdmin))]
        [HttpGet]
        public IActionResult GetAdmins()
        {
            return Ok(adminsServices.GetAdmins());
        }

        //[ServiceFilter(typeof(AuthenticationFilterAdmin))] to theloume???
        [HttpPost]
        public IActionResult CreateAdmin(AdminDTO adminDTO)
        {
            adminsServices.CreateAdmin(adminDTO);
            return Ok();
        }

        [ServiceFilter(typeof(AuthenticationFilterAdmin))]
        [HttpPost("/admin/add-candidate")]
        public IActionResult addCandidate(CandidateDTO candidateDTO)
        {           
            candidateServices.CreateCandidate(candidateDTO);
            return Ok();
        }

        //Remove a Candidate
        [ServiceFilter(typeof(AuthenticationFilterAdmin))]
        [HttpDelete("{candidateNumber}")] 
        public IActionResult DeleteCandidate(int candidateNumber)
        {
            bool isDeleted = adminsServices.DeleteCandidate(candidateNumber);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();
        }

        // Show List of Candidates
        [ServiceFilter(typeof(AuthenticationFilterAdmin))]
        [HttpGet("admin/get-candidates")]   
        public IActionResult GetCandidates()
        {
            return Ok(adminsServices.GetCandidates());
        }

        [ServiceFilter(typeof(AuthenticationFilterAdmin))]
        [HttpGet("admin/get-candidate-by-number/{candidateNumber}")]
        public IActionResult getCandidateByNumber(int candidateNumber)
        {
            var candidate = adminsServices.GetCandidateById(candidateNumber);
            if (candidate == null)
            { 
                return NotFound("Candidate is not found"); 
            }
            else 
            { 
                return Ok(candidate); 
            }
        }
        
        // Update Candidate
        [ServiceFilter(typeof(AuthenticationFilterAdmin))]
        [HttpPut("admin/update-candidate/{candidateNumber}")]   
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
