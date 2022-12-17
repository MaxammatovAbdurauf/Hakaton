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

    public async Task<Guid> CreateCourse(Guid userId, GetCourseDto createCource)
    {
        var key = Guid.NewGuid();
        var courseId = Guid.NewGuid();
        var course = new Course
        {
            Id = courseId,
            CourseName = createCource.CourseName,
            Key = key,

            UserCourseList = new List<UserCourse>
            {
                new UserCourse
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

    public async Task UpdateCourse(Guid courseId, UpdateCourseDto updateCourceDto)
    {
        var course = context.CourseRepository.GetById(courseId);
        if (course is null) return;

        course.CourseName = updateCourceDto.CourseName;
        context.Save();
    }

    public async Task DeleteCourse(Guid courseId)
    {
        var course = context.CourseRepository.GetById(courseId);
        if (course is null) return;
        await context.CourseRepository.Remove(course);
        context.Save();
    }

    public async Task JointoCourse(Guid courseId, Guid userId)
    {
        var course = context.CourseRepository.GetById(courseId);
        if (course is null) return;

        if (course.UserCourseList!.Any(u => u.UserId == userId)) return;

        course.UserCourseList ??= new List<UserCourse>();
        var userCourse = new UserCourse
        {
            UserId = userId,
            CourseId = course.Id,
            IsAdmin = false
        };
        // await context.CourseRepository.AddAsync(userCourse);
        context.Save();
    }
}