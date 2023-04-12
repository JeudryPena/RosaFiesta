using Domain.Entities.Product.UserInteract;
using Domain.Entities.Security;

namespace Domain.Entities.Enterprise;

public class QuoteEntity
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string ContactNumber { get; set; }
    public string? ExtraInfo { get; set; }
    public string? Email { get; set; }
    public string EventName { get; set; }
    public DateTimeOffset EventDate { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Location { get; set; }
    public ICollection<QuoteItemEntity> QuoteItems { get; set; }
    public string? UserId { get; set; }
}