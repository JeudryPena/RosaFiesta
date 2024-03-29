﻿using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;

using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

internal sealed class WishListService : IWishListService
{
	private readonly IRepositoryManager _repositoryManager;

	public WishListService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<WishListResponse> GetWishListAsync(string userId, CancellationToken cancellationToken = default)
	{
		WishListEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishWithProducts(userId, cancellationToken);
		var wishListResponse = wishListEntity.Adapt<WishListResponse>();
		return wishListResponse;
	}

	public async Task CreateWishListAsync(WishListDto wishList, string userId,
		CancellationToken cancellationToken = default)
	{
		WishListEntity wishListEntity = wishList.Adapt<WishListEntity>();
		if (wishList.OptionsId != null)
		{
			wishListEntity.ProductsWish = new List<WishListProductsEntity>();
			foreach (var i in wishList.OptionsId)
			{
				wishListEntity.ProductsWish.Add(new()
				{
					WishListId = wishListEntity.Id,
					OptionId = i,
				});
			}
		}
		_repositoryManager.WishListRepository.Insert(wishListEntity);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}

	public async Task AddProductsToWishListAsync(string userId,
		List<ProductsWishListDto> wishListDto, CancellationToken cancellationToken = default)
	{
		WishListEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishListByIdAsync(userId, cancellationToken);
		if (wishListEntity.ProductsWish == null)
			wishListEntity.ProductsWish = new List<WishListProductsEntity>();
		foreach (var i in wishListDto)
		{
			var option = wishListEntity.ProductsWish.FirstOrDefault(x => x.OptionId == i.OptionId);
			if (option != null)
			{
				if (option.IsDeleted)
					option.IsDeleted = false;
				else
					throw new Exception("El producto ya esta en tu lista de Deseos.");
			}
			
			wishListEntity.ProductsWish.Add(new()
			{
				WishListId = wishListEntity.Id,
				OptionId = i.OptionId,
			});
		}
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}

	/// <summary>
	/// Add product to wish list
	/// </summary>
	/// <param name="userId"></param>
	/// <param name="optionId"></param>
	/// <param name="cancellationToken"></param>
	public async Task AddProductsToWishListAsync(string userId, Guid optionId, CancellationToken cancellationToken = default)
	{
		WishListEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishListByIdAsync(userId, cancellationToken);
		if (wishListEntity.ProductsWish == null)
			wishListEntity.ProductsWish = new List<WishListProductsEntity>();
		var option = wishListEntity.ProductsWish.FirstOrDefault(x => x.OptionId == optionId);
		if (option != null)
		{
			if (option.IsDeleted)
				option.IsDeleted = false;
			else
				throw new Exception("El producto ya esta en tu lista de Deseos.");
		}
		else
		{
			wishListEntity.ProductsWish.Add(new()
			{
				WishListId = wishListEntity.Id,
				OptionId = optionId
			});
		}

		_repositoryManager.WishListRepository.Update(wishListEntity);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}

	public async Task DeleteProductFromWishListAsync(Guid wishListId, Guid optionId, CancellationToken cancellationToken)
	{
		WishListProductsEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishListOption(wishListId, optionId, cancellationToken);
		_repositoryManager.WishListRepository.DeleteProduct(wishListEntity);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}

	public async Task DeleteAllProductsFromWishListAsync(string userId, CancellationToken cancellationToken = default)
	{
		WishListEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishListByIdAsync(userId, cancellationToken);
		if (wishListEntity.ProductsWish == null)
			throw new Exception("La lista de Deseos ya esta vacía.");
		wishListEntity.ProductsWish.Clear();
		_repositoryManager.WishListRepository.Update(wishListEntity);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}
}