using Microsoft.AspNetCore.Mvc;

namespace RamandProject.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
