#nullable disable warnings

namespace WatersportsManager.Domain.Base
{
    public abstract class BaseNameEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
