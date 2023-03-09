﻿namespace Domain.Entities.Product.Helpers;

public enum PurchaseStatusType
{
    Pending = 1,
    Processing = 2,
    Shipped = 3,
    Delivered = 4,
    Cancelled = 5,
    Returned = 6,
    Refunded = 7
}