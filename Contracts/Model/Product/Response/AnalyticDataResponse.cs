namespace Contracts.Model.Product.Response;

public sealed class AnalyticDataResponse
{
    public int TotalClients { get; set; }
    public float AverageReviews { get; set; }
    public double TotalGains { get; set; }
}