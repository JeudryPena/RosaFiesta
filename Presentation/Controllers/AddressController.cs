using System.Net;
using System.Security.Claims;

using Contracts.Model.Security;
using Contracts.Model.Security.Response;

using Microsoft.AspNetCore.Mvc;

using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public AddressController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet("myAddresses")]
	public async Task<IActionResult> RetrieveAllAsync(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		IEnumerable<AddressPreviewResponse> addresses = await _serviceManager.UserService.GetByUserIdAsync(userId, cancellationToken);
		return Ok(addresses);
	}

	[HttpGet("{addressId:guid}")]
	public async Task<IActionResult> RetrieveByIdAsync(Guid addressId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		AddressResponse address = await _serviceManager.UserService.GetAddressByIdAsync(userId, addressId, cancellationToken);
		return Ok(address);
	}

	[HttpPost]
	public async Task<IActionResult> PersistAsync(AddressDto addressDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.UserService.CreateAddressAsync(userId, addressDto, cancellationToken);
		return Ok();
	}

	[HttpPut("{addressId:guid}")]
	public async Task<IActionResult> UpdateAsync(Guid addressId, AddressDto addressDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.UserService.UpdateAddressAsync(userId, addressId, addressDto, cancellationToken);
		return Ok();
	}

	[HttpDelete("{addressId:guid}")]
	public async Task<IActionResult> DeleteAsync(Guid addressId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.UserService.DisableAddressAsync(userId, addressId, cancellationToken);
		return Ok();
	}
}