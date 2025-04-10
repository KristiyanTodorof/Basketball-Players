﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.ViewModels.PlayerViewModels
{
    public class PlayerCreateViewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
