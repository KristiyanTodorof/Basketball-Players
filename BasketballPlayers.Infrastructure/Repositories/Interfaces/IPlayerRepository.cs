using BasketballPlayers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Infrastructure.Repositories.Interfaces
{
    public interface IPlayerRepository : IRepository<Player, Guid>
    {
        Task<Player> GetPlayerWithStatsAsync(Guid id);
        Task<IEnumerator<Player>> GetAllPlayersWithStatsAsync();
    }
}
