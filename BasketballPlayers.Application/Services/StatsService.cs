using AutoMapper;
using BasketballPlayers.Application.Contracts;
using BasketballPlayers.Application.ViewModels.StatsViewModels;
using BasketballPlayers.Domain.Models;
using BasketballPlayers.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.Services
{
    public class StatsService : IStatsService
    {
      private readonly IStatsRepository _statsRepository;
        private readonly IMapper _mapper;

        public StatsService(IStatsRepository statsRepository, IMapper mapper)
        {
            this._statsRepository = statsRepository;
            this._mapper = mapper;
        }
        public async Task<StatsViewModel> CreateStatsAsync(StatsCreateViewModel statsViewModel)
        {
            var stats = _mapper.Map<Stats>(statsViewModel);
            stats.Id = Guid.NewGuid();
            await _statsRepository.AddAsync(stats);
            await _statsRepository.SaveChangesAsync();

            return _mapper.Map<StatsViewModel>(stats);
        }

        public async Task<StatsViewModel> GetStatsByIdAsync(Guid id)
        {
            var stats = await _statsRepository.GetByIdAsync(id);
            return _mapper.Map<StatsViewModel>(stats);
        }

        public async Task<StatsViewModel> GetStatsByPlayerIdAsync(Guid playerId)
        {
            var stats = await _statsRepository.GetStatsByPlayerIdAsync(playerId);
            return _mapper.Map<StatsViewModel>(stats);
        }

        public async Task UpdateStatsAsync(StatsUpdateViewModel statsViewModel)
        {
            var stats = await _statsRepository.GetByIdAsync(statsViewModel.Id);
            if (stats == null)
                throw new KeyNotFoundException($"Stats with ID {statsViewModel.Id} not found");

            _mapper.Map(statsViewModel, stats);

            await _statsRepository.UpdateAsync(stats);
            await _statsRepository.SaveChangesAsync();
        }
    }
}
