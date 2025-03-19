using BasketballPlayers.Application.Contracts;
using BasketballPlayers.Application.ViewModels;
using BasketballPlayers.Domain.Models;
using BasketballPlayers.Infrastructure.Data;
using BasketballPlayers.Infrastructure.Repositories.Interfaces;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.Services
{
    public class FileReaderService : IFileReader
    {
        private readonly ApplicationDbContext _context;

        public FileReaderService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void ReadData()
        {
            using (var reader = new StreamReader("nba_data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<BasketballPlayersViewModel>();
                Dictionary<string, Player> players = new Dictionary<string, Player>();

                foreach (var record in records)
                {
                    // Get or create player
                    Player player;
                    if (!players.ContainsKey(record.Name))
                    {
                        player = new Player()
                        {
                            Name = record.Name
                        };
                        players.Add(record.Name, player);
                        _context.Players.Add(player);
                    }
                    else
                    {
                        player = players[record.Name];
                    }

                    // Create statistics and associate with player
                    Stats stats = new Stats()
                    {
                        PlayerId = player.Id, // This will be populated after SaveChanges
                        GamesPlayed = record.GamesPlayed,
                        Minutes = record.Minutes,
                        PointsScored = record.PointsScored,
                        FieldGoals = record.FieldGoals,
                        FieldGoalsAttempted = record.FieldGoalsAttempted,
                        ThreePointFieldGoals = record.ThreePointFieldGoals,
                        ThreePointFieldGoalsAttempted = record.ThreePointFieldGoalsAttempted,
                        FreeThrowsMade = record.FreeThrowsMade,
                        FreeThrowsAttempted = record.FreeThrowsAttempted,
                        OffensiveRebounds = record.OffensiveRebounds,
                        DefensiveRebounds = record.DefensiveRebounds,
                        Assists = record.Assists,
                        Steals = record.Steals,
                        Blocks = record.Blocks,
                        Turnovers = record.Turnovers,
                        IsPlayedFiveYears = record.IsPlayedFiveYears,
                        Player = player // Set the navigation property
                    };

                    _context.Stats.Add(stats);
                }

                _context.SaveChanges();
            }
        }
    }
}