﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EgetTest03.Data;
using EgetTest03.Models;

namespace EgetTest03.Pages.Arenas
{
    public class DeleteModel : PageModel
    {
        private readonly EgetTest03.Data.EgetTest03Context _context;

        public DeleteModel(EgetTest03.Data.EgetTest03Context context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Arena = await _context.Arena.FindAsync(id);

            if (Arena != null)
            {
                _context.Arena.Remove(Arena);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
