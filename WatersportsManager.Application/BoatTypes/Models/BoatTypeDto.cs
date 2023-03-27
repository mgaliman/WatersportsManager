#nullable disable warnings

namespace WatersportsManager.Application.BoatTypes.Models
{
    public class BoatTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Registration { get; set; }
        public double? Length { get; set; }
        public int? MaxCapacity { get; set; }
        public int? HorsePower { get; set; }
        public int? FuelPercentage { get; set; }
        public int? LifeJackets { get; set; }
        public bool IsFunctional { get; set; }
        public string? Price { get; set; }
    }
}

