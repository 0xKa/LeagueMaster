using AutoMapper;
using LeagueMaster.Application.DTOs.User;
using LeagueMaster.Domain.Entities;

namespace LeagueMaster.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

            CreateMap<UserInputDto, User>();

        }
    }
}