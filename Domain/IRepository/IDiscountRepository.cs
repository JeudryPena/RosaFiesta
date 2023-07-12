using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IDiscountRepository
{
	Task<IEnumerable<DiscountEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<DiscountEntity> GetByIdAsync(Guid discountId, CancellationToken cancellationToken = default);
	void Insert(DiscountEntity discountEntity);
	void Update(DiscountEntity discount);
	Task<AppliedDiscountEntity> GetAppliedDiscount(int purchaseNumber, CancellationToken cancellationToken = default);
	Task<DiscountEntity> GetByAppliedId(int? detailAppliedId, CancellationToken cancellationToken = default);
	Task<ICollection<DiscountEntity>> GetValidDiscountsPreview(string userId, Guid optionId,
		CancellationToken cancellationToken = default);
	Task<DiscountEntity> GetDiscountAsync(Guid discountId, CancellationToken cancellationToken = default);
	Task<DiscountEntity> GetValidDiscount(int optionId, string userId,
		CancellationToken cancellationToken = default);
	void UpdateAppliedDiscount(AppliedDiscountEntity appliedDiscount);
	void Delete(DiscountEntity discount);
	void DeleteAppliedDiscount(AppliedDiscountEntity appliedDiscount);
}