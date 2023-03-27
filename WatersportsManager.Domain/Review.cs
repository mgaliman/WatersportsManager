#nullable disable warnings

using WatersportsManager.Domain.Base;

namespace WatersportsManager.Domain
{
    public class Review : BaseNameEntity
    {
        public string Description { get; set; }
        public int Star { get; set; }
        public DateTime Date { get; set; }
        public virtual Person? Person { get; set; }
        public int? PersonId { get; set; }
        public virtual Reservation? Reservation { get; set; }
        public int? ResevationId { get; set; }
    }
}
