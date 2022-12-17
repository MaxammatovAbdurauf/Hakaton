using HakatonApi.Entities;

namespace HakatonApi.DataBase.Repositories;

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    public CourseRepository (AppDbContext context) : base (context) { }
}