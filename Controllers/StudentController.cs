using Microsoft.AspNetCore.Mvc;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetResult()
        {
            return "Hello API";
        }

    }
}