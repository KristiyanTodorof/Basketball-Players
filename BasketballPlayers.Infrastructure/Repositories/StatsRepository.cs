using BasketballPlayers.Domain.Models;
using BasketballPlayers.Infrastructure.Data;
using BasketballPlayers.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Infrastructure.Repositories
{
    public class StatsRepository : Repository<Stats, Guid>, IStatsRepository
    {
        public StatsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Stats> GetStatsByPlayerIdAsync(Guid playerId)
        {
            return await _context.Stats
            .FirstOrDefaultAsync(s => s.PlayerId == playerId);
        }
    }
}
