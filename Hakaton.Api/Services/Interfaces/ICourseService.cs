using HakatonApi.DataBase.Repositories;
using HakatonApi.Dtos.CourseDtos;
using HakatonApi.Entities;
using Task = System.Threading.Tasks.Task;

namespace HakatonApi.Services.Interfaces;

public interface ICourseService 
{
    Task<CourseView> CreateCourse(Guid userId, GetCourseDto createCource);
    Task<CourseView> GetCourseById(Guid courseId);
    Task<List<CourseView>> GetCourses();
    Task UpdateCourse(Guid courseId, UpdateCourseDto updateCourceDto);
    Task DeleteCourse(Guid courseId);
    Task JointoCourse(Guid courseId, Guid userId);
}