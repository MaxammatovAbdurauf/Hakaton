using HakatonApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HomeWork = HakatonApi.Entities.HomeWork;

namespace HakatonApi.DataBase;

public class AppDbContext : IdentityDbContext<User,Role,Guid>
{
    public DbSet<Result>? Results { get; set; }
    public DbSet<HomeWork>? HomeWorks { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<UserCourse> UserCourses { get; set; }
    public AppDbContext(DbContextOptions options) : base(options) { }
}