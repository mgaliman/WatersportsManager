#nullable disable warnings

using WatersportsManager.Domain.Base;

namespace WatersportsManager.Domain
{
    public class Reservation : BaseEntity
    {
        public virtual Person? Person { get; set; }
        public int? PersonId { get; set; }
        public virtual BoatType BoatType { get; set; }
        public int BoatTypeId { get; set; }
        public virtual Location? Location { get; set; }
        public int? LocationId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
