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
    
    [HttpPost("{productCode}/option/{optionId:int?}")]
    [Authorize]
    public async Task<IActionResult> CreateReview(string productCode, [FromBody] ReviewDto reviewDto, CancellationToken cancellationToken, int? optionId = 0)
    {
        if(optionId == 0)
            optionId = null;
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        ReviewResponse reviewResponse = await _serviceManager.ReviewService.CreateAsync(userId, productCode, optionId, reviewDto, cancellationToken);
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