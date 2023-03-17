﻿using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IOrderService
{
    Task<IEnumerable<OrderResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<OrderResponse> GetByIdAsync(int billId, CancellationToken cancellationToken = default);
    Task<OrderResponse> UpdateAsync(int billId, OrderDto orderDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(int billId, CancellationToken cancellationToken = default);
    Task<OrderResponse> OrderPurchaseAsync(string userId, Guid payMethodId, string? discountCode, OrderDto orderDto,
        CancellationToken cancellationToken = default);

    Task<ValidDiscountResponse> ApplyDiscountAsync(string userId, string productId, string discountCode, CancellationToken cancellationToken);
}