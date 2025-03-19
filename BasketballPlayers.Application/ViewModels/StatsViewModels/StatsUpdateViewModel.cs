using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.ViewModels.StatsViewModels
{
    public class StatsUpdateViewModel : StatsCreateViewModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
