using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
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
	await _dbContext.Products.Include(x => x.Option).ThenInclude(x => x.Image).ToListAsync(cancellationToken);

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
		var product = await _dbContext.Products.Include(x => x.Options).FirstOrDefaultAsync(x => x.Id == productId, cancellationToken);
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

	public async Task<ProductEntity> GetDetailAsync(Guid id, Guid optionId,
		CancellationToken cancellationToken = default)
	{
		ProductEntity? product = await _dbContext.Products.Include(x => x.Options).ThenInclude(x => x.Images).Include(x => x.Warranty).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
		if (product == null)
			throw new ArgumentNullException(nameof(product));
		return product;
	}

	public async Task<double> CartItemPrice(Guid optionId, int quantity, CancellationToken cancellationToken = default)
	{
		OptionEntity? option = await _dbContext.Options.FirstOrDefaultAsync(x => x.QuantityAvailable >= quantity && x.Id == optionId, cancellationToken);
		if (option == null)
			throw new Exception("Option not found");
		if (option.QuantityAvailable < quantity)
			throw new Exception($"You are adding {quantity - option.QuantityAvailable} more items than the quantity available");
		return option.Price;
	}

	public async Task CheckOptionAviabilityAsync(Guid optionId, int quantity, CancellationToken cancellationToken = default)
	{
		OptionEntity? option = await _dbContext.Options.FirstOrDefaultAsync(x => x.Id == optionId, cancellationToken);
		if (option == null)
			throw new ArgumentNullException(nameof(option));
		if (option.QuantityAvailable < quantity)
			if (quantity < option.QuantityAvailable)
				throw new Exception($"You are adding {option. QuantityAvailable - option.QuantityAvailable} more items than the quantity available");
	}

	/// <summary>
	/// Get all recommended products
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<IEnumerable<ProductEntity>> GetAllRecommendedAsync(CancellationToken cancellationToken)
	{
		IEnumerable<ProductEntity> products = await _dbContext.Products.Include(x => x.Option).ThenInclude(x => x != null ? x.Image : null).Where(x => x.Views > 0).OrderByDescending(x => x.Views).Take(5).ToListAsync(cancellationToken);
		return products;
	}

	/// <summary>
	/// Search products
	/// </summary>
	/// <param name="filter"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<IEnumerable<ProductEntity>> FilterProductsAsync(SearchFilter filter,
		CancellationToken cancellationToken)
	{
		IEnumerable<ProductEntity> products = await _dbContext.Products.Include(x => x.Options).ThenInclude(x => x.Image).Include(x => x.Options).ThenInclude(x => x.Reviews).ToListAsync(cancellationToken);
		if(!string.IsNullOrEmpty(filter.SearchValue))
			products = products.Where(x => x.Options.Any(o => o.Title.ToLower().Contains(filter.SearchValue.ToLower())));
		if (filter.Condition is > 0)
			products = products.Where(x => x.Options.Any(o => o.Condition == (ConditionType)filter.Condition)).ToList();
		if (filter.CategoryId != null)
			products = products.Where(x => x.CategoryId == filter.CategoryId).ToList();
		if(filter.StartValue is > 0)
			products = products.Where(x => x.Options.Any(o => o.Price >= filter.StartValue)).ToList();
		if(filter.EndValue is > 0)
			products = products.Where(x => x.Options.Any(o => o.Price <= filter.EndValue)).ToList();
		if (filter.Rating is > 0)
			products = products.Where(x => x.Options.Any(o => o.Reviews is { Count: > 0 } && o.Reviews.Average(r => r.Rating) >= filter.Rating)).ToList();
			
		return products;
	}

	/// <summary>
	/// Retrieves related products
	/// </summary>
	/// <param name="categoryId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<IEnumerable<ProductEntity>> GetRelatedProducts(int categoryId, CancellationToken cancellationToken)
	{
		Guid random = Guid.NewGuid();
		ICollection<ProductEntity> products = await _dbContext.Products.Include(x => x.Option).ThenInclude(x => x.Image).Where(x => x.CategoryId == categoryId).OrderBy(r => random).Take(5).ToListAsync(cancellationToken);
		return products;
	}

	public async Task<IEnumerable<ProductEntity>> SearchProductsAsync(ProductsSearch filter, CancellationToken cancellationToken)
	{
		IEnumerable<ProductEntity> products = await _dbContext.Products.Include(x => x.Options).ThenInclude(x => x.Image).ToListAsync(cancellationToken);
		if(!string.IsNullOrEmpty(filter.SearchValue))
			products = products.Where(x => x.Options.Any(o => o.Title.ToLower().Contains(filter.SearchValue.ToLower())));
		if(filter.CategoryId != null)
			products = products.Where(x => x.CategoryId == filter.CategoryId);
			
		return products;
	}

	public async Task<bool> IsService(Guid optionProductId, CancellationToken cancellationToken)
	{
		 bool isService = await _dbContext.Products.AnyAsync(x => x.Id == optionProductId && x.IsService, cancellationToken);
		 return isService;
	}

	public async Task<int> GetCountViews(CancellationToken cancellationToken)
	{
		int count = await _dbContext.Products.SumAsync(x => x.Views, cancellationToken);
		return count;
	}

	public async Task<IEnumerable<MostPurchasedProducts>> GetMostPurchasedProductsAsync(
		CancellationToken cancellationToken)
	{
		IEnumerable<ProductEntity> products = await _dbContext.Products
			.Where(x => x.Details != null && x.Details.Count > 0).OrderByDescending(p =>
				p.Details.Where(x => x.CartId == null)
					.Sum(d => d.PurchaseOptions.Count + d.PurchaseOptions.Sum(o => o.Quantity))).Include(x => x.Option).Include(x => x.Details).ThenInclude(x => x.PurchaseOptions).Take(5)
			.ToListAsync(cancellationToken);
		
		IEnumerable<MostPurchasedProducts> mostPurchasedProducts = products.Select(x => new MostPurchasedProducts
		{
			Name = x.Option.Title,
			Value = x.Details.Where(x => x.CartId == null).Sum(d => d.PurchaseOptions.Count + d.PurchaseOptions.Sum(o => o.Quantity))
		});
		return mostPurchasedProducts;
	}

	public async Task VerifyIfOptionExists(string optionTitle, CancellationToken cancellationToken)
	{
		bool exists = await _dbContext.Options.AnyAsync(x => x.Title == optionTitle, cancellationToken);
		if (exists)
			throw new Exception("Ya existe una opción de producto con ese nombre");
	}

	public async Task VerifyIfOptionAlredyExists(string optionTitle, Guid optionId, CancellationToken cancellationToken)
	{
		bool exists = await _dbContext.Options.AnyAsync(x => x.Title == optionTitle && x.Id != optionId, cancellationToken);
		if (exists)
			throw new Exception("Ya existe una opción de producto con ese nuevo nombre");
	}

	public async Task<IEnumerable<MostPurchasedProductsWithDates>> GetMostPurchasedProductsWithDatesAsync(DateOnly start, DateOnly end, CancellationToken cancellationToken)
	{
		// IEnumerable<ProductEntity> products = await _dbContext.Products
		// 	.Where(x => x.Details != null && x.Details.Count > 0).OrderByDescending(p =>
		// 		p.Details.Where(x => x.CartId == null && x.Order.CreatedAt >= start && x.CreatedAt <= end)
		// 			.Sum(d => d.PurchaseOptions.Count + d.PurchaseOptions.Sum(o => o.Quantity))).Include(x => x.Option).Include(x => x.Details).ThenInclude(x => x.PurchaseOptions).Take(5)
		// 	.ToListAsync(cancellationToken);
		
		// IEnumerable<MostPurchasedProductsWithDates> mostPurchasedProducts = products.Select(x => new MostPurchasedProductsWithDates 
		// {
		// 	Name = x.Option.Title,
		// 	Series = new PurchasedProductsWithDates()
		// 	Value = x.Details.Where(x => x.CartId == null).Sum(d => d.PurchaseOptions.Count + d.PurchaseOptions.Sum(o => o.Quantity))
		// });
		IEnumerable<MostPurchasedProductsWithDates> mostPurchasedProducts = new List<MostPurchasedProductsWithDates>();
		return mostPurchasedProducts;
	}
} 