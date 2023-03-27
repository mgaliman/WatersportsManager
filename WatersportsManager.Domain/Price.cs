#nullable disable warnings

using WatersportsManager.Domain.Base;

namespace WatersportsManager.Domain
{
    public class Price : BaseEntity
    {        
        public int Value { get; set; }
        public virtual TimeType TimeType { get; set; }
        public int TimeTypeId { get; set; }

        public ICollection<BoatType> BoatTypes { get; set; } = new List<BoatType>();
    }
}
