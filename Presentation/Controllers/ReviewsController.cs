using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController: ControllerBase
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
    
    [HttpGet("{reviewId:guid}")]
    public async Task<IActionResult> GetReviewById(Guid reviewId, CancellationToken cancellationToken)
    {
        ReviewResponse supplier = await _serviceManager.ReviewService.GetByIdAsync(reviewId, cancellationToken);
        return Ok(supplier);
    }
    
    [HttpPost("{productCode}")]
    [Authorize]
    public async Task<IActionResult> CreateReview(Guid productCode, [FromBody] ReviewDto reviewDto, CancellationToken cancellationToken)
    {
        string userId = _serviceManager.AuthenticateService.CurrentUserId();
        ReviewResponse reviewResponse = await _serviceManager.ReviewService.CreateAsync(userId, productCode, reviewDto, cancellationToken);
        return Ok(reviewResponse);
    }
    
    [HttpPut("{reviewId:guid}")]
    [Authorize]
    public async Task<IActionResult> UpdateReview(Guid reviewId, [FromBody] ReviewDto reviewDto, CancellationToken cancellationToken)
    {
        ReviewResponse reviewResponse = await _serviceManager.ReviewService.UpdateAsync(reviewId, reviewDto, cancellationToken);
        return Ok(reviewResponse);
    }
    
    [HttpDelete("{reviewId:guid}")]
    [Authorize]
    public async Task<IActionResult> DeleteReview(Guid reviewId, CancellationToken cancellationToken)
    {
        await _serviceManager.ReviewService.DeleteAsync(reviewId, cancellationToken);
        return Ok();
    }
}