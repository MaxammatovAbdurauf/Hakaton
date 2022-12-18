using System.ComponentModel.DataAnnotations;

namespace HakatonApi.Models
{
    public class SignUpUserDto
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

        [Required]
        public string? Email { get; set; }

        public IFormFile? Avatar { get; set; }
    }
}
