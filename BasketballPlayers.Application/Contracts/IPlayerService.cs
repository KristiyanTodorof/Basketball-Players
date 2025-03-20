using BasketballPlayers.Application.ViewModels.PlayerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.Contracts
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerViewModel>> GetAllPlayersAsync();
        Task<PlayerDetailViewModel> GetPlayerDetailsAsync(Guid id);
        Task<PlayerViewModel> CreatePlayerAsync(PlayerCreateViewModel playerViewModel);
        Task UpdatePlayerAsync(PlayerUpdateViewModel playerViewModel);
        Task DeletePlayerAsync(Guid id);
    }
}
