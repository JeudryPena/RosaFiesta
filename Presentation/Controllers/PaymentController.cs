using System.Net;
using System.Security.Claims;

using Contracts.Model.Security.Response;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Abstractions;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PaymentController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public PaymentController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet()]
	public async Task<IActionResult> RetrieveAllAsync(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		IEnumerable<PaymentsPreviewResponse> payments = await _serviceManager.PayMethodService.GetByUserIdAsync(userId, cancellationToken);
		return Ok(payments);
	}

	[HttpGet("{paymentId:guid}")]
	public async Task<IActionResult> RetrieveByIdAsync(Guid paymentId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		PaymentResponse payment = await _serviceManager.PayMethodService.GetByIdAsync(paymentId, cancellationToken);
		if (payment.UserId != userId)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		return Ok(payment);
	}

	[HttpPut("{paymentId:guid}")]
	public async Task<IActionResult> MakeDefaultAsync(Guid paymentId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.PayMethodService.MakePaymentDefaultAsync(paymentId, userId, cancellationToken);
		return Ok();
	}

	[HttpDelete("{paymentId:guid}")]
	public async Task<IActionResult> DeleteAsync(Guid paymentId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.PayMethodService.DeleteAsync(paymentId, cancellationToken);
		return Ok();
	}
}