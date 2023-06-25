namespace Domain.Entities;
public class ByBaseEntity : BaseEntity
{
	public string CreatedBy { get; set; }
	public string? UpdatedBy { get; set; }
}
