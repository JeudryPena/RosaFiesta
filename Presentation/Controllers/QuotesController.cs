using System.Net;
using System.Security.Claims;
using Contracts.Model.Enterprise;
using Contracts.Model.Enterprise.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuotesController:ControllerBase
{
    private readonly IServiceManager _serviceManager;
    
    public QuotesController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet]
    [Authorize(Roles ="Admin")]
    public async Task<IActionResult> GetQuotes(CancellationToken cancellationToken)
    {
        IEnumerable<QuotePreviewResponse> quotes = await _serviceManager.QuoteService.GetQuotesAsync(cancellationToken);
        return Ok(quotes);
    }
    
    [HttpGet("{userId}")]
    [Authorize(Roles ="Admin")]
    public async Task<IActionResult> GetQuotesByUserId(string userId, CancellationToken cancellationToken)
    {
        IEnumerable<QuotePreviewResponse> quotes = await _serviceManager.QuoteService.GetQuotesByUserIdAsync(userId, cancellationToken);
        return Ok(quotes);
    }
    
    [HttpGet("userQuotes")]
    [Authorize]
    public async Task<IActionResult> GetUserQuotes(CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        IEnumerable<QuotePreviewResponse> quotes = await _serviceManager.QuoteService.GetQuotesByUserIdAsync(userId, cancellationToken);
        return Ok(quotes);
    }
    
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetQuote(int id, CancellationToken cancellationToken)
    {
        QuoteResponse quote = await _serviceManager.QuoteService.GetQuoteAsync(id, cancellationToken);
        return Ok(quote);
    }

    [HttpPost]
    public async Task<IActionResult> MakeQuote([FromBody] QuoteDto quoteDto, CancellationToken cancellationToken)
    {
        QuoteResponse quote = await _serviceManager.QuoteService.CreateQuoteAsync(quoteDto, cancellationToken);
        return Ok(quote);
    }
    
    [HttpPost("userQuote")]
    [Authorize]
    public async Task<IActionResult> MakeUserQuote([FromBody] QuoteDto quoteDto, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        QuoteResponse quote = await _serviceManager.QuoteService.CreateUserQuoteAsync(userId, quoteDto, cancellationToken);
        return Ok(quote);
    }
    
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateQuote(int id, [FromBody] QuoteUpdateDto quoteDto, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        QuoteResponse quote = await _serviceManager.QuoteService.UpdateQuoteAsync(id, quoteDto, userId, cancellationToken);
        return Ok(quote);
    }
    
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteQuote(int id, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        await _serviceManager.QuoteService.DeleteQuoteAsync(id, userId, cancellationToken);
        return Ok();
    }
}