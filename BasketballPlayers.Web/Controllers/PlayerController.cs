using BasketballPlayers.Application.Contracts;
using BasketballPlayers.Application.ViewModels.PlayerViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BasketballPlayers.Web.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        // GET: Player
        public async Task<IActionResult> Index()
        {
            var players = await _playerService.GetAllPlayersAsync();
            return View(players);
        }

        // GET: Player/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var playerDetails = await _playerService.GetPlayerDetailsAsync(id);
            if (playerDetails == null)
            {
                return NotFound();
            }
            return View(playerDetails);
        }

        // GET: Player/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlayerCreateViewModel playerViewModel)
        {
            if (ModelState.IsValid)
            {
                await _playerService.CreatePlayerAsync(playerViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(playerViewModel);
        }

        // GET: Player/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var player = await _playerService.GetPlayerDetailsAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            var updateViewModel = new PlayerUpdateViewModel
            {
                Id = player.Id,
                Name = player.Name,
                
            };

            return View(updateViewModel);
        }

        // POST: Player/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PlayerUpdateViewModel playerViewModel)
        {
            if (id != playerViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _playerService.UpdatePlayerAsync(playerViewModel);
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(playerViewModel);
        }

        // GET: Player/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var player = await _playerService.GetPlayerDetailsAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _playerService.DeletePlayerAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}