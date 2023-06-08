﻿using System.Net;
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

	[HttpGet("MyPayments")]
	public async Task<IActionResult> GetMyPayments(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		IEnumerable<PaymentsPreviewResponse> payments = await _serviceManager.PayMethodService.GetByUserIdAsync(userId, cancellationToken);
		return Ok(payments);
	}

	[HttpGet("MyPayments/{paymentId:guid}")]
	public async Task<IActionResult> GetMyPaymentById(Guid paymentId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		PaymentResponse payment = await _serviceManager.PayMethodService.GetByIdAsync(paymentId, cancellationToken);
		if (payment.UserId != userId)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		return Ok(payment);
	}

	[HttpPut("MyPayments/{paymentId:guid}")]
	public async Task<IActionResult> MakePaymentDefault(Guid paymentId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.PayMethodService.MakePaymentDefaultAsync(paymentId, userId, cancellationToken);
		return Ok();
	}

	[HttpGet("MyPayments/{paymentId:guid}/delete")]
	public async Task<IActionResult> DeleteMyPaymentById(Guid paymentId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.PayMethodService.DeleteAsync(paymentId, cancellationToken);
		return Ok();
	}
}