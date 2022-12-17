namespace HakatonApi.DataBase.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;

    private ICourseRepository _courseRepository;
    public ICourseRepository courseRepository
    {
        get
        {
            if (_courseRepository is null) _courseRepository = new CourseRepository(context);
            return _courseRepository;
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
}
