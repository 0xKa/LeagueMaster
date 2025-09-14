using AutoMapper;
using LeagueMaster.Application.DTOs.Players;
using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Mappings
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDto>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.ToString()));

            CreateMap<PlayerInputDto, Player>();
        }
    }
}