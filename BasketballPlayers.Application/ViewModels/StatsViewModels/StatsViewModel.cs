using BasketballPlayers.Application.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.ViewModels.StatsViewModels
{
    public class StatsViewModel : BaseViewModel<Guid>
    {
        public byte GamesPlayed { get; set; }
        public double Minutes { get; set; }
        public double PointsScored { get; set; }
        public double FieldGoals { get; set; }
        public double FieldGoalsAttempted { get; set; }
        public double ThreePointFieldGoals { get; set; }
        public double ThreePointFieldGoalsAttempted { get; set; }
        public double FreeThrowsMade { get; set; }
        public double FreeThrowsAttempted { get; set; }
        public double OffensiveRebounds { get; set; }
        public double DefensiveRebounds { get; set; }
        public double Assists { get; set; }
        public double Steals { get; set; }
        public double Blocks { get; set; }
        public double Turnovers { get; set; }
        public bool IsPlayedFiveYears { get; set; }
        public Guid PlayerId { get; set; }

        public double FieldGoalPercentage => FieldGoalsAttempted > 0 ? Math.Round(FieldGoals / FieldGoalsAttempted * 100, 1) : 0;
        public double ThreePointPercentage => ThreePointFieldGoalsAttempted > 0 ? Math.Round(ThreePointFieldGoals / ThreePointFieldGoalsAttempted * 100, 1) : 0;
        public double FreeThrowPercentage => FreeThrowsAttempted > 0 ? Math.Round(FreeThrowsMade / FreeThrowsAttempted * 100, 1) : 0;
        public double TotalRebounds => OffensiveRebounds + DefensiveRebounds;
        public double PointsPerGame => GamesPlayed > 0 ? Math.Round(PointsScored / GamesPlayed, 1) : 0;
        public double AssistsPerGame => GamesPlayed > 0 ? Math.Round(Assists / GamesPlayed, 1) : 0;
        public double ReboundsPerGame => GamesPlayed > 0 ? Math.Round(TotalRebounds / GamesPlayed, 1) : 0;
    }
}
