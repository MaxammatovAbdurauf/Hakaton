using HakatonApi.Extensions.AddServiceFromAttribute;

namespace HakatonApi.DataBase.Repositories;

[Scoped]
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;

    private ICourseRepository _courseRepository;
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
