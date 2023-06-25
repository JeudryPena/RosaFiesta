namespace Domain.Entities;
public interface IAutoBy : IAutoUpdate
{
	string CreatedBy { get; set; }
	string? UpdatedBy { get; set; }
}
