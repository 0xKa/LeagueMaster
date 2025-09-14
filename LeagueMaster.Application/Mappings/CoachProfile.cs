using AutoMapper;
using LeagueMaster.Application.DTOs.Coaches;
using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Mappings
{
    public class CoachProfile : Profile
    {
        public CoachProfile()
        {
            CreateMap<Coach, CoachDto>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name));

            CreateMap<CoachInputDto, Coach>();
        }
    }
}