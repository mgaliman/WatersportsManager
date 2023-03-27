#nullable disable warnings

namespace WatersportsManager.Application.People.Models
{
    public class CreatePersonDto
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsSkipper { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int? LocationId { get; set; }
    }
}
