using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Contracts.Model.Enterprise;

public sealed class OficializeQuoteDto
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public double Shipping { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Province { get; set; }
    public int PostalCode { get; set; }
    public DateTime EventDate { get; set; }
    public ICollection<OficializeItemsDto>? Products { get; set; }
}