namespace Contracts.Model.Security.Response;

public class PaymentsPreviewResponse : BaseResponse
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public bool? IsDefault { get; set; }
}