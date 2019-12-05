using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Nordlager.Backend.Models;

namespace Nordlager.Backend.Authorization
{
    public class AdminHandler: AuthorizationHandler<AdminRequirement>
    {
        private readonly NolaDbContext _context;

        public AdminHandler(NolaDbContext context)
        {
            _context = context;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
        {
            var userName = context.User.Identity.Name;
            if (userName == null)
            {
                return;
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name.Equals(userName));
            if (user == null)
            {
                _context.Users.Add(new User() {Name = userName});
                await _context.SaveChangesAsync();
                return;
            }

            if (user.IsAdmin)
            {
                context.Succeed(requirement);
            }
        }
    }
}
