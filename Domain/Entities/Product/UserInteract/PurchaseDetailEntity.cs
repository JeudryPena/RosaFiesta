using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Product.Helpers;

namespace Domain.Entities.Product.UserInteract;

public class PurchaseDetailEntity
{
    public int PurchaseNumber { get; set; }
    public string ProductId { get; set; }
    public int? OrderSku { get; set; }
    public ICollection<PurchaseDetailOptions> PurchaseOptions { get; set; }
    public int? CartId { get; set; }
}