#nullable disable warnings

namespace WatersportsManager.Application.Reviews.Models
{
    public class CreateReviewDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Star { get; set; }
        public DateTime Date { get; set; }
        public int? PersonId { get; set; }
        public int? ResevationId { get; set; }
    }
}
