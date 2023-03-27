using WatersportsManager.Application.PriorityTypes.Models;
using WatersportsManager.Domain;

namespace WatersportsManager.Application.PriorityTypes
{
    public interface IPriorityTypeService
    {
        public Task<IReadOnlyList<PriorityTypeDto>> GetPriorityTypes(CancellationToken token);
        public Task<bool> PriorityTypeExists(int id, CancellationToken token);
    }
}
