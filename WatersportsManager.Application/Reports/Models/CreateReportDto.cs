#nullable disable warnings

namespace WatersportsManager.Application.Reports.Models
{
    public class CreateReportDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PersonId { get; set; }
        public int PriorityTypeId { get; set; }
    }
}
