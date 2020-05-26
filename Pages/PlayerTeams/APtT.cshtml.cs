using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgetTest03.Data;
using EgetTest03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EgetTest03.Pages.PlayerTeams
{
    public class APtTModel : PageModel
    {
        private readonly EgetTest03Context _context;

        public APtTModel(EgetTest03Context context)
        {
            _context = context;
        }
        public IList<Player> Players { get; set; }              // All Players 
        public List<Player> PiT { get; set; }                  // Players in the team
        public IList<int> PlayerIds { get; set; }
        public IList<PlayerTeam> PlayerTeams { get; set; }
        public Team Team { get; set; }

        public int TeamId;

        public async Task OnGetAsync(int Tid)
        {
            PiT = new List<Player>();
            Players = await _context.Player.ToListAsync().ConfigureAwait(true);
            Team = await _context.Team.Where(t => t.Id == Tid).FirstOrDefaultAsync().ConfigureAwait(true);
            var DbSelection = await _context.Player                                         // 
                .Include(p => p.PlayerTeams)
                .ThenInclude(p => p.Team)
                .ToListAsync().ConfigureAwait(true);
            foreach (var dbs in DbSelection)
            {
                foreach (var item in dbs.PlayerTeams.Where(t => t.TeamId == Tid).Select(p => p.Player))
                {
                    PiT.Add(item);
                }
            }
            TeamId = Tid;
        }

        // --------------------------------------------------------------------------------------------------------------------------------------

        [BindProperty]
        public int PTTId { get; set; }            // The id of the player to be added to the team

        [BindProperty]
        public int Tid { get; set; }               // The id of the team

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Player player = await _context.Player.Where(p => p.Id == PTTId).FirstOrDefaultAsync().ConfigureAwait(true);
            Team team = await _context.Team.Where(t => t.Id == Tid).FirstOrDefaultAsync().ConfigureAwait(true);

            PlayerTeam playerTeam = new PlayerTeam()
            {
                PlayerId = PTTId,
                Player = player,
                TeamId = Tid,
                Team = team
            };

            team.PlayerTeams.Add(playerTeam);

            _context.Team.Update(team);

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(true);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(Team.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("APtT", new { Tid });
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.Id == id);
        }
    }
}