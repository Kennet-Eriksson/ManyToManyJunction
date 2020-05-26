using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EgetTest03.Data;
using EgetTest03.Models;

namespace EgetTest03.Pages.Arenas
{
    public class EditModel : PageModel
    {
        private readonly EgetTest03.Data.EgetTest03Context _context;

        public EditModel(EgetTest03.Data.EgetTest03Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Arena Arena { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Arena = await _context.Arena.FirstOrDefaultAsync(m => m.Id == id);

            if (Arena == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Arena).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArenaExists(Arena.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArenaExists(int id)
        {
            return _context.Arena.Any(e => e.Id == id);
        }
    }
}
