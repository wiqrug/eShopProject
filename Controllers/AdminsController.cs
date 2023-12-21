//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Project2.Services;

//namespace Project2.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AdminsController : ControllerBase
//    {
//        private readonly AdminServices adminsServices;

//        public AdminsController(AdminServices adminsServices)
//        {
//            this.adminsServices = adminsServices;
//        }
//        [HttpGet]
//        public IActionResult GetAdmins()
//        {
            
//            return Ok(adminsServices.GetAdmins());
//        }

//        [HttpPost]
//        public IActionResult CreateAdmin()
//        {
//            return Ok();
//        }
//    }
//}
