﻿namespace Domain.Entities.Product;

public class MultipleOptionImages
{
	public int Id { get; set; }
	public string Image { get; set; }
	public Guid OptionId { get; set; }
}