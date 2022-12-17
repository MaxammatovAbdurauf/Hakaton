<<<<<<< HEAD
=======
using HakatonApi.DataBase;
using HakatonApi.Entities;
using HakatonApi.Services;
using HakatonApi.Services.Interfaces;
>>>>>>> 01054ac2342f8dbf66211f4249d3e56c4f3cc11b
using Microsoft.EntityFrameworkCore;
using HakatonApi.Extensions;
using HakatonApi.Extensions.AddServiceFromAttribute;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFileHelperService, FileHelperService>();

<<<<<<< HEAD
builder.Services._AddCors();
builder.Services._AddDbContext(builder.Configuration.GetConnectionString("PostGres"));
builder.Services._AddIdentity();
builder._AddSerilogWithConfig();
builder.Services._AddServicesViaAttribute();    
=======
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostGres"));
});

builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
})
    .AddEntityFrameworkStores<AppDbContext>();




>>>>>>> 01054ac2342f8dbf66211f4249d3e56c4f3cc11b

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();