using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EgetTest03.Pages.PlayerTeams
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public string SVal { get; set; } = "Teams";

        public string[] SVals = new[] { "Players", "Teams" };

        public IActionResult OnPost()
        {
            if (SVal == "Teams")
            {
                return RedirectToPage("./ShowTeams");
            }
            else
            {
                return RedirectToPage("./ShowPlayers");
            };

        }
    }
}