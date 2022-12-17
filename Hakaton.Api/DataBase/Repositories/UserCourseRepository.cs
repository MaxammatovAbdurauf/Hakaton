using HakatonApi.Entities;

namespace HakatonApi.DataBase.Repositories;

public class UserCourseRepository : GenericRepository<CourseUser>, IUserCourseRepository
{
    public UserCourseRepository(AppDbContext context) : base (context) { }
}
