using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IDiscountRepository
{
    Task<IEnumerable<DiscountEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<DiscountEntity> GetByIdAsync(string discountId, CancellationToken cancellationToken = default);
    void Insert(DiscountEntity discountEntity);
    void Update(DiscountEntity discount);
    Task<AppliedDiscountEntity> GetAppliedDiscount(int purchaseNumber, CancellationToken cancellationToken = default);
    Task<DiscountEntity> GetByAppliedId(int? detailAppliedId, CancellationToken cancellationToken = default);
    Task<ICollection<DiscountEntity>> GetValidDiscountsPreview(string userId, string productCode, int optionId,
        CancellationToken cancellationToken = default);
    Task<DiscountEntity> GetDiscountAsync(string discountId, CancellationToken cancellationToken = default);
    Task<DiscountEntity> GetValidDiscount(string productCode, int optionId, string userId,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<DiscountEntity>> ManagementGetAllAsync(CancellationToken cancellationToken = default);
	void DeleteAppliedDiscount(AppliedDiscountEntity appliedDiscount);
}