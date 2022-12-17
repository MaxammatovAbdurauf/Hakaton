using Microsoft.EntityFrameworkCore;
using HakatonApi.Entities;
using Task = HakatonApi.Entities.Task;
namespace HakatonApi.DataBase;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public AppDbContext(DbContextOptions options) : base(options) { }
}