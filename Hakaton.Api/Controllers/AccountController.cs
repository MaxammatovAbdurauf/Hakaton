using Hakaton.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hakaton.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SignUp([FromForm] SignUpUserDto dtoModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (dtoModel.Password != dtoModel.ConfirmPassword)
                return BadRequest();

            return Ok();
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInUserDto signInUserDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok();
        }
    }
}
