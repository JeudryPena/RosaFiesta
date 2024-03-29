﻿namespace Domain.Entities.Product;

public class ProductsDiscountsEntity : ISoftDelete
{
	public Guid Id { get; set; }
	public Guid DiscountId { get; set; }
	public DiscountEntity Discount { get; set; }
	public Guid OptionId { get; set; }
	public OptionEntity Option { get; set; }
	public bool IsDeleted { get; set; }
}