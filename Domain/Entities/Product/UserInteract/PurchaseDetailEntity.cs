using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Product.Helpers;

namespace Domain.Entities.Product.UserInteract;

public class PurchaseDetailEntity: BaseEntity
{
    public int PurchaseNumber { get; set; }
    public string? ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public string? DiscountId { get; set; }
    public DiscountEntity? DiscountApplied { get; set; }
    public int CartId { get; set; }
    public CartEntity Cart { get; set; }
}