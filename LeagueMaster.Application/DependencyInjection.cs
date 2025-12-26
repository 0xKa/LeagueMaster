using LeagueMaster.Application.Interfaces.Services;
using LeagueMaster.Application.Mappings;
using LeagueMaster.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueMaster.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // assembly scanning to finds all automapper profiles
            services.AddAutoMapper(cfg => { cfg.AddMaps(typeof(LeagueProfile).Assembly); });

            //services
            services.AddScoped<ILeagueService, LeagueService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<ICoachService, CoachService>();
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
