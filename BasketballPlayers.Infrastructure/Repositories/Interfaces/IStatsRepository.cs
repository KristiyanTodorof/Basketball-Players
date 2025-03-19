using BasketballPlayers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Infrastructure.Repositories.Interfaces
{
    public interface IStatsRepository : IRepository<Stats, Guid>
    {
        Task<Stats> GetStatsByPlayerIdAsync(Guid playerId);
    }
}
