#nullable disable warnings

using WatersportsManager.Application.Reports.Models;
using WatersportsManager.Application.Persistence;
using WatersportsManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace WatersportsManager.Application.Reports
{
    public class ReportService : IReportService
    {
        private readonly WatersportsManagerDbContext _dbContext;
        public ReportService(WatersportsManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<ReportDto>> GetReports(CancellationToken token)
        {
            return await _dbContext.Reports.AsNoTracking()
               .Select(report => new ReportDto
               {
                   Id = report.Id,
                   Title = report.Title,
                   Description = report.Description,
                   Person = report.Person.ToString(),
                   PriorityType = report.PriorityType.Type
               })
               .ToListAsync(token);
        }

        public async Task<ReportDto> GetReportById(int id, CancellationToken token)
        {
            return await _dbContext.Reports.Where(report => report.Id == id)
               .Select(report => new ReportDto
               {
                   Id = report.Id,
                   Title = report.Title,
                   Description = report.Description,
                   Person = report.Person.ToString(),
                   PriorityType = report.PriorityType.Type
               })
               .FirstOrDefaultAsync(token);
        }

        public async Task<int> CreateReport(CreateReportDto report, CancellationToken token)
        {
            ArgumentNullException.ThrowIfNull(report, nameof(report));

            Report reportToCreate = new()
            {
                Title = report.Title,
                Description = report.Description,
                PersonId = report.PersonId,
                PriorityTypeId = report.PriorityTypeId
            };

            _dbContext.Add(reportToCreate);

            await _dbContext.SaveChangesAsync(token);

            return reportToCreate.Id;
        }

        public async Task UpdateReport(UpdateReportDto report, CancellationToken token)
        {
            Report reportToUpdate = await _dbContext.Reports.FindAsync(new object[] { report.Id }, cancellationToken: token);

            reportToUpdate.Title = report.Title;
            reportToUpdate.Description = report.Description;
            reportToUpdate.PersonId = report.PersonId;
            reportToUpdate.PriorityTypeId = report.PriorityTypeId;

            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<bool> DeleteReport(int id, CancellationToken token)
        {
            Report reportToDelete = await _dbContext.Reports.Where(report => report.Id == id).FirstOrDefaultAsync(token);
            if (reportToDelete is null)
                return false;

            _dbContext.Reports.Remove(reportToDelete);
            await _dbContext.SaveChangesAsync(token);

            return true;
        }

        public async Task<bool> ReportExists(int id, CancellationToken token)
        {
            return await _dbContext.Reports.Where(report => report.Id == id).AnyAsync(token);
        }
    }
}
