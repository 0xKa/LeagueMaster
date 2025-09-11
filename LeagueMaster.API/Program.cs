using LeagueMaster.Application.Interfaces;
using LeagueMaster.Application.Services;
using LeagueMaster.Infrastructure.Persistence;
using LeagueMaster.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // DB 
    var conn = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<LeagueMasterDbContext>(option => 
        option.UseSqlServer(conn)
              // console logging ... might use serilog later
              .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
              .EnableSensitiveDataLogging()); 

    // DI: repository (Infrastructure) and service (Application)
    builder.Services.AddScoped<ILeagueRepository, LeagueRepository>();
    builder.Services.AddScoped<ILeagueService, LeagueService>();

}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapScalarApiReference(options =>
        {
            options.WithTitle("League Master API")
                   .WithTheme(ScalarTheme.DeepSpace)
                   .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
                   .WithOpenApiRoutePattern("/swagger/{documentName}/swagger.json");
        });
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}