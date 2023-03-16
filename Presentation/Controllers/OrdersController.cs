using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController: ControllerBase
{
    private readonly IServiceManager _serviceManager;
    
    public OrdersController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetBills(CancellationToken cancellationToken)
    {
        IEnumerable<OrderResponse> bills = await _serviceManager.OrderService.GetAllAsync(cancellationToken);
        return Ok(bills);
    }
    
    [HttpGet("{billId}")]
    public async Task<IActionResult> GetBillById(int billId, CancellationToken cancellationToken)
    {
        OrderResponse bill = await _serviceManager.OrderService.GetByIdAsync(billId, cancellationToken);
        return Ok(bill);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateBill([FromBody] OrderDto orderDto, CancellationToken cancellationToken)
    {
        OrderResponse billResponse = await _serviceManager.OrderService.CreateAsync(orderDto, cancellationToken);
        return Ok(billResponse);
    }
    
    [HttpPut("{billId}")]
    [Authorize]
    public async Task<IActionResult> UpdateBill(int billId, [FromBody] OrderDto orderDto, CancellationToken cancellationToken)
    {
        OrderResponse billResponse = await _serviceManager.OrderService.UpdateAsync(billId, orderDto, cancellationToken);
        return Ok(billResponse);
    }
    
    [HttpDelete("{billId}")]
    [Authorize]
    public async Task<IActionResult> DeleteBill(int billId, CancellationToken cancellationToken)
    {
        await _serviceManager.OrderService.DeleteAsync(billId, cancellationToken);
        return Ok();
    }
}