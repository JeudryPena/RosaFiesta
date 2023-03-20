using Contracts.Model;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Domain.Entities;
using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Security;
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

    public async Task<ICollection<ProductPreviewResponse>> GetAllAsyncPreview(CancellationToken cancellationToken = default)
    {
        IEnumerable<ProductEntity> products = await _repositoryManager.ProductRepository.GetAllAsync(cancellationToken);
        ICollection<ProductPreviewResponse> productPreviewResponse = products.Adapt<ICollection<ProductPreviewResponse>>();
        foreach (var pr in productPreviewResponse)
        {
            foreach (var p in products)
            {
                if (p.Code == pr.Code)
                {
                    pr.AverageRating = p.Reviews.Average(r => r.ReviewRating);
                    pr.TotalReviews = p.Reviews.Count;
                }
            } 
        }
        return productPreviewResponse;
    }

    public async Task<ProductsResponse> GetByIdAsync(string productId, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
        ProductsResponse productResponse = product.Adapt<ProductsResponse>();
        return productResponse;
    }
    
    public async Task<ProductsResponse> CreateAsync(string? username, ProductDto productForCreationDto,
        CancellationToken cancellationToken = default)
    {
        var product = new ProductEntity
        {
            Code = productForCreationDto.Code,
            Tittle = productForCreationDto.Name,
            Description = productForCreationDto.Description,
            Price = productForCreationDto.Price,
            QuantityAvaliable = productForCreationDto.Quantity,
            Brand = productForCreationDto.Brand,
            Color = productForCreationDto.Color,
            Size = productForCreationDto.Size,
            Type = productForCreationDto.Type.Adapt<ProductType>(),
            Condition = productForCreationDto.Condition.Adapt<ConditionType>(),
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = username,
            WarrantyId = productForCreationDto.WarrantyId,
            SupplierId = productForCreationDto.SupplierId,
        };
        product.GenderFor = (productForCreationDto.GenderFor ?? 0).Adapt<GenderType>();
        product.Material = (productForCreationDto.Material ?? 0).Adapt<MaterialType>();

        if (productForCreationDto.Category != null)
        {
            var category = new CategoryEntity
            {
                Name = productForCreationDto.Category.Name,
                Description = productForCreationDto.Category.Description,
                CreatedAt = DateTimeOffset.UtcNow,
                CreatedBy = username,
                Icon = productForCreationDto.Category.Icon,
                Slug = productForCreationDto.Category.Slug,
                IsActive = productForCreationDto.Category.IsActive,
            };
            if (productForCreationDto.Category.SubCategories != null)
            {
                category.SubCategories = productForCreationDto.Category.SubCategories.Adapt<List<SubCategoryEntity>>();
                foreach (var subCategory in category.SubCategories)
                {
                    subCategory.CreatedAt = DateTimeOffset.UtcNow;
                    subCategory.CreatedBy = username;
                } 
            }
            _repositoryManager.CategoryRepository.Insert(category);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            product.CategoryId = category.Id;
        }
        else
            product.CategoryId = productForCreationDto.CategoryId;
        
        _repositoryManager.ProductRepository.Insert(product);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        var productResponse = product.Adapt<ProductsResponse>();
        return productResponse;
    }

    public async Task<ProductsResponse> UpdateAsync(string? username, string productId,
        ProductUpdateDto productForUpdateDto, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
        product.Code = productForUpdateDto.Code;
        product.Tittle = productForUpdateDto.Name;
        product.Description = productForUpdateDto.Description;
        product.Price = productForUpdateDto.Price;
        product.Brand = productForUpdateDto.Brand;
        product.Color = productForUpdateDto.Color;
        product.Size = productForUpdateDto.Size;
        product.Type = productForUpdateDto.Type.Adapt<ProductType>();
        product.Condition = productForUpdateDto.Condition.Adapt<ConditionType>();
        product.UpdatedAt = DateTimeOffset.UtcNow;
        product.UpdatedBy = username;
        product.WarrantyId = productForUpdateDto.WarrantyId;
        product.GenderFor = (productForUpdateDto.GenderFor ?? 0).Adapt<GenderType>();
        product.Material = (productForUpdateDto.Material ?? 0).Adapt<MaterialType>();

        _repositoryManager.ProductRepository.Update(product);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        ProductsResponse productsResponse = product.Adapt<ProductsResponse>();
        return productsResponse;
        
    }

    public async Task DeleteAsync(string productId, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
        _repositoryManager.ProductRepository.Delete(product);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<ProductAdjustResponse> AdjustProductQuantityAsync(string? username, string productId, int count, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
        product.QuantityAvaliable += count;
        product.UpdatedAt = DateTimeOffset.UtcNow;
        product.UpdatedBy = username;
        _repositoryManager.ProductRepository.Update(product);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        ProductAdjustResponse productAdjustResponse = product.Adapt<ProductAdjustResponse>();
        return productAdjustResponse;
    }

    public async Task<ProductDetailResponse> GetProductDetail(string productCode, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productCode, cancellationToken);
        ProductDetailResponse productResponse = product.Adapt<ProductDetailResponse>();
        return productResponse;
    }
}