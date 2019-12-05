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
    public class IndexModel : PageModel
    {
        private readonly Nordlager.Backend.Models.NolaDbContext _context;

        public IndexModel(Nordlager.Backend.Models.NolaDbContext context)
        {
            _context = context;
        }

        public IList<NewsItem> NewsItem { get;set; }

        public async Task OnGetAsync()
        {
            NewsItem = await _context.News.ToListAsync();
        }
    }
}
