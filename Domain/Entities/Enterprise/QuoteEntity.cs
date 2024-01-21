﻿using System.ComponentModel.DataAnnotations;

using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Enterprise;

public class QuoteEntity : BaseEntity, IAutoUpdate
{
	public Guid Id { get; set; }
	public DateTimeOffset EventDate { get; set; }
	public string? UserId { get; set; }
	public OrderEntity? Order { get; set; }
}