using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

namespace homework_2.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class HomeController : Controller 
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet]
        [Route("/login")]
        public IActionResult login()
        {
            return Json(new {success=true , data="login get methot"});
        }

        [HttpGet]
        [Route("/register")]
        public IActionResult register()
        {
            return Json(new { success = true, data = "register get methot" });
        }

        [HttpPut]
        
        [ApiExplorerSettings(IgnoreApi = true)]  // We can hide this end point on swagger using this line
        
        public IActionResult test()
        {
            return Ok();
        }
    }
}
