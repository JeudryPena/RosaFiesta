using Domain.Entities.Product.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Product;

public class WarrantyEntity: BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public WarrantyType Type { get; set; } 
    public WarrantyScopeType ScopeType { get; set; }
    public WarrantyStatusType? Status { get; set; }
    public string Period { get; set; } 
    public string Description { get; set; } 
    public string Conditions { get; set; }
}