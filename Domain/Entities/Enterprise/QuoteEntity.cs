using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Enterprise;

public class QuoteEntity : BaseEntity
{
    public int Id { get; set; }
    [StringLength(50, MinimumLength = 2)]
    public string CustomerName { get; set; }
    [StringLength(15, MinimumLength = 7)]
    public string ContactNumber { get; set; }
    [StringLength(4, MinimumLength = 5000)]
    public string? ExtraInfo { get; set; }
    [StringLength(7, MinimumLength = 320)]
    public string? Email { get; set; }
    [StringLength(50, MinimumLength = 2)]
    public string EventName { get; set; }
    public DateTimeOffset EventDate { get; set; }
    [StringLength(255, MinimumLength = 2)]
    public string Location { get; set; }
    public ICollection<QuoteItemEntity> QuoteItems { get; set; }
    [StringLength(36, MinimumLength = 32)]
    public string? UserId { get; set; }
}