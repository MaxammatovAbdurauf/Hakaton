using HakatonApi.Extensions;
using HakatonApi.Extensions.AddServiceFromAttribute;
using HakatonApi.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services._AddCors();
builder.Services._AddDbContext(builder.Configuration.GetConnectionString("PostGres"));
builder.Services._AddIdentity();
builder._AddSerilogWithConfig();
builder.Services._AddServicesViaAttribute();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

if (app.Services.GetRequiredService<HttpContextAccessor>() != null)
{
    HttpContextHelper.Accessor = app.Services.GetRequiredService<HttpContextAccessor>();
}
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();