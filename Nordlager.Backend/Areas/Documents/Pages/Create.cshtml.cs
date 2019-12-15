using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nordlager.Backend.Authorization;
using Nordlager.Shared.Models;

namespace Nordlager.Backend.Areas.Documents.Pages
{
    [AuthorizeAdmin]
    public class CreateModel : PageModel
    {
        private readonly Nordlager.Backend.Models.NolaDbContext _context;

        public CreateModel(Nordlager.Backend.Models.NolaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DocumentItem DocumentItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Documents.Add(DocumentItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
