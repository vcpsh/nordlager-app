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
            var documents =  await this._context.Documents.ToListAsync();
            documents = documents.Where(item =>
            {
                var validTo = item.ValidTo ?? DateTime.MaxValue;
                var validFrom = item.ValidFrom ?? DateTime.MinValue;
                return validFrom < DateTime.Now && validTo > DateTime.Now;
            }).ToList();
            return Ok(documents);
        }
    }
}
