using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Application.ViewModels
{
    public class BasketballPlayersViewModel
    {
        [Name("Name")]
        public string Name { get; set; }
        [Name("GP")]
        public byte GamesPlayed { get; set; }
        [Name("MIN")]
        public double Minutes { get; set; }
        [Name("PTS")]
        public double PointsScored { get; set; }
        [Name("FGS")]
        public double FieldGoals { get; set; }
        [Name("FGA")]
        public double FieldGoalsAttempted { get; set; }
        [Name("3PM")]
        public double ThreePointFieldGoals { get; set; }
        [Name("3PA")]
        public double ThreePointFieldGoalsAttempted { get; set; }
        [Name("FTM")]
        public double FreeThrowsMade { get; set; }
        [Name("FTA")]
        public double FreeThrowsAttempted { get; set; }
        [Name("OREB")]
        public double OffensiveRebounds { get; set; }
        [Name("DREB")]
        public double DefensiveRebounds { get; set; }
        [Name("AST")]
        public double Assists { get; set; }
        [Name("STL")]
        public double Steals { get; set; }
        [Name("BLK")]
        public double Blocks { get; set; }
        [Name("TOV")]
        public double Turnovers { get; set; }
        [Name("5Yrs")]
        public bool IsPlayedFiveYears { get; set; }
    }
}
