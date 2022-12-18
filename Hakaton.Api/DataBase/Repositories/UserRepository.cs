using HakatonApi.Entities;
using HakatonApi.DataBase.Repositories;

namespace HakatonApi.DataBase.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base (context) { }
}