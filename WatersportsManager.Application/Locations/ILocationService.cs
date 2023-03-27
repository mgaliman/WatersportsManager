using WatersportsManager.Application.Locations.Models;

namespace WatersportsManager.Application.Locations
{
    public interface ILocationService
    {
        public Task<IReadOnlyList<LocationDto>> GetLocations(CancellationToken token);
        public Task<bool> LocationExists(int id, CancellationToken token);
    }
}
