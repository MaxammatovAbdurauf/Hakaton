using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeWorkController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok();
        }
        
    }
}
