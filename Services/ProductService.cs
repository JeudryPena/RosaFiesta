﻿using Contracts.Model.Product;
using Contracts.Model.Product.Response;

using Domain.Entities.Product;
using Domain.Entities.Security;
using Domain.Entities.Security.Helper;
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

	public async Task<ICollection<ProductsResponse>> ManagementGetAllAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<ProductEntity> products = await _repositoryManager.ProductRepository.ManagementGetAllAsync(cancellationToken);
		ICollection<ProductsResponse> productPreviewResponse = products.Adapt<ICollection<ProductsResponse>>();
		return productPreviewResponse;
	}

	public async Task<ICollection<ProductPreviewResponse>> GetAllAsyncPreview(CancellationToken cancellationToken = default)
	{
		IEnumerable<ProductEntity> products = await _repositoryManager.ProductRepository.GetAllAsync(cancellationToken);
		ICollection<ProductPreviewResponse> productPreviewResponse = products.Adapt<ICollection<ProductPreviewResponse>>();
		return productPreviewResponse;
	}

	public async Task<ProductResponse> GetByIdAsync(string productId, int optionId,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, optionId, cancellationToken);
		OptionEntity? option = product.Options.FirstOrDefault(x => x.Id == optionId);
		if (option == null)
			throw new Exception("Option not found");
		ProductResponse productResponse = product.Adapt<ProductResponse>();
		productResponse.OptionId = option.Id;
		return productResponse;
	}

	public async Task<ProductResponse> CreateAsync(string userId, ProductDto productForCreationDto,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = productForCreationDto.Adapt<ProductEntity>();
		product.Options = productForCreationDto.Options.Adapt<List<OptionEntity>>();
		if (productForCreationDto.Category != null)
		{
			CategoryEntity category = productForCreationDto.Category.Adapt<CategoryEntity>();
			if (productForCreationDto.Category.SubCategories != null)
			{
				category.SubCategories = productForCreationDto.Category.SubCategories.Adapt<List<SubCategoryEntity>>();
			}
			_repositoryManager.CategoryRepository.Insert(category);
			await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
			product.CategoryId = category.Id;
		}
		else
			product.CategoryId = productForCreationDto.CategoryId;
		_repositoryManager.ProductRepository.Insert(product);
		ActionLogEntity actionLog = new()
		{
			Action = ActivityAction.Created,
			UserId = userId,
			ActivityType = Activities.Product,
		};
		_repositoryManager.ActionLogRepository.Create(actionLog);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		ProductResponse productResponse = new();
		productResponse.Adapt(product);
		return productResponse;
	}

	public async Task<ProductResponse> UpdateAsync(string userId, int optionId, string productId,
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
		ActionLogEntity actionLog = new()
		{
			Action = ActivityAction.Updated,
			UserId = userId,
			ActivityType = Activities.Product,
		};
		_repositoryManager.ActionLogRepository.Create(actionLog);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		ProductResponse productAndOptionResponse = product.Adapt<ProductResponse>();
		return productAndOptionResponse;
	}

	public async Task DeleteAsync(string userId, string productId, int? optionId,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetProductById(productId, cancellationToken);
		ActionLogEntity actionLog = new()
		{
			ActivityType = Activities.Product,
			Action = ActivityAction.Deleted,
			UserId = userId,
		};
		if (optionId == null)
		{
			OptionEntity? option = product.Options.FirstOrDefault(x => x.Id == optionId);
			if (option == null)
				throw new Exception("Option not found");
			option.IsDeleted = true;
			_repositoryManager.ProductRepository.Update(product);
			actionLog.ActivityType = Activities.Option;
		}
		else
		{
			product.IsDeleted = true;
			_repositoryManager.ProductRepository.Update(product);
			actionLog.ActivityType = Activities.Option;
		}
		_repositoryManager.ActionLogRepository.Create(actionLog);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}

	public async Task<ProductDetailResponse> GetProductDetail(string productCode, int optionId,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetProductAndOption(productCode, optionId, cancellationToken);
		ProductDetailResponse productDetailResponse = product.Adapt<ProductDetailResponse>();
		productDetailResponse.Option = product.Options[0].Adapt<OptionDetailResponse>();
		productDetailResponse.WarrantyName = product.Warranty?.Name;
		return productDetailResponse;
	}

	public async Task<OptionAdjustResponse> AdjustOptionQuantityAsync(string userId, int optionId, string productId, int count, CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetProductAndOption(productId, optionId, cancellationToken);
		OptionEntity option = product.Options[0];
		option.QuantityAvaliable += count;
		_repositoryManager.ProductRepository.Update(product);
		ActionLogEntity actionLog = new()
		{
			Action = ActivityAction.Updated,
			UserId = userId,
			ActivityType = Activities.Product,
		};
		_repositoryManager.ActionLogRepository.Create(actionLog);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		OptionAdjustResponse optionAdjustResponse = option.Adapt<OptionAdjustResponse>();
		return optionAdjustResponse;
	}

	public async Task<ProductResponse> CreateOptionAsync(string userId, string productId,
		OptionDto optionForCreationDto,
		CancellationToken cancellationToken = default)
	{
		ProductEntity product = await _repositoryManager.ProductRepository.GetProductById(productId, cancellationToken);
		var option = optionForCreationDto.Adapt<OptionEntity>();
		product.Options.Add(option);
		_repositoryManager.ProductRepository.Update(product);
		ActionLogEntity actionLog = new()
		{
			Action = ActivityAction.Updated,
			UserId = userId,
			ActivityType = Activities.Option,
		};
		_repositoryManager.ActionLogRepository.Create(actionLog);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		ProductResponse optionResponse = new();
		optionResponse.Adapt(product);
		optionResponse.Adapt(option);
		return optionResponse;
	}
}