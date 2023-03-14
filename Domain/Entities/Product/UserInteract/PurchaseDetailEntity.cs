using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Product.Helpers;

namespace Domain.Entities.Product.UserInteract;

public class PurchaseDetailEntity: BaseEntity
{
    public int PurchaseNumber { get; set; }
    public Guid BillId { get; set; }
    public OrderEntity Order { get; set; } 
    public string? ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public string? DiscountId { get; set; }
    public DiscountEntity? DiscountApplied { get; set; } 
}