using HakatonApi.Entities;

namespace HakatonApi.DataBase.Repositories;

public class UserCourseRepository : GenericRepository<UserCourse>, IUserCourseRepository
{
    public UserCourseRepository(AppDbContext context) : base (context) { }
}
