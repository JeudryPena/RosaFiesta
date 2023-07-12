﻿namespace Contracts.Model.Security.Response;

public class AddressResponse : BaseResponse

{
	public Guid Id { get; set; }
	public string? ExtraDetails { get; set; }
	public string Title { get; set; }
	public string City { get; set; }
	public string ZipCode { get; set; }
	public string Street { get; set; }
	public Guid UserId { get; set; }
}