using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nordlager.Backend.Authorization;
using Nordlager.Shared.Models;

namespace Nordlager.Backend.Areas.Documents.Pages
{
    [AuthorizeAdmin]
    public class IndexModel : PageModel
    {
        private readonly Nordlager.Backend.Models.NolaDbContext _context;

        public IndexModel(Nordlager.Backend.Models.NolaDbContext context)
        {
            _context = context;
        }

        public IList<DocumentItem> DocumentItem { get;set; }

        public async Task OnGetAsync()
        {
            DocumentItem = await _context.Documents.ToListAsync();
        }
    }
}
