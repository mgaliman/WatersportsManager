#nullable disable warnings

namespace WatersportsManager.Application.Reports.Models
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Person { get; set; }
        public string PriorityType { get; set; }
    }
}
