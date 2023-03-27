#nullable disable warnings

using WatersportsManager.Domain.Base;

namespace WatersportsManager.Domain
{
    public class Report : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
        public virtual PriorityType PriorityType { get; set; }
        public int PriorityTypeId { get; set; }
    }
}
