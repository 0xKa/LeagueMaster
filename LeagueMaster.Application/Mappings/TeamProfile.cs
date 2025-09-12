using AutoMapper;
using LeagueMaster.Application.DTOs.Team;
using LeagueMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeagueMaster.Application.Mappings
{
    public class TeamProfile : Profile
    {
        public TeamProfile() {

            CreateMap<Team, TeamDto>();
            CreateMap<TeamInputDto, Team>();

        }



    }
}
