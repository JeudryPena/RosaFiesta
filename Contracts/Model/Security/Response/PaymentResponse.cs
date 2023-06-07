namespace Contracts.Model.Security.Response;

public class PaymentResponse : BaseResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PayMethodType { get; set; }
    public string UserId { get; set; }
}