using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballPlayers.Application.ViewModels.StatsViewModels;

namespace BasketballPlayers.Application.ViewModels.PlayerViewModels
{
    public class PlayerDetailViewModel : PlayerViewModel
    {
        public StatsViewModel Stats { get; set; }
    }
}
