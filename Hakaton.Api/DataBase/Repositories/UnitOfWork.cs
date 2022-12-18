using HakatonApi.Extensions.AddServiceFromAttribute;
using System.Linq.Expressions;

namespace HakatonApi.DataBase.Repositories;

[Scoped]
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;

    private ICourseRepository? _courseRepository;
    public ICourseRepository CourseRepository
    {
        get
        {
            if (_courseRepository is null) _courseRepository = new CourseRepository(context);
            return _courseRepository;
        }
    }
    private IHomeWorkRepository _homeWorkRepository;
    public IHomeWorkRepository HomeWorkRepository
    {
        get
        {
            if (_homeWorkRepository is null) _homeWorkRepository = new HomeWorkRepository(context);
            return _homeWorkRepository;
        }
    }

    private ICourseUserRepository? _userCourseRepository;
    public ICourseUserRepository CourseUserRepository
    {
        get
        {
            if (_userCourseRepository is null) 
                _userCourseRepository = new CourseUserRepository(context);

            return (_userCourseRepository);
        }
    }

    private IUserRepository _userRepository;
    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository is null) _userRepository =  new UserRepository(context);
            return _userRepository;
        }
    }

    public UnitOfWork(AppDbContext _context)
    {
        context = _context;
    }

    public int Save() => context.SaveChanges();

    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }

    public Task<int> SaveAsync() => context.SaveChangesAsync();
}
