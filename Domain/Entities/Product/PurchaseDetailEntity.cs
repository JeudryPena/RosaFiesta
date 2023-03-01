using Domain.Entities.Security;

namespace Domain.Entities.Product;

public class PurchaseDetailEntity: BaseEntity
{
    public Guid UserId { get; set; }
    public UserEntity UserEntity { get; set; } = new();
    public int PurchaseNumber { get; set; }
    public double PurchaseTotalPrice { get; set; }
    public PurchaseStatusType PurchaseStatus { get; set; } = PurchaseStatusType.Pending;
    public ICollection<ProductEntity> ProductsPurchased { get; set; } = new List<ProductEntity>();
    public Guid? DiscountId { get; set; }
    public DiscountEntity? DiscountApplied { get; set; } = new();
    public Guid? WarrantyId { get; set; }
    public WarrantyEntity? WarrantyApplied { get; set; } = new();
}