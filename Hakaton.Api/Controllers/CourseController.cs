using HakatonApi.Dtos.CourseDtos;
using HakatonApi.Entities;
using HakatonApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Controllers;

[Route("Api.[controller]")]
[ApiController]
[Authorize]
public class CourseController : ControllerBase
{
    private readonly CourseService courseService;
    private readonly UserManager<User> userManager;
    public CourseController(CourseService _courseService, UserManager<User> _userManager)
    {
        courseService = _courseService;
        userManager = _userManager;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CourseView), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateCourse(GetCourseDto getCourseDto)
    {
        var user = await userManager.GetUserAsync(User);
        await courseService.CreateCourse(user.Id, getCourseDto);
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(typeof(CourseView), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCourseById(Guid courseId)
    {
        var course = await courseService.GetCourseById(courseId);
        if (course is null) return BadRequest();
        return Ok(course);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<CourseView>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCourses() =>
        Ok(await courseService.GetCourses());

    [HttpPut]
    [ProducesResponseType(typeof(CourseView), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateCourse(UpdateCourseDto updateCourseDto)
    {
        var user = await userManager.GetUserAsync(User);
        await courseService.UpdateCourse(user.Id, updateCourseDto);
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(typeof(CourseView), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteCourse(Guid courseId)
    {
        await courseService.DeleteCourse(courseId);
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(typeof(CourseView), StatusCodes.Status200OK)]
    public async Task<IActionResult> JoinToCourse(Guid courseId)
    {
        var user = await userManager.GetUserAsync(User);
        await courseService.JointoCourse(user.Id, courseId);
        return Ok();
    }
}