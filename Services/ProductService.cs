using Contracts.Model.Product;
using Contracts.Model.Product.Response;

using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

internal sealed class ProductService : IProductService
{
	private readonly IRepositoryManager _repositoryManager;

	public ProductService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<ICollection<ProductsListResponse>> GetProductsList(CancellationToken cancellationToken = default)
	{
		IEnumerable<ProductEntity> products = await _repositoryManager.ProductRepository.GetProductsList(cancellationToken);
		ICollection<ProductsListResponse> productsListResponse = products.Adapt<ICollection<ProductsListResponse>>();
		return productsListResponse;
	}

	public async Task<ICollection<ManagementProductsResponse>> ManagementGetAllAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<ProductEntity> products = await _repositoryManager.ProductRepository.ManagementGetAllAsync(cancellationToken);
		foreach (var product in products)
		{
			product.CreatedBy = await _repositoryManager.UserRepository.GetUserName(product.CreatedBy, cancellationToken);
			if (product.UpdatedBy != null)
				product.UpdatedBy = await _repositoryManager.UserRepository.GetUserName(product.UpdatedBy, cancellationToken);
		}
		ICollection<ManagementProductsResponse> productsResponse = products.Adapt<ICollection<ManagementProductsResponse>>();
		return productsResponse;
	}

	public async Task<ICollection<ProductPreviewResponse>> GetAllAsyncPreview(CancellationToken cancellationToken = default)
	{
		IEnumerable<ProductEntity> products = await _repositoryManager.ProductRepository.GetAllAsync(cancellationToken);
		ICollection<ProductPreviewResponse> productPreviewResponse = products.Adapt<ICollection<ProductPreviewResponse>>();
		return productPreviewResponse;
	}

	public async Task<ProductResponse> GetByIdAsync(Guid productId,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
		ProductResponse productResponse = product.Adapt<ProductResponse>();
		productResponse.CreatedBy = await _repositoryManager.UserRepository.GetUserName(product.CreatedBy, cancellationToken);
		if (product.UpdatedBy != null)
			productResponse.UpdatedBy = await _repositoryManager.UserRepository.GetUserName(product.UpdatedBy, cancellationToken);
		return productResponse;
	}

	public async Task CreateAsync(string userId, ProductDto productDto,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = productDto.Adapt<ProductEntity>();

		_repositoryManager.ProductRepository.Insert(product);
		foreach (var option in product.Options)
		{
			await _repositoryManager.ProductRepository.VerifyIfOptionExists(option.Title, cancellationToken);
		}
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		
		ProductEntity newProduct = await _repositoryManager.ProductRepository.GetProductWithOption(product.Id, cancellationToken);
		newProduct.OptionId = newProduct.Options[productDto.OptionIndex].Id;
		int index = 0;
		foreach (var option in newProduct.Options)
		{
			if (option.Images != null)
				option.ImageId = option.Images.ElementAt(productDto.Options.ElementAt(index).ImageIndex).Id;
			index++;
		}
		_repositoryManager.ProductRepository.Update(newProduct);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task UpdateAsync(string userId, Guid productId,
		ProductDto productDto, CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
		product.Code = productDto.Code;
		product.IsService = productDto.IsService;
		product.CategoryId = productDto.CategoryId;
		product.WarrantyId = productDto.WarrantyId;
		product.SupplierId = productDto.SupplierId;
		List<MultipleOptionImagesEntity> multipleImagesResponses = new List<MultipleOptionImagesEntity>();
		
		foreach(var option in product.Options)
		{
			if (!productDto.Options.Any(x => x.Id == option.Id))
			{
				option.IsDeleted = true;
			}
		}
		_repositoryManager.ProductRepository.Update(product);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		
		foreach(var opt in productDto.Options)
		{
			OptionEntity option = new OptionEntity();
			if (opt.Id != null)
			{
				option = await _repositoryManager.ProductRepository.GetOptionByIdAsync((Guid)opt.Id, cancellationToken);
				await _repositoryManager.ProductRepository.VerifyIfOptionAlredyExists(opt.Title, option.Id, cancellationToken);
			}
			else
			{
				option.Id = Guid.NewGuid();
			}
			
			option.Title = opt.Title;
			option.Description = opt.Description;
			option.Price = opt.Price;
			option.QuantityAvailable = opt.QuantityAvailable;
			option.Color = opt.Color;
			option.GenderFor = (GenderType)opt.GenderFor;
			option.Condition = (ConditionType)opt.Condition;
			option.Images.Clear();
			option.Image = null;
			option.ImageId = null;
			_repositoryManager.ProductRepository.UpdateOption(option);
			foreach(var optionDto in opt.Images)
			{
				MultipleOptionImagesEntity multipleOptionImagesEntity = new MultipleOptionImagesEntity
				{
					Id = Guid.NewGuid(),
					Image = optionDto.Image,
					OptionId = option.Id
				};
				multipleImagesResponses.Add(multipleOptionImagesEntity);
			}
		}
		_repositoryManager.ProductRepository.AddRangeImages(multipleImagesResponses);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		ProductEntity newProduct = await _repositoryManager.ProductRepository.GetProductWithOption(product.Id, cancellationToken);
		newProduct.OptionId = newProduct.Options[productDto.OptionIndex].Id;
		int index = 0;
		foreach (var option in newProduct.Options.Where(x => x.IsDeleted == false))
		{
			if (option.Images != null)
				option.ImageId = option.Images.ElementAt(productDto.Options.ElementAt(index).ImageIndex).Id;
			index++;
		}
		_repositoryManager.ProductRepository.Update(newProduct);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task DeleteAsync(string userId, Guid productId, Guid? optionId,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetProductById(productId, cancellationToken);
		if (optionId != null)
		{
			OptionEntity? option = product.Options.FirstOrDefault(x => x.Id == optionId);
			if (option == null)
				throw new Exception("Option not found");
			_repositoryManager.ProductRepository.DeleteOption(option);
		}
		else
			_repositoryManager.ProductRepository.Delete(product);

		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	/// <summary>
	/// Retrieve product detail
	/// </summary>
	/// <param name="id"></param>
	/// <param name="optionId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<ProductDetailResponse> GetProductDetail(Guid id,
		Guid optionId,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetDetailAsync(id, optionId, cancellationToken);
		product.Option = product.Options.FirstOrDefault(x => x.Id == optionId);
		ProductDetailResponse productDetailResponse = product.Adapt<ProductDetailResponse>();
		return productDetailResponse;
	}

	public async Task AdjustOptionQuantityAsync(string userId, Guid optionId, Guid productId, int count, CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetProductAndOption(productId, optionId, cancellationToken);
		OptionEntity option = product.Options[0];
		option.QuantityAvailable += count;
		_repositoryManager.ProductRepository.Update(product);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task<IList<string>> GetOptionImages(Guid optionId, CancellationToken cancellationToken)
	{
		List<string> images = await _repositoryManager.ProductRepository.GetOptionImages(optionId, cancellationToken);
		return images;
	}

	public async Task<ICollection<OptionsListResponse>> GetOptionsList(CancellationToken cancellationToken = default)
	{
		IEnumerable<OptionEntity> options = await _repositoryManager.ProductRepository.GetOptionsList(cancellationToken);
		ICollection<OptionsListResponse> optionsListResponse = options.Adapt<ICollection<OptionsListResponse>>();
		return optionsListResponse;
	}

	/// <summary>
	/// Increase the view count of a product
	/// </summary>
	/// <param name="productId"></param>
	/// <param name="cancellationToken"></param>
	public async Task ViewAsync(Guid productId, CancellationToken cancellationToken)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetProductById(productId, cancellationToken);
		product.Views++;
		_repositoryManager.ProductRepository.Update(product);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}

	/// <summary>
	/// Get recommended products
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<ICollection<ProductPreviewResponse>> GetRecommendedProducts(CancellationToken cancellationToken)
	{
		IEnumerable<ProductEntity> products = await _repositoryManager.ProductRepository.GetAllRecommendedAsync(cancellationToken);
		ICollection<ProductPreviewResponse> productPreviewResponse = products.Adapt<ICollection<ProductPreviewResponse>>();
		return productPreviewResponse;
	}

	/// <summary>
	/// Filter products
	/// </summary>
	/// <param name="filter"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<ICollection<ProductPreviewResponse>> FilterProductAsyncPreview(
		FilteredSearchDto filter, CancellationToken cancellationToken)
	{
		SearchFilter searchFilter = filter.Adapt<SearchFilter>(); 
		IEnumerable<ProductEntity> products = await _repositoryManager.ProductRepository.FilterProductsAsync( searchFilter, cancellationToken);
		ICollection<ProductPreviewResponse> productPreviewResponse = products.Adapt<ICollection<ProductPreviewResponse>>();
		return productPreviewResponse;
	}
	
	/// <summary>
	/// Retrieves related products
	/// </summary>
	/// <param name="categoryId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<ICollection<ProductPreviewResponse>> GetRelatedProducts(int categoryId, CancellationToken cancellationToken)
	{
		IEnumerable<ProductEntity> products = await _repositoryManager.ProductRepository.GetRelatedProducts(categoryId, cancellationToken);
		ICollection<ProductPreviewResponse> productPreviewResponse = products.Adapt<ICollection<ProductPreviewResponse>>();
		return productPreviewResponse;
	}

	/// <summary>
	/// Search products
	/// </summary>
	/// <param name="filter"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<ICollection<ProductPreviewResponse>> SearchProductsAsync(FilteredSearchDto filter, CancellationToken cancellationToken)
	{
		ProductsSearch searchFilter = filter.Adapt<ProductsSearch>(); 
		IEnumerable<ProductEntity> products = await _repositoryManager.ProductRepository.SearchProductsAsync( searchFilter, cancellationToken);
		ICollection<ProductPreviewResponse> productPreviewResponse = products.Adapt<ICollection<ProductPreviewResponse>>();
		return productPreviewResponse;
	}

	public async Task<int> GetCountViews(CancellationToken cancellationToken)
	{
		int count = await _repositoryManager.ProductRepository.GetCountViews(cancellationToken);
		return count;
	}


	public async Task<IEnumerable<MostPurchasedProductsResponse>> GetMostPurchasedProductsAsync(CancellationToken cancellationToken)
	{
		IEnumerable<MostPurchasedProducts> mostPurchasedProducts = await _repositoryManager.ProductRepository.GetMostPurchasedProductsAsync(cancellationToken);
		IEnumerable<MostPurchasedProductsResponse> mostPurchasedProductsResponse = mostPurchasedProducts.Adapt<IEnumerable<MostPurchasedProductsResponse>>();
		return mostPurchasedProductsResponse;
	}

	public async Task<IEnumerable<MostPurchasedProductsWithDatesResponse>> GetMostPurchasedProductsWithDatesAsync(DateOnly start,
		DateOnly end, CancellationToken cancellationToken)
	{
		IEnumerable<MostPurchasedProductsWithDates> mostPurchasedProducts = await _repositoryManager.ProductRepository.GetMostPurchasedProductsWithDatesAsync(start, end, cancellationToken);
		IEnumerable<MostPurchasedProductsWithDatesResponse> mostPurchasedProductsResponse = mostPurchasedProducts.Adapt<IEnumerable<MostPurchasedProductsWithDatesResponse>>();
		return mostPurchasedProductsResponse;
	}
}