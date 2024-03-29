﻿using Domain.Entities.Product;

namespace Domain.IRepository;

public interface ICategoryRepository
{
	Task<IEnumerable<CategoryEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	void Insert(CategoryEntity category);
	Task<CategoryEntity> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default);
	void Update(CategoryEntity category);
	Task<CategoryEntity> GetManagementById(int categoryId, CancellationToken cancellationToken = default);
	void Delete(CategoryEntity category);
	Task<string> GetCategoryNameByProductIdAsync(Guid productId, CancellationToken cancellationToken);
	Task CheckIfCategoryExistsAsync(string categoryDtoName, CancellationToken cancellationToken);
}