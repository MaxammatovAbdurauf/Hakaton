using HakatonApi.Models.CourseDtos;

namespace HakatonApi.Services.Interfaces;

public interface ICourseService
{
    Task<Guid> CreateCourse(Guid userId, GetCourseDto createCource);
    Task<CourseView> GetCourseById(Guid courseId);
    Task<List<CourseView>> GetCourses();
    Task UpdateCourse(Guid courseId, UpdateCourseDto updateCourceDto);
    Task DeleteCourse(Guid courseId);
    Task JointoCourse(Guid courseId, Guid userId);
}