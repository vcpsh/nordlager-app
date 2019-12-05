using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nordlager.Backend.Authorization;
using Nordlager.Backend.Models;
using Nordlager.Shared.Models;

namespace Nordlager.Backend.Areas.News.Pages
{
    [AuthorizeAdmin]
    public class DeleteModel : PageModel
    {
        private readonly Nordlager.Backend.Models.NolaDbContext _context;

        public DeleteModel(Nordlager.Backend.Models.NolaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NewsItem NewsItem { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewsItem = await _context.News.FirstOrDefaultAsync(m => m.Id == id);

            if (NewsItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewsItem = await _context.News.FindAsync(id);

            if (NewsItem != null)
            {
                _context.News.Remove(NewsItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
