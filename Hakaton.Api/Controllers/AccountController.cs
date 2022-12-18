﻿using Hakaton.Api.Models;
using HakatonApi.Entities;
using HakatonApi.Models.UserDtos;
using HakatonApi.Services;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hakaton.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly SignInManager<User> signInManager;
    private readonly UserManager<User> userManager;
    private readonly AccountService accountService;

    public AccountController(SignInManager<User> signInManager,
                               UserManager<User> userManager,
                               AccountService accountService)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.accountService = accountService;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromForm] SignUpUserDto registerUserDto)
    {
        var user = registerUserDto.Adapt<User>();
        var result = await userManager.CreateAsync(user, registerUserDto.Password);

        if (!result.Succeeded)
            return BadRequest();

        await signInManager.SignInAsync(user, true);
        return Ok(user);
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(string userName, string password)
    {
        var result = await signInManager.PasswordSignInAsync(userName, password, true, true);
        if (!result.Succeeded)
            return BadRequest();

        return Ok();
    }

    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAccount(UpdateUserDto updateUserDto)
    {
        var user = await userManager.GetUserAsync(User);
        accountService.UpdateAccount(user.Id, updateUserDto);
        return Ok();
    }

    [HttpDelete]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAccount()
    {
        var user = await userManager.GetUserAsync(User);
        accountService.DeleteAccount(user);
        return Ok();
    }
}