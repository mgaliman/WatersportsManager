using WatersportsManager.Application.Reports.Models;

namespace WatersportsManager.Application.Reports
{
    public interface IReportService
    {
        public Task<IReadOnlyList<ReportDto>> GetReports(CancellationToken token);
        public Task<ReportDto> GetReportById(int id, CancellationToken token);
        public Task<int> CreateReport(CreateReportDto report, CancellationToken token);
        public Task UpdateReport(UpdateReportDto report, CancellationToken token);
        public Task<bool> DeleteReport(int id, CancellationToken token);
        public Task<bool> ReportExists(int id, CancellationToken token);
    }
}
