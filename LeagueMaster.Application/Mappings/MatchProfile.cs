using AutoMapper;
using LeagueMaster.Application.DTOs.Matches;
using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Mappings
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<Match, MatchDto>()
                .ForMember(dest => dest.HomeTeamName, opt => opt.MapFrom(src => src.HomeTeam != null ? src.HomeTeam.Name : string.Empty))
                .ForMember(dest => dest.AwayTeamName, opt => opt.MapFrom(src => src.AwayTeam != null ? src.AwayTeam.Name : string.Empty));

            CreateMap<MatchInputDto, Match>();
        }
    }
}