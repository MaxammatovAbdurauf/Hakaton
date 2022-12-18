using HakatonApi.DataBase.Repositories;
using HakatonApi.Models.CourseDtos;
using HakatonApi.Entities;
using HakatonApi.Extensions.AddServiceFromAttribute;
using HakatonApi.Services.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace HakatonApi.Services;

[Scoped]
public class CourseService : ICourseService
{
    private readonly IUnitOfWork context;
    public CourseService(IUnitOfWork _context) => context = _context;

    public async Task<Guid> CreateCourse(Guid userId, CreateCourseDto createCource)
    {
        var key = Guid.NewGuid();
        var courseId = Guid.NewGuid();
        var course = new Course
        {
            Id = courseId,
            CourseName = createCource.CourseName,
            Key = key,

            CourseUsers = new List<CourseUser>
            {
                new CourseUser
                {
                    CourseId = courseId,
                    UserId = userId,
                    IsAdmin = true
                }
            }
        };

        await context.CourseRepository.AddAsync(course);
        await context.SaveAsync();
        return courseId;
    }

    public async Task<CourseView> GetCourseById(Guid courseId)
    {
        var course = context.CourseRepository.GetById(courseId);
        if (course is null) throw new Exception("Not Found");
        else return course.Adapt<CourseView>();
    }

    public async Task<List<CourseView>> GetCourses()
    {
        var courses = await context.CourseRepository.GetAll().ToListAsync();
        return courses.Select(course => course.Adapt<CourseView>()).ToList();
    }

    public async Task UpdateCourse(UpdateCourseDto updateCourceDto)
    {
        var course = context.CourseRepository.GetById(updateCourceDto.courseId);
        if (course is null) throw new Exception ("Not Found");

        course.CourseName = updateCourceDto.CourseName;
        await context.SaveAsync();
    }

    public async Task DeleteCourse(Guid courseId)
    {
        var course = context.CourseRepository.GetById(courseId);
        if (course is null) throw new Exception("Not Found");
        await context.CourseRepository.Remove(course);
        await context.SaveAsync();
    }

    public async Task JointoCourse(Guid courseId, Guid userId)
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

    public async Task<List<User>> GetCourseMembers(Guid courseId)
    {
        var course = context.CourseRepository.GetById(courseId);
        if (course is null) throw new Exception("Not Found");

        var members = course.CourseUsers!.Select(CourseUser => CourseUser.User).ToList();
        return members;
    }
}