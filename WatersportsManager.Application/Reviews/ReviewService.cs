#nullable disable warnings

using Microsoft.EntityFrameworkCore;
using WatersportsManager.Application.Persistence;
using WatersportsManager.Application.Reviews.Models;
using WatersportsManager.Domain;

namespace WatersportsManager.Application.Reviews
{
    public class ReviewService : IReviewService
    {
        private readonly WatersportsManagerDbContext _dbContext;
        public ReviewService(WatersportsManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<ReviewDto>> GetReviews(CancellationToken token)
        {
            return await _dbContext.Reviews.AsNoTracking()
               .Select(review => new ReviewDto
               {
                   Id = review.Id,
                   Name = review.Name,
                   Date = review.Date.Date,
                   Description = review.Description,
                   Star = review.Star,
                   Person = review.PersonId != null ? review.Person.ToString() : null,
                   Resevation = review.ResevationId != null ? review.Reservation.BoatType.Registration : null
               })
               .ToListAsync(token);
        }

        public async Task<ReviewDto> GetReviewById(int id, CancellationToken token)
        {
            return await _dbContext.Reviews.Where(review => review.Id == id)
               .Select(review => new ReviewDto
               {
                   Id = review.Id,
                   Name = review.Name,
                   Date = review.Date.Date,
                   Description = review.Description,
                   Star = review.Star,
                   Person = review.PersonId != null ? review.Person.ToString() : null,
                   Resevation = review.ResevationId != null ? review.Reservation.BoatType.Registration : null
               })
               .FirstOrDefaultAsync(token);
        }

        public async Task<int> CreateReview(CreateReviewDto review, CancellationToken token)
        {
            ArgumentNullException.ThrowIfNull(review, nameof(review));

            Review reviewToCreate = new()
            {
                Name = review.Name,
                Date = review.Date.Date,
                Description = review.Description,
                Star = review.Star,
                PersonId = review.PersonId,
                ResevationId = review.ResevationId
            };

            _dbContext.Add(reviewToCreate);

            await _dbContext.SaveChangesAsync(token);

            return reviewToCreate.Id;
        }

        public async Task UpdateReview(UpdateReviewDto review, CancellationToken token)
        {
            Review reviewToUpdate = await _dbContext.Reviews.FindAsync(new object[] { review.Id }, cancellationToken: token);

            reviewToUpdate.Name = review.Name;
            reviewToUpdate.Date = review.Date.Date;
            reviewToUpdate.Description = review.Description;
            reviewToUpdate.Star = review.Star;
            reviewToUpdate.PersonId = review.PersonId;
            reviewToUpdate.ResevationId = review.ResevationId;

            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<bool> DeleteReview(int id, CancellationToken token)
        {
            Review reviewToDelete = await _dbContext.Reviews.Where(review => review.Id == id).FirstOrDefaultAsync(token);
            if (reviewToDelete is null)
                return false;

            _dbContext.Reviews.Remove(reviewToDelete);
            await _dbContext.SaveChangesAsync(token);

            return true;
        }

        public async Task<bool> ReviewExists(int id, CancellationToken token)
        {
            return await _dbContext.Reviews.Where(review => review.Id == id).AnyAsync(token);
        }
    }
}
