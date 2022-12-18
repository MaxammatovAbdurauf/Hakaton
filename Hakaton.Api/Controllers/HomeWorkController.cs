using HakatonApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[ValidateModel]
public class HomeWorkController : ControllerBase
{
    [HttpGet]
    public IActionResult GetTasks()
    {
        return Ok();
    }
}