namespace Contracts.Model.Product.Response;
public class ManagementDiscountsResponse
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public double Value { get; set; }
    public int MaxTimesApply { get; set; }
    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }
    public string? Description { get; set; }

}
