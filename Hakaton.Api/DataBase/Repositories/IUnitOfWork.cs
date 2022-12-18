
namespace HakatonApi.DataBase.Repositories;

public interface IUnitOfWork
{
    ICourseRepository CourseRepository { get;}
    IUserCourseRepository UserCourseRepository { get;}
    IHomeWorkRepository HomeWorkRepository { get; }
    int Save();
    Task<int> SaveAsync();
}