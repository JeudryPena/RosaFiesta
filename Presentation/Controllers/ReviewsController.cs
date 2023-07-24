using System.Net;
using System.Security.Claims;

using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public ReviewsController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet("options/{optionId:guid}")]
	public async Task<IActionResult> GetReviews(Guid optionId, CancellationToken cancellationToken)
	{
		IEnumerable<ReviewResponse> reviews = await _serviceManager.ReviewService.GetAllAsync(optionId, cancellationToken);
		return Ok(reviews);
	}

	[HttpGet("{reviewId}")]
	public async Task<IActionResult> GetReviewById(int reviewId, CancellationToken cancellationToken)
	{
		ReviewResponse supplier = await _serviceManager.ReviewService.GetByIdAsync(reviewId, cancellationToken);
		return Ok(supplier);
	}

	[HttpPost("options/{optionId:guid}")]
	[Authorize]
	public async Task<IActionResult> CreateReview([FromBody] ReviewDto reviewDto, Guid optionId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		ReviewResponse reviewResponse = await _serviceManager.ReviewService.CreateAsync(userId, optionId, reviewDto, cancellationToken);
		return Ok(reviewResponse);
	}

	[HttpPut("{reviewId}")]
	[Authorize]
	public async Task<IActionResult> UpdateReview(int reviewId, [FromBody] ReviewDto reviewDto, CancellationToken cancellationToken)
	{

		ReviewResponse reviewResponse = await _serviceManager.ReviewService.UpdateAsync(reviewId, reviewDto, cancellationToken);
		return Ok(reviewResponse);
	}

	[HttpDelete("{reviewId}")]
	[Authorize]
	public async Task<IActionResult> DeleteReview(int reviewId, CancellationToken cancellationToken)
	{
		await _serviceManager.ReviewService.DeleteAsync(reviewId, cancellationToken);
		return Ok();
	}
}