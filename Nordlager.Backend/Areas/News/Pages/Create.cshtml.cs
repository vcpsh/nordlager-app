using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nordlager.Backend.Authorization;
using Nordlager.Backend.Models;
using Nordlager.Shared.Models;

namespace Nordlager.Backend.Areas.News.Pages
{
    [AuthorizeAdmin]
    public class CreateModel : PageModel
    {
        private readonly NolaDbContext _context;

        public CreateModel(NolaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NewsItem NewsItem { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.News.Add(NewsItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
