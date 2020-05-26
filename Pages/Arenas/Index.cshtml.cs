using System;
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
    public class IndexModel : PageModel
    {
        private readonly EgetTest03.Data.EgetTest03Context _context;

        public IndexModel(EgetTest03.Data.EgetTest03Context context)
        {
            _context = context;
        }

        public IList<Arena> Arena { get;set; }

        public async Task OnGetAsync()
        {
            Arena = await _context.Arena.ToListAsync();
        }
    }
}
