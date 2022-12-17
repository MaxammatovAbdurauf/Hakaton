using Microsoft.EntityFrameworkCore;
using HakatonApi.Extensions;
using HakatonApi.Extensions.AddServiceFromAttribute;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services._AddCors();
builder.Services._AddDbContext(builder.Configuration.GetConnectionString("PostGres"));
builder.Services._AddIdentity();
builder._AddSerilogWithConfig();
builder.Services._AddServicesViaAttribute();    

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();