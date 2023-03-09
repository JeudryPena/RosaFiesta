﻿namespace Domain.Entities;

public abstract class BaseEntity
{
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; } = "System";
    public string? UpdatedBy { get; set; }
}