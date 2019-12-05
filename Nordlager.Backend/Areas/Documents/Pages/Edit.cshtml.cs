using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nordlager.Backend.Authorization;
using Nordlager.Shared.Models;

namespace Nordlager.Backend.Areas.Documents.Pages
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
        public DocumentItem DocumentItem { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DocumentItem = await _context.Documents.FirstOrDefaultAsync(m => m.Id == id);

            if (DocumentItem == null)
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

            _context.Attach(DocumentItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentItemExists(DocumentItem.Id))
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

        private bool DocumentItemExists(Guid id)
        {
            return _context.Documents.Any(e => e.Id == id);
        }
    }
}
