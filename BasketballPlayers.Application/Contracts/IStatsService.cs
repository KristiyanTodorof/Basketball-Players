using BasketballPlayers.Application.ViewModels.StatsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.Contracts
{
    public interface IStatsService
    {
        Task<StatsViewModel> GetStatsByIdAsync(Guid id);
        Task<StatsViewModel> GetStatsByPlayerIdAsync(Guid playerId);
        Task<StatsViewModel> CreateStatsAsync(StatsCreateViewModel statsViewModel);
        Task UpdateStatsAsync(StatsUpdateViewModel statsViewModel);
    }
}
