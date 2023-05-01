﻿namespace Contracts.Model.Enterprise.Response;

public class ServiceResponse: BaseResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public int Quantity { get; set; }
    public int QuantityAvaliable { get; set; }
}