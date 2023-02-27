using System.ComponentModel.DataAnnotations;

namespace Contracts.Model;

public class ProductEntityDto
{
    public Guid ID { get; set; }

    [MinLength(3), MaxLength(30)]
    public string? Name { get; set; }

    [MinLength(3), MaxLength(30)]
    public string? Description { get; set; }

    [Range(1, 100000)]
    public int Price { get; set; }

    public bool IsAvailable { get; set; }

    public DateTimeOffset AddedAt { get; set; } = DateTimeOffset.Now;
}
