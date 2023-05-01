﻿namespace Contracts.Model.Enterprise.Response;

public class EmployeeResponse : BaseResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; } 
    public string Email { get; set; } 
    public string Phone { get; set; } 
    public int DepartmentId { get; set; }
    public string JobTitle { get; set; }
    public string Address { get; set; }
    public decimal Salary { get; set; }
    public string WorkingHours { get; set; }
    public string WorkingDays { get; set; }
    public string? Resume { get; set; }
    public string Photo { get; set; }
    public string IdentityCard { get; set; }
}