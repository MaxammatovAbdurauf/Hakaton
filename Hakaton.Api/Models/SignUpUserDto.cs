using System.ComponentModel.DataAnnotations;

namespace Hakaton.Api.Models
{
    public class SignUpUserDto
    {
        [Required]
        public string? UserName { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

        public IFormFile? Avatar { get; set; }
    }
}
