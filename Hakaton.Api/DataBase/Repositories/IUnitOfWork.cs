
namespace HakatonApi.DataBase.Repositories;

public interface IUnitOfWork
{
    ICourseRepository CourseRepository { get;}
    ICourseUserRepository CourseUserRepository { get;}
    IUserRepository UserRepository { get;}

    IHomeWorkRepository HomeWorkRepository { get; }
    int Save();
    Task<int> SaveAsync();
}