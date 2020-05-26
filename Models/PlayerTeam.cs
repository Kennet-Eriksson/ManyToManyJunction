using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgetTest03.Models
{
    public class PlayerTeam
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
