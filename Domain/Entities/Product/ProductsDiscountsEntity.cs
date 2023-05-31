using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product;

public class ProductsDiscountsEntity
{
    public Guid Id { get; set; }
    [StringLength(25, MinimumLength = 5)]
    public string DiscountCode { get; set; }
    public string? ProductId { get; set; }
    public int? OptionId { get; set; }
    public OptionEntity? Option { get; set; }
}