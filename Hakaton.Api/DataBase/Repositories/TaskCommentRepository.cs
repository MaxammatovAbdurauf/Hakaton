using HakatonApi.Entities;
using HakatonApi.Extensions.AddServiceFromAttribute;

namespace HakatonApi.DataBase.Repositories;

[Scoped]
public class TaskCommentRepository : GenericRepository<Comment>, ITaskCommentRepository
{
    public TaskCommentRepository(AppDbContext context) : base(context)
    {
    }
}

