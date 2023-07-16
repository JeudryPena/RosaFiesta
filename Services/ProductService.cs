using Contracts.Model.Product;
using Contracts.Model.Product.Response;

using Domain.Entities.Product;
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
		return productResponse;
	}

	public async Task CreateAsync(string userId, ProductDto productDto,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = productDto.Adapt<ProductEntity>();
		_repositoryManager.ProductRepository.Insert(product);
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
		product = productDto.Adapt(product);
		_repositoryManager.ProductRepository.Update(product);
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

	public async Task<ProductDetailResponse> GetProductDetail(Guid productCode, Guid optionId,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetProductAndOption(productCode, optionId, cancellationToken);
		ProductDetailResponse productDetailResponse = product.Adapt<ProductDetailResponse>();
		productDetailResponse.Option = product.Options[0].Adapt<OptionDetailResponse>();
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
}