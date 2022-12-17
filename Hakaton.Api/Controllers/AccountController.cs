using Hakaton.Api.Models;
using HakatonApi.DataBase;
using HakatonApi.Entities;
using HakatonApi.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hakaton.Api.Controller;

[Route("api/[controller]")]
[ApiController]

public class AccountController : ControllerBase
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromForm] SignUpUserDto registerUserDto)
    {
        var user = registerUserDto.Adapt<User>();
        var result = await _userManager.CreateAsync(user, registerUserDto.Password);

        if (!result.Succeeded)
            return BadRequest();

        await _signInManager.SignInAsync(user, true);
        return Ok(user);
    }
    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(string userName, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(userName, password, true, true);
        if (!result.Succeeded)
            return BadRequest();

        return Ok();
    }
}
