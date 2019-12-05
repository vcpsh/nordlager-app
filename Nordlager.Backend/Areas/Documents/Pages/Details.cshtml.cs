using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nordlager.Backend.Authorization;
using Nordlager.Shared.Models;

namespace Nordlager.Backend.Areas.Documents.Pages
{
    [AuthorizeAdmin]
    public class DetailsModel : PageModel
    {
        private readonly Nordlager.Backend.Models.NolaDbContext _context;

        public DetailsModel(Nordlager.Backend.Models.NolaDbContext context)
        {
            _context = context;
        }

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
    }
}
