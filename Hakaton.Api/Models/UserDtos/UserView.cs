namespace HakatonApi.Models.UserDtos;

public class UserView
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
    public FormFile? UserImage { get; set; }
}