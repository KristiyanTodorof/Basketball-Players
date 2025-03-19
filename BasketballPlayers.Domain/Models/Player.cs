using BasketballPlayers.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Domain.Models
{
    public class Player : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public Stats Stats { get; set; }
    }
}
