using BasketballPlayers.Application.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.ViewModels.PlayerViewModels
{
    public class PlayerViewModel : BaseViewModel<Guid>
    {
        public string Name { get; set; }

    }
}
