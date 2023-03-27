#nullable disable warnings

using WatersportsManager.Domain.Base;

namespace WatersportsManager.Domain
{
    public class BoatType : BaseNameEntity
    {        
        public string? Registration { get; set; }
        public double? Length { get; set; }
        public int? MaxCapacity { get; set; }
        public int? HorsePower { get; set; }
        public int? FuelPercentage { get; set; }
        public int? LifeJackets { get; set; }
        public bool IsFunctional { get; set; }

        public virtual Price? Price { get; set; }
        public int? PriceId { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}

