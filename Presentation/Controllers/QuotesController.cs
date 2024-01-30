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
public class QuotesController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public QuotesController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}
	
	[HttpGet("count")]
	[Authorize(Roles="Admin, ProductsManager, MarketingManager, SalesManager")]
	public async Task<IActionResult> GetQuotesCount(CancellationToken cancellationToken)
	{
		int count = await _serviceManager.QuoteService.GetQuotesCountAsync(cancellationToken);
		return Ok(count);
	}

	[HttpGet]
	[Authorize(Roles = "Admin, SalesManager")]
	public async Task<IActionResult> GetQuotes(CancellationToken cancellationToken)
	{
		IEnumerable<QuotePreviewResponse> quotes = await _serviceManager.QuoteService.GetQuotesAsync(cancellationToken);
		return Ok(quotes);
	}

	[HttpGet("{userId}")]
	[Authorize(Roles = "Admin, SalesManager")]
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
			return StatusCode((int)HttpStatusCode.Unauthorized);
		IEnumerable<QuotePreviewResponse> quotes = await _serviceManager.QuoteService.GetQuotesByUserIdAsync(userId, cancellationToken);
		return Ok(quotes);
	}

	[HttpGet("userQuote/{userId}")]
	[Authorize(Roles="Admin, ProductsManager, MarketingManager, SalesManager")]
	public async Task<IActionResult> GetUserQuote(string userId, CancellationToken cancellationToken)
	{
		IEnumerable<QuotePreviewResponse> quotes = await _serviceManager.QuoteService.GetQuotesByUserIdAsync(userId, cancellationToken);
		return Ok(quotes);
	}

	[HttpGet("{id:guid}")]
	[Authorize]
	public async Task<IActionResult> GetQuote(Guid id, CancellationToken cancellationToken)
	{
		QuoteResponse quote = await _serviceManager.QuoteService.GetQuoteAsync(id, cancellationToken);
		return Ok(quote);
	}

	[HttpPost]
	public async Task<IActionResult> MakeQuote([FromBody] QuoteDto quoteDto, CancellationToken cancellationToken)
	{
		await _serviceManager.QuoteService.CreateQuoteAsync(quoteDto, cancellationToken);
		return Ok();
	}
	
	[HttpPut("oficialize")]
	[Authorize(Roles="Admin, SalesManager")]
	public async Task<IActionResult> OficializeQuote([FromBody] OficializeQuoteDto oficializeQuoteDto, CancellationToken cancellationToken)
	{
		await _serviceManager.QuoteService.OficializeQuoteAsync(oficializeQuoteDto, cancellationToken);
		return Ok();
	}

	[HttpPost("userQuote")]
	[Authorize]
	public async Task<IActionResult> MakeUserQuote([FromBody] QuoteDto quoteDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		QuoteResponse quote = await _serviceManager.QuoteService.CreateUserQuoteAsync(userId, quoteDto, cancellationToken);
		return Ok(quote);
	}

	[HttpPut("{id:guid}")]
	[Authorize]
	public async Task<IActionResult> UpdateQuote(Guid id, [FromBody] QuoteDto quoteDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		QuoteResponse quote = await _serviceManager.QuoteService.UpdateQuoteAsync(id, quoteDto, userId, cancellationToken);
		return Ok(quote);
	}

	[HttpDelete("{id:guid}")]
	[Authorize]
	public async Task<IActionResult> DeleteQuote(Guid id, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.QuoteService.DeleteQuoteAsync(id, userId, cancellationToken);
		return Ok();
	}
}