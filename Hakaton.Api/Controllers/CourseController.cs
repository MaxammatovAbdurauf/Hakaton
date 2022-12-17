using HakatonApi.DataBase;
using HakatonApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Controllers;

[Route("Api.[controller]")]
[Authorize]
public class CourseController : ControllerBase
{
    public CourseController ()
    {

    }
}