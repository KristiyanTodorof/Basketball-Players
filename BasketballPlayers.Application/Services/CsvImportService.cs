using AutoMapper;
using BasketballPlayers.Application.Contracts;
using BasketballPlayers.Application.ViewModels;
using BasketballPlayers.Domain.Models;
using BasketballPlayers.Infrastructure.Repositories.Interfaces;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.Services
{
    public class CsvImportService : ICsvImportService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IStatsRepository _statsRepository;
        private readonly IMapper _mapper;

        public CsvImportService(
            IPlayerRepository playerRepository,
            IStatsRepository statsRepository,
            IMapper mapper)
        {
            _playerRepository = playerRepository;
            _statsRepository = statsRepository;
            _mapper = mapper;
        }

        public async Task ImportBasketballDataAsync(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<BasketballPlayersViewModel>().ToList();
                Dictionary<string, Player> playersDict = new Dictionary<string, Player>();

                foreach (var record in records)
                {
                    Player player;
                    if (!playersDict.ContainsKey(record.Name))
                    {
                        player = _mapper.Map<Player>(record);
                        playersDict.Add(record.Name, player);
                        await _playerRepository.AddAsync(player);
                        await _playerRepository.SaveChangesAsync();
                    }
                    else
                    {
                        player = playersDict[record.Name];
                    }

                    var stats = _mapper.Map<Stats>(record);
                    stats.PlayerId = player.Id;
                    await _statsRepository.AddAsync(stats);
                    await _statsRepository.SaveChangesAsync();

                    player.Stats = stats;
                    await _playerRepository.UpdateAsync(player);
                    await _playerRepository.SaveChangesAsync();
                }
            }
        }
    }
}
