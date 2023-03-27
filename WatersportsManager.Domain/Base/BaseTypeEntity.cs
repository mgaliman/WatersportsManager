#nullable disable warnings

namespace WatersportsManager.Domain.Base
{
    public abstract class BaseTypeEntity : BaseEntity
    {
        public string Type { get; set; }
    }
}
