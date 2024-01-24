using System.ComponentModel.DataAnnotations;
using Domain.Entities.Enterprise;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class OrderEntity : BaseEntity, IAutoUpdate
{
	public Guid Id { get; set; } = Guid.NewGuid();
	[StringLength(100, MinimumLength = 3)]
	public string? OrderId { get; set; }
	public string? UserId { get; set; }
	public UserEntity? User { get; set; }
	[Required]
	public OrderStatusType Status { get; set; } = OrderStatusType.Pendiente;
	public IList<PurchaseDetailEntity> Details { get; set; } = new List<PurchaseDetailEntity>();
	[StringLength(100, MinimumLength = 3)]
	public string? TransactionId { get; set; } = string.Empty;
	[StringLength(100, MinimumLength = 3)]
	public string? CurrencyCode { get; set; } = string.Empty;
	[StringLength(100, MinimumLength = 3)]
	public string? PayerId { get; set; } = string.Empty;
	public double? Shipping { get; set; }
	public double? Total { get; set; }
	public Guid AddressId { get; set; }
	public AddressEntity Address { get; set; }
	public Guid? QuoteId { get; set; }
	public QuoteEntity? Quote { get; set; }
	public DateTimeOffset? TransactionDate { get; set; }
}