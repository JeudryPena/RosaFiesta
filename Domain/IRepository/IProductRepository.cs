using Domain.Entities.Product;

namespace Domain.IRepository;

public interface IProductRepository
{
	void Insert(ProductEntity product);
	Task<IEnumerable<ProductEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<ProductEntity>> ManagementGetAllAsync(CancellationToken cancellationToken = default);
	Task<ProductEntity> GetByIdAsync(string productId, int cartItemOptionId,
		CancellationToken cancellationToken = default);
	Task<OptionEntity> GetOptionByIdAsync(int? optionId, CancellationToken cancellationToken = default);
	void Update(ProductEntity product);
	Task<ProductEntity> GetProductDetail(string cartItemProductId, int optionId,
		CancellationToken cancellationToken = default);
	Task<ProductEntity> GetProductAndOption(string productCode, int optionId, CancellationToken cancellationToken = default);
	Task<ProductEntity> GetProductById(string productId, CancellationToken cancellationToken = default);
	void UpdateOption(OptionEntity option);
}