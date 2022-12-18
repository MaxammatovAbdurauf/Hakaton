
namespace HakatonApi.DataBase.Repositories;

public interface IUnitOfWork
{
    ICourseRepository CourseRepository { get;}
    ICourseUserRepository CourseUserRepository { get;}
    IUserRepository UserRepository { get;}
    ITaskCommentRepository TaskCommentRepository { get;}
    IHomeWorkRepository HomeWorkRepository { get; }
    int Save();
    Task<int> SaveAsync();
}