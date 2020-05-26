using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgetTest03.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PlayerTeam> PlayerTeams { get; } = new List<PlayerTeam>();

    }
}
