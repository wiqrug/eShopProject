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

        //Test admins functionality
        [HttpGet]
        public IActionResult GetAdmins()
        {

            return Ok(adminsServices.GetAdmins());
        }

        [HttpPost]
        public IActionResult CreateAdmin(AdminDTO adminDTO)
        {
            adminsServices.CreateAdmin(adminDTO);
            return Ok();
        }


        //Admin able to create a new Candidate
        //In fact before doing this i must validate that user = admin
        // but actually admins will be hardCoded

        //fix this to call adminsServices
        [HttpPost("/admin/add-candidate")]
        public IActionResult addCandidate(CandidateDTO candidateDTO, string email, string password)
        {
            if (adminsServices.isAdmin(email, password)) { candidateServices.CreateCandidate(candidateDTO);
                return Ok();
            }
            else { return BadRequest("User is not an admin."); }
        }

        //Remove a Candidate
   
        [HttpDelete("{candidateNumber}")] // Delete Candidate
        public IActionResult DeleteCandidate(int candidateNumber,string email, string password)
        {
            if (adminsServices.isAdmin(email, password))
            {
                bool isDeleted = adminsServices.DeleteCandidate(candidateNumber);

                if (!isDeleted)
                {
                    return NotFound();
                }

                return Ok();
            }
            else return BadRequest("You are not an admin bro, what are you trying to do!");
   
        }

        [HttpGet("admin/get-candidates")]   // Show List of Candidates
        public IActionResult GetCandidates(string email, string password)
        {
            if (adminsServices.isAdmin(email, password)) { return Ok(adminsServices.GetCandidates()); }
            else
            { return BadRequest("You are not an admin mofo"); };
        }

        [HttpGet("admin/get-candidate-by-number/{candidateNumber}")]
        public IActionResult getCandidateByNumber(int candidateNumber, string email,string password)
        {
            if (adminsServices.isAdmin(email, password))
            {
                var candidate = adminsServices.GetCandidateById(candidateNumber);
                if (candidate == null)
                { return BadRequest("Candidate is not found"); }
                else { return Ok(candidate); }
            }
            else return BadRequest("You are not an admin brotha");
        }

        [HttpPut("admin/update-candidate/{candidateNumber}")]   // Update Candidate
        public IActionResult UpdateCandidate(int candidateNumber, CandidateDTO candidateDTO,string email,string password)
        {
            if (adminsServices.isAdmin(email, password))
            {
                if (candidateNumber == null)
                {
                    return BadRequest("Candidate number doesnt exist");
                }
                candidateServices.UpdateCandidate(candidateNumber, candidateDTO);

                return Ok();
            }
            else return BadRequest("You are not an admin brotha");
        }




    }
}
