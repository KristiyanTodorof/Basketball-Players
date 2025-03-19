using AutoMapper;
using BasketballPlayers.Application.ViewModels;
using BasketballPlayers.Application.ViewModels.PlayerViewModels;
using BasketballPlayers.Application.ViewModels.StatsViewModels;
using BasketballPlayers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.Services.Mapping
{
    public class BasketballMappingProfile : Profile
    {
        public BasketballMappingProfile()
        {
            CreateMap<Player, PlayerViewModel>();
            CreateMap<Player, PlayerDetailViewModel>();
            CreateMap<PlayerCreateViewModel, Player>();
            CreateMap<PlayerUpdateViewModel, Player>();

            CreateMap<Stats, StatsViewModel>();
            CreateMap<StatsCreateViewModel, Stats>();
            CreateMap<StatsUpdateViewModel, Stats>();

            CreateMap<BasketballPlayersViewModel, Player>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<BasketballPlayersViewModel, Stats>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
        }
    }
}
