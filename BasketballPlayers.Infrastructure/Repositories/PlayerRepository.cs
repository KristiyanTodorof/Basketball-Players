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
    public class PlayerRepository : Repository<Player, Guid>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerator<Player>> GetAllPlayersWithStatsAsync()
        {
            return (IEnumerator<Player>)await _context.Players
            .Include(p => p.Stats)
            .ToListAsync();
        }

        public async Task<Player> GetPlayerWithStatsAsync(Guid id)
        {
            return await _context.Players
            .Include(p => p.Stats)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
