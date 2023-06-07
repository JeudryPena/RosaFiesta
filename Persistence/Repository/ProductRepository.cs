using Domain.Entities.Product;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public class ProductRepository : IProductRepository
{
	private readonly RosaFiestaContext _dbContext;

	public ProductRepository(RosaFiestaContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IEnumerable<ProductEntity>> ManagementGetAllAsync(CancellationToken cancellationToken = default) =>
	await _dbContext.Products.Include(x => x.Options).Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);

	public async Task<IEnumerable<ProductEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
	await _dbContext.Products.Where(x => x.IsDeleted == false).Include(x => x.Options).ThenInclude(x => x.Reviews).ToListAsync(cancellationToken);

	public async Task<ProductEntity> GetProductDetail(string cartItemProductId, int optionId,
		CancellationToken cancellationToken = default)
	{
		var product = await _dbContext.Products.Include(x => x.Options.Where(x => x.Id == optionId)).FirstOrDefaultAsync(x => x.Code == cartItemProductId, cancellationToken);
		if (product == null)
			throw new ArgumentNullException(nameof(product));
		if (product.IsDeleted)
			throw new ArgumentNullException(nameof(product));
		return product;
	}

	public async Task<ProductEntity> GetProductAndOption(string productCode, int optionId, CancellationToken cancellationToken = default)
	{
		var product = await _dbContext.Products.Include(x => x.Options).FirstOrDefaultAsync(x => x.Code == productCode, cancellationToken);
		if (product == null)
			throw new ArgumentNullException(nameof(product));
		if (product.IsDeleted)
			throw new ArgumentNullException(nameof(product));
		return product;
	}

	public async Task<ProductEntity> GetProductById(string productId, CancellationToken cancellationToken = default)
	{
		var product = await _dbContext.Products.Include(x => x.Options).FirstOrDefaultAsync(x => x.Code == productId, cancellationToken);
		if (product == null)
			throw new ArgumentNullException(nameof(product));
		if (product.IsDeleted)
			throw new ArgumentNullException(nameof(product));
		return product;
	}

	public void UpdateOption(OptionEntity option)
	=> _dbContext.Options.Update(option);

	public async Task<ProductEntity> GetByIdAsync(string productId, int cartItemOptionId,
		CancellationToken cancellationToken = default)
	{
		var product = await _dbContext.Products.Include(p => p.Supplier).Include(p => p.Warranty).Include(x => x.Options).ThenInclude(x => x.Reviews).FirstOrDefaultAsync(x => x.Code == productId, cancellationToken);
		if (product == null)
			throw new ArgumentNullException(nameof(product));
		if (product.IsDeleted)
			throw new ArgumentNullException(nameof(product));
		return product;
	}

	public async Task<OptionEntity> GetOptionByIdAsync(int? optionId, CancellationToken cancellationToken = default)
	{
		var option = await _dbContext.Options.FirstOrDefaultAsync(x => x.Id == optionId, cancellationToken);
		if (option == null)
			throw new ArgumentNullException(nameof(option));
		if (option.IsDeleted)
			throw new ArgumentNullException(nameof(option));
		return option;
	}

	public void Update(ProductEntity product)
	{
		if (product.Options.Any(x => !x.IsDeleted))
			product.IsDeleted = false;
		_dbContext.Products.Update(product);
	}

	public void Insert(ProductEntity product)
		=> _dbContext.Products.Add(product);
}