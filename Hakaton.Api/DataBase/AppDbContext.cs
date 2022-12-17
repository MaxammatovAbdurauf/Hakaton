using HakatonApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = HakatonApi.Entities.Task;

namespace HakatonApi.DataBase;

public class AppDbContext : IdentityDbContext<User,Role,Guid>
{
    public DbSet<Result>? Results { get; set; }
    public DbSet<Task>? Tasks { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<UserCourse> UserCourses { get; set; }
    public AppDbContext(DbContextOptions options) : base(options) { }
}