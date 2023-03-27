#nullable disable warnings

using WatersportsManager.Domain.Base;

namespace WatersportsManager.Domain
{
    public class Role : BaseEntity
    {
        public string Code { get; set; }

        public ICollection<Person> People { get; set; } = new List<Person>();
    }
}
