﻿using System.ComponentModel.DataAnnotations;

namespace Hakaton.Api.Models
{
    public class SignInUserDto
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
