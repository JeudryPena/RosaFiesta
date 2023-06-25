namespace Contracts.Model;
public class ByBaseResponse : BaseResponse
{
	public string CreatedBy { get; set; }
	public string? UpdatedBy { get; set; }
}
