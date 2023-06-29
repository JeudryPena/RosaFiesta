﻿using Contracts.Model.Product;
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

	public async Task<IEnumerable<OptionsListResponse>> GetOptionsAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<OptionEntity> options = await _repositoryManager.ProductRepository.GetOptionsAsync(cancellationToken);
		IEnumerable<OptionsListResponse> optionsListResponse = options.Adapt<IEnumerable<OptionsListResponse>>();
		return optionsListResponse;
	}

	public async Task<ProductResponse> GetByIdAsync(Guid productId,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
		ProductResponse productResponse = product.Adapt<ProductResponse>();
		return productResponse;
	}

	public async Task CreateAsync(string userId, ProductDto productForCreationDto,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = productForCreationDto.Adapt<ProductEntity>();
		_repositoryManager.ProductRepository.Insert(product);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task UpdateAsync(string userId, int optionId, Guid productId,
		ProductUpdateDto productForUpdateDto, CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetProductAndOption(productId, optionId, cancellationToken);
		OptionEntity? option = product.Options.FirstOrDefault(x => x.Id == optionId);
		if (option == null)
			throw new Exception("Option not found");
		option.Adapt(productForUpdateDto);
		product.Adapt(productForUpdateDto);
		product.Options.Add(option);
		_repositoryManager.ProductRepository.Update(product);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task DeleteAsync(string userId, Guid productId, int? optionId,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetProductById(productId, cancellationToken);
		if (optionId == null)
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

	public async Task<ProductDetailResponse> GetProductDetail(Guid productCode, int optionId,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetProductAndOption(productCode, optionId, cancellationToken);
		ProductDetailResponse productDetailResponse = product.Adapt<ProductDetailResponse>();
		productDetailResponse.Option = product.Options[0].Adapt<OptionDetailResponse>();
		productDetailResponse.WarrantyName = product.Warranty?.Name;
		return productDetailResponse;
	}

	public async Task<OptionAdjustResponse> AdjustOptionQuantityAsync(string userId, int optionId, Guid productId, int count, CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetProductAndOption(productId, optionId, cancellationToken);
		OptionEntity option = product.Options[0];
		option.QuantityAvailable += count;
		_repositoryManager.ProductRepository.Update(product);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		OptionAdjustResponse optionAdjustResponse = option.Adapt<OptionAdjustResponse>();
		return optionAdjustResponse;
	}
}