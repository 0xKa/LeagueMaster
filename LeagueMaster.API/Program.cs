using LeagueMaster.Application.Interfaces;
using LeagueMaster.Application.Services;
using LeagueMaster.Infrastructure.Persistence;
using LeagueMaster.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB 
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LeagueMasterDbContext>(opt => opt.UseSqlServer(conn));

// DI: repository (Infrastructure) and service (Application)
builder.Services.AddScoped<ILeagueRepository, LeagueRepository>();
builder.Services.AddScoped<ILeagueService, LeagueService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();