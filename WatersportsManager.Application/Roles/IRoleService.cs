using WatersportsManager.Application.Roles.Models;

namespace WatersportsManager.Application.Roles
{
    public interface IRoleService
    {
        public Task<IReadOnlyList<RoleDto>> GetRoles(CancellationToken token);
        public Task<bool> RoleExists(int id, CancellationToken token);
    }
}
