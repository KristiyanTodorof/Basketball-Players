using AutoMapper;
using BasketballPlayers.Application.Contracts;
using BasketballPlayers.Application.ViewModels.PlayerViewModels;
using BasketballPlayers.Domain.Models;
using BasketballPlayers.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            this._playerRepository = playerRepository;
            this._mapper = mapper;
        }
        public async Task<PlayerViewModel> CreatePlayerAsync(PlayerCreateViewModel playerViewModel)
        {
            var player = _mapper.Map<Player>(playerViewModel);
            player.Id = Guid.NewGuid();

            await _playerRepository.AddAsync(player);
            await _playerRepository.SaveChangesAsync();

            return _mapper.Map<PlayerViewModel>(player);
        }

        public async Task DeletePlayerAsync(Guid id)
        {
            await _playerRepository.DeleteAsync(id);
            await _playerRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<PlayerViewModel>> GetAllPlayersAsync()
        {
            var players = await _playerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlayerViewModel>>(players);
        }

        public async Task<PlayerDetailViewModel> GetPlayerDetailsAsync(Guid id)
        {
            var player = await _playerRepository.GetPlayerWithStatsAsync(id);
            return _mapper.Map<PlayerDetailViewModel>(player);
        }

        public async Task UpdatePlayerAsync(PlayerUpdateViewModel playerViewModel)
        {
            var player = await _playerRepository.GetByIdAsync(playerViewModel.Id);
            if (player == null) 
            {
                throw new KeyNotFoundException($"Player with ID {playerViewModel.Id} not found");
            }
            _mapper.Map(playerViewModel, player);

            await _playerRepository.UpdateAsync(player);
            await _playerRepository.SaveChangesAsync();
        }
    }
}
