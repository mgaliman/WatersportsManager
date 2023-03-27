using WatersportsManager.Application.TimeTypes.Models;

namespace WatersportsManager.Application.TimeTypes
{
    public interface ITimeTypeService
    {
        public Task<IReadOnlyList<TimeTypeDto>> GetTimeTypes(CancellationToken token);
        public Task<bool> TimeTypeExists(int id, CancellationToken token);
    }
}
