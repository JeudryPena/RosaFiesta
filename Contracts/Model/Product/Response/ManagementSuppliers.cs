namespace Contracts.Model.Product.Response;
public sealed class ManagementSuppliers
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string? Email { get; set; }
	public string? Description { get; set; }
	public string? Phone { get; set; }
	public string? Address { get; set; }
}
