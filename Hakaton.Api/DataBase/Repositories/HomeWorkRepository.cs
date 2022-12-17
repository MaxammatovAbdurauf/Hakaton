using HakatonApi.Entities;

namespace HakatonApi.DataBase.Repositories;

public class HomeWorkRepository : GenericRepository<Course>, ICourseRepository
{
    public HomeWorkRepository(AppDbContext context) : base(context) { }
}