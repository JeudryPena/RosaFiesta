using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IDiscountRepository
{
    Task<IEnumerable<DiscountEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<DiscountEntity> GetByIdAsync(string discountId, CancellationToken cancellationToken = default);
    void Insert(DiscountEntity discountEntity);
    void Update(DiscountEntity discount);
    void Delete(DiscountEntity discount);
    Task<DiscountEntity> GetValidDiscountAsync(string discountCode, string productId,
        CancellationToken cancellationToken = default);
    Task<AppliedDiscountEntity> GetAppliedDiscount(string userId, string discountCode, CancellationToken cancellationToken = default);
    void UpdateAppliedDiscount(AppliedDiscountEntity discountApplied);
}