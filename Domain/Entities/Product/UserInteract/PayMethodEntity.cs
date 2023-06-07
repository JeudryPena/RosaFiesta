using System.ComponentModel.DataAnnotations;

using Domain.Entities.Product.Helpers;
using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class PayMethodEntity : BaseEntity
{
    public Guid Id { get; set; }
    [StringLength(30, MinimumLength = 3)]
    public string Name { get; set; }
    [StringLength(500, MinimumLength = 3)]
    public string Description { get; set; }
    [StringLength(10, MinimumLength = 3)]
    public PayMethodType PayMethodType { get; set; }
    public string UserId { get; set; }
    public UserEntity? User { get; set; }
}