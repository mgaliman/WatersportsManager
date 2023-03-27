#nullable disable warnings

using WatersportsManager.Domain.Base;

namespace WatersportsManager.Domain
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsSkipper { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public string Email { get; set; }

        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public virtual Location? Location { get; set; }
        public int? LocationId { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
