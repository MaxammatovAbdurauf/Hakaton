
namespace HakatonApi.DataBase.Repositories;

public interface IUnitOfWork
{
    ICourseRepository CourseRepository { get;}
    IUserCourseRepository UserCourseRepository { get;}
    int Save();
    Task<int> SaveAsync();
}