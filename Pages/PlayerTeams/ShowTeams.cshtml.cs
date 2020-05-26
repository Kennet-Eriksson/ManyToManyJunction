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
    public class ShowTeamsModel : PageModel
    {
        private readonly EgetTest03Context _context;

        public ShowTeamsModel(EgetTest03Context context)
        {
            _context = context;
        }

        public IList<Team> Teams { get; set; }

        public async Task OnGetAsync()
        {
            Teams = await _context.Team.ToListAsync().ConfigureAwait(true);
        }

        // -----------------------------------------------------------------------------------------------------------------------------

        [BindProperty]
        public int Tid { get; set; }

        public IActionResult OnPost()
        {
            return RedirectToPage("./ST", new { Tid });
        }
    }
}