using WatersportsManager.Application.BoatTypes.Models;

namespace WatersportsManager.Application.BoatTypes
{
    public interface IBoatTypeService
    {
        public Task<IReadOnlyList<BoatTypeDto>> GetBoatTypes(CancellationToken token);
        public Task<BoatTypeDto> GetBoatTypeById(int id, CancellationToken token);
        public Task<int> CreateBoatType(CreateBoatTypeDto boatType, CancellationToken token);
        public Task UpdateBoatType(UpdateBoatTypeDto boatType, CancellationToken token);
        public Task<bool> DeleteBoatType(int id, CancellationToken token);
        public Task<bool> BoatTypeExists(int id, CancellationToken token);
    }
}
