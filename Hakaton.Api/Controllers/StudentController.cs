using HakatonApi.Services;
using HakatonApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Controllers;

[Route("[controller]")]
[ApiController]
public class StudentController : Controller
{
    private readonly UserService studentService;
    private readonly UserManager<User> userManager;
    public StudentController (UserService _studentService,
                             UserManager<User> _userManager)
    {
        studentService = _studentService; 
        userManager = _userManager;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> JoinToCourse(Guid courseId)
    {
        var user = await userManager.GetUserAsync(User);
        await studentService.JoinToCourse(courseId, user.Id);
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> LeaveCourse(Guid courseId)
    {
        var user = await userManager.GetUserAsync(User);
        await studentService.LeaveCourse(courseId, user.Id);
        return Ok();
    }
}