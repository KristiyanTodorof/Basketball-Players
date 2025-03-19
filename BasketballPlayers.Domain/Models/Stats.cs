using BasketballPlayers.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Domain.Models
{
    public class Stats : BaseEntity<Guid>
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
        public double Steals {  get; set; }
        public double Blocks { get; set; }
        public double Turnovers { get; set; }
        public bool IsPlayedFiveYears { get; set; }

        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
