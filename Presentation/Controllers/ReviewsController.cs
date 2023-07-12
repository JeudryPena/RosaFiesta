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
public class ReviewController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public ReviewController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet]
	public async Task<IActionResult> GetReviews(CancellationToken cancellationToken)
	{
		IEnumerable<ReviewResponse> reviews = await _serviceManager.ReviewService.GetAllAsync(cancellationToken);
		return Ok(reviews);
	}

	[HttpGet("{reviewId}")]
	public async Task<IActionResult> GetReviewById(int reviewId, CancellationToken cancellationToken)
	{
		ReviewResponse supplier = await _serviceManager.ReviewService.GetByIdAsync(reviewId, cancellationToken);
		return Ok(supplier);
	}

	[HttpPost("option/{optionId:guid}")]
	[Authorize]
	public async Task<IActionResult> CreateReview([FromBody] ReviewDto reviewDto, CancellationToken cancellationToken, Guid optionId)
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