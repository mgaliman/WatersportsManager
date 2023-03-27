using Microsoft.AspNetCore.Mvc;
using WatersportsManager.Application.Reports;
using WatersportsManager.Application.Reports.Models;

namespace WatersportsManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet(Name = nameof(GetReports))]
        public async Task<IReadOnlyList<ReportDto>> GetReports(CancellationToken cancellationToken)
        {
            return await _reportService.GetReports(cancellationToken);
        }

        [HttpGet("{id}", Name = nameof(GetReport))]
        public async Task<IActionResult> GetReport([FromRoute] int id, CancellationToken cancellationToken)
        {
            ReportDto report = await _reportService.GetReportById(id, cancellationToken);

            return report is not null ? Ok(report) : NotFound();
        }

        [HttpPost(Name = nameof(CreateReport))]
        public async Task<IActionResult> CreateReport([FromBody] CreateReportDto model, CancellationToken cancellationToken)
        {
            int reportId = await _reportService.CreateReport(model, cancellationToken);

            return CreatedAtAction(nameof(CreateReport), new { Id = reportId });
        }

        [HttpPut(Name = nameof(UpdateReport))]
        public async Task<IActionResult> UpdateReport([FromBody] UpdateReportDto model, CancellationToken cancellationToken)
        {
            await _reportService.UpdateReport(model, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}", Name = nameof(DeleteReport))]
        public async Task<IActionResult> DeleteReport([FromRoute] int id, CancellationToken cancellationToken)
        {
            bool reportDeleted = await _reportService.DeleteReport(id, cancellationToken);

            return reportDeleted ? NoContent() : NotFound();
        }
    }
}
