using BasketballPlayers.Application.Contracts;
using BasketballPlayers.Application.ViewModels.StatsViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BasketballPlayers.Web.Controllers
{
    public class StatsController : Controller
    {
        private readonly IStatsService _statsService;
        private readonly IPlayerService _playerService;

        public StatsController(IStatsService statsService, IPlayerService playerService)
        {
            _statsService = statsService;
            _playerService = playerService;
        }

        // GET: Stats/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var stats = await _statsService.GetStatsByIdAsync(id);
            if (stats == null)
            {
                return NotFound();
            }
            return View(stats);
        }

        // GET: Stats/PlayerStats/5
        public async Task<IActionResult> PlayerStats(Guid playerId)
        {
            var stats = await _statsService.GetStatsByPlayerIdAsync(playerId);
            if (stats == null)
            {
                return NotFound();
            }

            // Get player details to display player name
            var player = await _playerService.GetPlayerDetailsAsync(playerId);
            ViewBag.PlayerName = $"{player.Name}";
            ViewBag.PlayerId = playerId;

            return View(stats);
        }

        // GET: Stats/Create
        public async Task<IActionResult> Create(Guid playerId)
        {
            var player = await _playerService.GetPlayerDetailsAsync(playerId);
            if (player == null)
            {
                return NotFound();
            }

            ViewBag.PlayerName = $"{player.Name}";

            var viewModel = new StatsCreateViewModel
            {
                PlayerId = playerId
            };

            return View(viewModel);
        }

        // POST: Stats/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StatsCreateViewModel statsViewModel)
        {
            if (ModelState.IsValid)
            {
                await _statsService.CreateStatsAsync(statsViewModel);
                return RedirectToAction("PlayerStats", new { playerId = statsViewModel.PlayerId });
            }

            var player = await _playerService.GetPlayerDetailsAsync(statsViewModel.PlayerId);
            ViewBag.PlayerName = $"{player.Name}";

            return View(statsViewModel);
        }

        // GET: Stats/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var stats = await _statsService.GetStatsByIdAsync(id);
            if (stats == null)
            {
                return NotFound();
            }

            var updateViewModel = new StatsUpdateViewModel
            {
                Id = stats.Id,
                PlayerId = stats.PlayerId,
                GamesPlayed = stats.GamesPlayed,
                Minutes = stats.Minutes,
                PointsScored = stats.PointsScored,
                FieldGoals = stats.FieldGoals,
                FieldGoalsAttempted = stats.FieldGoalsAttempted,
                ThreePointFieldGoals = stats.ThreePointFieldGoals,
                ThreePointFieldGoalsAttempted = stats.ThreePointFieldGoalsAttempted,
                FreeThrowsMade = stats.FreeThrowsMade,
                FreeThrowsAttempted = stats.FreeThrowsAttempted,
                OffensiveRebounds = stats.OffensiveRebounds,
                DefensiveRebounds = stats.DefensiveRebounds,
                Assists = stats.Assists,
                Steals = stats.Steals,
                Blocks = stats.Blocks,
                Turnovers = stats.Turnovers,
                IsPlayedFiveYears = stats.IsPlayedFiveYears,
            };

            var player = await _playerService.GetPlayerDetailsAsync(stats.PlayerId);
            ViewBag.PlayerName = $"{player.Name}";

            return View(updateViewModel);
        }

        // POST: Stats/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, StatsUpdateViewModel statsViewModel)
        {
            if (id != statsViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _statsService.UpdateStatsAsync(statsViewModel);
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
                return RedirectToAction("PlayerStats", new { playerId = statsViewModel.PlayerId });
            }

            var player = await _playerService.GetPlayerDetailsAsync(statsViewModel.PlayerId);
            ViewBag.PlayerName = $"{player.Name}";

            return View(statsViewModel);
        }
    }
}