namespace Contracts.Model.Security.Response;

public class FinishRegisterResponse
{
    public string Id { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}