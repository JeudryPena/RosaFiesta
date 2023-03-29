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
        int? detailOptionId,
        CancellationToken cancellationToken = default);
    Task<AppliedDiscountEntity> GetAppliedDiscount(int purchaseNumber, CancellationToken cancellationToken = default);
    void UpdateAppliedDiscount(AppliedDiscountEntity discountApplied);
    void CreateAppliedDiscount(AppliedDiscountEntity discountApplied);
    void DeleteAppliedDiscount(AppliedDiscountEntity appliedDiscount);
    Task<DiscountEntity> GetByAppliedId(int? detailAppliedId, CancellationToken cancellationToken = default);
    Task<ICollection<ProductsDiscountsEntity>> GetDiscountPreviewsAsync(string productCode, int? optionId,
        CancellationToken cancellationToken = default);
}