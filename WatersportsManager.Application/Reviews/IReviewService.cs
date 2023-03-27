using WatersportsManager.Application.Reviews.Models;

namespace WatersportsManager.Application.Reviews
{
    public interface IReviewService
    {
        public Task<IReadOnlyList<ReviewDto>> GetReviews(CancellationToken token);
        public Task<ReviewDto> GetReviewById(int id, CancellationToken token);
        public Task<int> CreateReview(CreateReviewDto review, CancellationToken token);
        public Task UpdateReview(UpdateReviewDto review, CancellationToken token);
        public Task<bool> DeleteReview(int id, CancellationToken token);
        public Task<bool> ReviewExists(int id, CancellationToken token);
    }
}
