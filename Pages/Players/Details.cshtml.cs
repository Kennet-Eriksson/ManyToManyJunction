using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EgetTest03.Data;
using EgetTest03.Models;

namespace EgetTest03.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly EgetTest03.Data.EgetTest03Context _context;

        public DetailsModel(EgetTest03.Data.EgetTest03Context context)
        {
            _context = context;
        }

        public Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Player.FirstOrDefaultAsync(m => m.Id == id);

            if (Player == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
