using HakatonApi.DataBase.Repositories;
using HakatonApi.Entities;
using HakatonApi.Models.UserDtos;
using HakatonApi.Services.Interfaces;

namespace HakatonApi.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork context;
    public UserService (IUnitOfWork _context) => context = _context;

    public async Task JoinToCourse(Guid courseId, Guid userId)
    {
        var course = context.CourseRepository.GetById(courseId);

        if (course is null)
            throw new Exception("Not Found");

        if (course.CourseUsers!.Any(u => u.UserId == userId))
            throw new Exception("You have already joined");

        course.CourseUsers ??= new List<CourseUser>();
        var courseUser = new CourseUser
        {
            UserId = userId,
            CourseId = course.Id,
            IsAdmin = false
        };

        await context.CourseUserRepository.AddAsync(courseUser);
        await context.SaveAsync();
    }

    public void LeaveCourse(Guid userId, Guid courseId)
    {
        var courseUser =  context.CourseUserRepository.GetById(userId);
        if (courseUser is null) throw new Exception("you are not member of this course");
        context.CourseUserRepository.Remove(courseUser);
    }
}