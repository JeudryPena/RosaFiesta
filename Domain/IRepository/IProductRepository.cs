using Domain.Entities.Product;

namespace Domain.IRepository;

public interface IProductRepository
{
	void Insert(ProductEntity product);
	Task<IEnumerable<ProductEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<ProductEntity>> ManagementGetAllAsync(CancellationToken cancellationToken = default);
	Task<ProductEntity> GetByIdAsync(Guid productId,
		CancellationToken cancellationToken = default);
	Task<OptionEntity> GetOptionByIdAsync(int? optionId, CancellationToken cancellationToken = default);
	void Update(ProductEntity product);
	Task<ProductEntity> GetProductDetail(Guid cartItemProductId, int optionId,
		CancellationToken cancellationToken = default);
	Task<ProductEntity> GetProductAndOption(Guid productCode, int optionId, CancellationToken cancellationToken = default);
	Task<ProductEntity> GetProductById(Guid productId, CancellationToken cancellationToken = default);
	void UpdateOption(OptionEntity option);
	void DeleteOption(OptionEntity option);
	void Delete(ProductEntity product);
	Task<IEnumerable<OptionEntity>> GetOptionsAsync(CancellationToken cancellationToken);
	Task<string> GetOptionTitle(int optionId, CancellationToken cancellationToken);
	Task<List<string>> GetOptionImages(int optionId, CancellationToken cancellationToken);
	Task<IEnumerable<ProductEntity>> GetProductsList(CancellationToken cancellationToken = default);
}