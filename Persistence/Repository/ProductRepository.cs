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
	await _dbContext.Products.Include(x => x.Options).Include(x => x.Category).ToListAsync(cancellationToken);

	public async Task<IEnumerable<ProductEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
	await _dbContext.Products.Include(x => x.Options).ThenInclude(x => x.Reviews).ToListAsync(cancellationToken);

	public async Task<ProductEntity> GetProductDetail(Guid cartItemProductId, Guid optionId,
		CancellationToken cancellationToken = default)
	{
		var product = await _dbContext.Products.Include(x => x.Options.Where(x => x.Id == optionId)).FirstOrDefaultAsync(x => x.Id == cartItemProductId, cancellationToken);
		if (product == null)
			throw new ArgumentNullException(nameof(product));
		if (product.IsDeleted)
			throw new ArgumentNullException(nameof(product));
		return product;
	}

	public async Task<ProductEntity> GetProductAndOption(Guid productId, Guid optionId, CancellationToken cancellationToken = default)
	{
		var product = await _dbContext.Products.Include(x => x.Options).FirstOrDefaultAsync(x => x.Id == productId, cancellationToken);
		if (product == null)
			throw new ArgumentNullException(nameof(product));
		return product;
	}

	public async Task<ProductEntity> GetProductById(Guid productId, CancellationToken cancellationToken = default)
	{
		var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId, cancellationToken);
		if (product == null)
			throw new ArgumentNullException(nameof(product));
		return product;
	}

	public async Task<string> GetOptionTitle(Guid optionId, CancellationToken cancellationToken)
	{
		var option = await _dbContext.Options.FirstOrDefaultAsync(x => x.Id == optionId, cancellationToken);
		if (option == null)
			throw new ArgumentNullException(nameof(option));
		return option.Title;
	}

	public void UpdateOption(OptionEntity option)
	=> _dbContext.Options.Update(option);

	public async Task<ProductEntity> GetByIdAsync(Guid productId,
		CancellationToken cancellationToken = default)
	{
		var product = await _dbContext.Products.Include(x => x.Options).ThenInclude(x => x.Images).Include(x => x.Category).Include(x => x.Warranty).Include(x => x.Supplier).FirstOrDefaultAsync(x => x.Id == productId, cancellationToken);
		if (product == null)
			throw new ArgumentNullException(nameof(product));
		return product;
	}

	public async Task<OptionEntity> GetOptionByIdAsync(Guid? optionId, CancellationToken cancellationToken = default)
	{
		var option = await _dbContext.Options.FirstOrDefaultAsync(x => x.Id == optionId, cancellationToken);
		if (option == null)
			throw new ArgumentNullException(nameof(option));
		return option;
	}

	public void Update(ProductEntity product)
	{
		_dbContext.Products.Update(product);
	}

	public void Insert(ProductEntity product)
		=> _dbContext.Products.Add(product);

	public void DeleteOption(OptionEntity option)
	=> _dbContext.Options.Remove(option);

	public void Delete(ProductEntity product)
	=> _dbContext.Products.Remove(product);

	public async Task<List<string>> GetOptionImages(Guid optionId, CancellationToken cancellationToken)
	{
		List<string> images = await _dbContext.OptionImages.Where(x => x.OptionId == optionId).Select(x => x.Image).ToListAsync(cancellationToken);
		return images;
	}

	public async Task<IEnumerable<ProductEntity>> GetProductsList(CancellationToken cancellationToken = default)
	{
		IEnumerable<ProductEntity> products = await _dbContext.Products.Include(x => x.Option).ToListAsync(cancellationToken);
		return products;
	}

	public async Task<OptionEntity> GetOptionByIdAsync(Guid optionId, CancellationToken cancellationToken = default)
	{
		var option = await _dbContext.Options.FirstOrDefaultAsync(x => x.Id == optionId, cancellationToken);
		if (option == null)
			throw new ArgumentNullException(nameof(option));
		return option;
	}

	public void InsertOptions(ICollection<OptionEntity> options)
	{
		_dbContext.Options.AddRange(options);
	}

	public void InsertOptionImages(IList<MultipleOptionImagesEntity> images)
	{
		_dbContext.OptionImages.AddRange(images);
	}

	public async Task<ProductEntity> GetProductWithOption(Guid id, CancellationToken cancellationToken)
	{
		var product = await _dbContext.Products.Include(x => x.Options).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
		if (product == null)
			throw new ArgumentNullException(nameof(product));
		return product;
	}

	public async Task<IEnumerable<OptionEntity>> GetOptionsList(CancellationToken cancellationToken = default) => await _dbContext.Options.ToListAsync(cancellationToken);
}