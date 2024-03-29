﻿using System.ComponentModel.DataAnnotations;

using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class WarrantyEntity : ByBaseEntity, IAutoBy
{
	public Guid Id { get; set; }
	[StringLength(100, MinimumLength = 5)]
	public string Name { get; set; }
	public WarrantyType Type { get; set; }
	public WarrantyStatusType Status { get; set; } = WarrantyStatusType.Activo;
	public int Period { get; set; }
	[StringLength(1000, MinimumLength = 5)]
	public string Description { get; set; }
	public ICollection<ProductEntity>? Products { get; set; }
}