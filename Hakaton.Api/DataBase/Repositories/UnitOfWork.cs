using HakatonApi.Extensions.AddServiceFromAttribute;

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

    private IUserCourseRepository? _userCourseRepository;
    public IUserCourseRepository UserCourseRepository
    {
        get
        {
            if (_userCourseRepository is null) 
                _userCourseRepository = new UserCourseRepository(context);

            return (_userCourseRepository);
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
