using Microsoft.AspNetCore.Mvc;
using WatersportsManager.Application.Reviews.Models;
using WatersportsManager.Application.Reviews;

namespace WatersportsManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet(Name = nameof(GetReviews))]
        public async Task<IReadOnlyList<ReviewDto>> GetReviews(CancellationToken cancellationToken)
        {
            return await _reviewService.GetReviews(cancellationToken);
        }

        [HttpGet("{id}", Name = nameof(GetReview))]
        public async Task<IActionResult> GetReview([FromRoute] int id, CancellationToken cancellationToken)
        {
            ReviewDto review = await _reviewService.GetReviewById(id, cancellationToken);

            return review is not null ? Ok(review) : NotFound();
        }

        [HttpPost(Name = nameof(CreateReview))]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto model, CancellationToken cancellationToken)
        {
            int reviewId = await _reviewService.CreateReview(model, cancellationToken);

            return CreatedAtAction(nameof(CreateReview), new { Id = reviewId });
        }

        [HttpPut(Name = nameof(UpdateReview))]
        public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewDto model, CancellationToken cancellationToken)
        {
            await _reviewService.UpdateReview(model, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}", Name = nameof(DeleteReview))]
        public async Task<IActionResult> DeleteReview([FromRoute] int id, CancellationToken cancellationToken)
        {
            bool reviewDeleted = await _reviewService.DeleteReview(id, cancellationToken);

            return reviewDeleted ? NoContent() : NotFound();
        }
    }
}
