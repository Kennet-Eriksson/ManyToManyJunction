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
    public class ShowPlayersModel : PageModel
    {
        private readonly EgetTest03Context _context;

        public ShowPlayersModel(EgetTest03Context context)
        {
            _context = context;
        }

        public IList<Player> Players { get; set; }

        public async Task OnGetAsync()
        {
            Players = await _context.Player.ToListAsync().ConfigureAwait(true);
        }

        // -----------------------------------------------------------------------------------------------------------------------------

        [BindProperty]
        public int Pid { get; set; }

        public IActionResult OnPost()
        {
            return RedirectToPage("./SP", new { Pid });
        }
    }
}