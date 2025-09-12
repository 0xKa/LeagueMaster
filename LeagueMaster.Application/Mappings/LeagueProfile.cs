using AutoMapper;
using LeagueMaster.Application.DTOs.Leagues;
using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Mappings
{
    public class LeagueProfile : Profile
    {
        public LeagueProfile()
        {
            CreateMap<League, LeagueDto>();

            CreateMap<LeagueInputDto, League>();
                //.ForMember(dest => dest.Id, opt => opt.Ignore())
                //.ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                //.ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}