using Domain.Entities;
using Domain.Entities.Product;

namespace Domain.IRepository;

public interface IProductRepository
{
    void Insert(ProductEntity product);
    Task<IEnumerable<ProductEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProductEntity> GetByIdAsync(string productId, CancellationToken cancellationToken = default);
    Task<OptionEntity> GetOptionByIdAsync(int optionId, CancellationToken cancellationToken = default);
    void Update(ProductEntity product);
    void Delete(ProductEntity product);
    void UpdateRange(List<ProductEntity> listProducts);
    void InsertOptions(OptionEntity option);
    void DeleteOption(OptionEntity option);
    void UpdateOption(OptionEntity detailOption);
    Task<IEnumerable<OptionEntity>> GetAllOptionAsync(CancellationToken cancellationToken = default);
}