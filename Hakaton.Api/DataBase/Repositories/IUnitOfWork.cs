
namespace HakatonApi.DataBase.Repositories;

public interface IUnitOfWork
{
    ICourseRepository CourseRepository { get;}
    int Save();
}