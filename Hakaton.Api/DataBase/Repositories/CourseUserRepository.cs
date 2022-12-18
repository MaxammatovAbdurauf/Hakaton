using HakatonApi.Entities;

namespace HakatonApi.DataBase.Repositories;

public class CourseUserRepository : GenericRepository<CourseUser>, ICourseUserRepository
{
    public CourseUserRepository(AppDbContext context) : base (context) { }
}
