#nullable disable warnings

using WatersportsManager.Domain.Base;

namespace WatersportsManager.Domain
{
    public class TimeType : BaseTypeEntity
    {
        public ICollection<Price> Prices { get; set; } = new List<Price>();
    }
}
