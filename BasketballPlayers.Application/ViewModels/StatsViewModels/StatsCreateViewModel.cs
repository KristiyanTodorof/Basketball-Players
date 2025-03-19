using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.ViewModels.StatsViewModels
{
    public class StatsCreateViewModel
    {
        [Range(0, 255)]
        public byte GamesPlayed { get; set; }

        [Range(0, double.MaxValue)]
        public double Minutes { get; set; }

        [Range(0, double.MaxValue)]
        public double PointsScored { get; set; }

        [Range(0, double.MaxValue)]
        public double FieldGoals { get; set; }

        [Range(0, double.MaxValue)]
        public double FieldGoalsAttempted { get; set; }

        [Range(0, double.MaxValue)]
        public double ThreePointFieldGoals { get; set; }

        [Range(0, double.MaxValue)]
        public double ThreePointFieldGoalsAttempted { get; set; }

        [Range(0, double.MaxValue)]
        public double FreeThrowsMade { get; set; }

        [Range(0, double.MaxValue)]
        public double FreeThrowsAttempted { get; set; }

        [Range(0, double.MaxValue)]
        public double OffensiveRebounds { get; set; }

        [Range(0, double.MaxValue)]
        public double DefensiveRebounds { get; set; }

        [Range(0, double.MaxValue)]
        public double Assists { get; set; }

        [Range(0, double.MaxValue)]
        public double Steals { get; set; }

        [Range(0, double.MaxValue)]
        public double Blocks { get; set; }

        [Range(0, double.MaxValue)]
        public double Turnovers { get; set; }

        public bool IsPlayedFiveYears { get; set; }

        [Required]
        public Guid PlayerId { get; set; }
    }
}
