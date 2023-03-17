﻿using System.Security.Claims;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

public class PurchaseController: ControllerBase
{
    private readonly IServiceManager _serviceManager;
    
    public PurchaseController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    // Order purchase
    [HttpPost("{userId}/payMethod/{payMethodId:guid}")]
    public async Task<IActionResult> OrderPurchaseAsync(string userId, Guid payMethodId, [FromBody] OrderDto orderDto, CancellationToken cancellationToken)
    {
        OrderResponse cart = await _serviceManager.OrderService.OrderPurchaseAsync(userId, payMethodId, orderDto, cancellationToken);
        return Ok(cart);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPurchaseDetails(CancellationToken cancellationToken)
    {
        IEnumerable<PurchaseDetailResponse> purchaseDetails = await _serviceManager.PurchaseDetailService.GetAllAsync(cancellationToken);
        return Ok(purchaseDetails);
    }
    
    [HttpGet("{detailId}")]
    public async Task<IActionResult> GetPurchaseDetailById(int detailId, CancellationToken cancellationToken)
    {
        PurchaseDetailResponse purchaseDetail = await _serviceManager.PurchaseDetailService.GetByIdAsync(detailId, cancellationToken);
        return Ok(purchaseDetail);
    }
    
    [HttpPut("{detailId}")]
    public async Task<IActionResult> UpdatePurchaseDetail(int detailId, [FromBody] PurchaseDetailDto purchaseDetail, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        PurchaseDetailResponse purchaseDetailEntity = await _serviceManager.PurchaseDetailService.UpdateAsync(detailId, purchaseDetail, userId, cancellationToken);
        return Ok(purchaseDetailEntity);
    }

    [HttpDelete("{detailId}")]
    public async Task<IActionResult> DeletePurchaseDetail(int detailId, CancellationToken cancellationToken)
    {
        await _serviceManager.PurchaseDetailService.DeleteAsync(detailId,  cancellationToken);
        return Ok();
    }
    
}