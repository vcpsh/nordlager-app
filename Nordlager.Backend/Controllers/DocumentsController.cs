using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nordlager.Backend.Models;
using Nordlager.Shared.Models;

namespace Nordlager.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class DocumentsController : ControllerBase
    {
        private readonly NolaDbContext _context;

        public DocumentsController(NolaDbContext context)
        {
            this._context = context;
        }

        // GET: api/Documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentItem>>> GetDocuments()
        {
            return await this._context.Documents.Where(d => d.ValidFrom.HasValue && d.ValidTo.HasValue).ToListAsync();
        }
    }
}
