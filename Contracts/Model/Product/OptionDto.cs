﻿using Contracts.Model.Product.UserInteract;

namespace Contracts.Model.Product;

public class OptionDto
{
	public Guid? Id { get; set; }
	public string Title { get; set; }
	public string? Description { get; set; }
	public double Price { get; set; }
	public int QuantityAvailable { get; set; }
	public string? Color { get; set; }
	public int GenderFor { get; set; }
	public int Condition { get; set; }
	public int ImageIndex { get; set; }
	public ICollection<MultipleImageDto>? Images { get; set; }
}