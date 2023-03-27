using Microsoft.AspNetCore.Mvc;
using WatersportsManager.Application.Roles;
using WatersportsManager.Application.Roles.Models;

namespace WatersportsManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet(Name = nameof(GetRoles))]
        public async Task<IReadOnlyList<RoleDto>> GetRoles(CancellationToken cancellationToken)
        {
            return await _roleService.GetRoles(cancellationToken);
        }
    }
}
