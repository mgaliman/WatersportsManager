#nullable disable warnings

namespace WatersportsManager.Application.Reviews.Models
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Star { get; set; }
        public DateTime Date { get; set; }
        public string? Person { get; set; }
        public string? Resevation { get; set; }
    }
}
