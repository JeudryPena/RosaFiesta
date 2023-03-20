using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Product.Helpers;

namespace Domain.Entities.Product.UserInteract;

public class PurchaseDetailEntity
{
    public int PurchaseNumber { get; set; }
    public string? ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public int? OrderSku { get; set; }
    public OrderEntity? Order { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public int? AppliedId { get; set; }
    public AppliedDiscountEntity? DiscountApplied { get; set; }
    public int? CartId { get; set; }
    public CartEntity? Cart { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}