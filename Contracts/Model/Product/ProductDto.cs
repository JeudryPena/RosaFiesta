using Contracts.Model.Product.Response;

namespace Contracts.Model.Product;

public class ProductDto
{
	public string? Code { get; set; }
	public bool IsService { get; set; }
	public ICollection<OptionDto> Options { get; set; }
	public CategoriesListResponse Category { get; set; }
	public WarrantiesListResponse? Warranty { get; set; }
	public SuppliersListResponse? SupplierId { get; set; }
}
