using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nordlager.Backend.Authorization;
using Nordlager.Backend.Models;
using Nordlager.Shared.Models;

namespace Nordlager.Backend.Areas.News.Pages
{
    
    [AuthorizeAdmin]
    public class EditModel : PageModel
    {
        private readonly Nordlager.Backend.Models.NolaDbContext _context;

        public EditModel(Nordlager.Backend.Models.NolaDbContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NewsItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsItemExists(NewsItem.Id))
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

        private bool NewsItemExists(Guid id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}
