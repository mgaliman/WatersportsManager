using Microsoft.EntityFrameworkCore;
using WatersportsManager.Application.Persistence;
using WatersportsManager.Application.Roles.Models;

namespace WatersportsManager.Application.Roles
{
    public class RoleService : IRoleService
    {
        private readonly WatersportsManagerDbContext _dbContext;
        public RoleService(WatersportsManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<RoleDto>> GetRoles(CancellationToken token)
        {
            return await _dbContext.Roles.AsNoTracking()
               .Select(role => new RoleDto
               {
                   Id = role.Id,
                   Code = role.Code
               })
               .ToListAsync(token);
        }

        public async Task<bool> RoleExists(int id, CancellationToken token)
        {
            return await _dbContext.Roles.Where(person => person.Id == id).AnyAsync(token);
        }
    }
}