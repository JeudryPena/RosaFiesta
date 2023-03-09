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

    public async Task<ProductsResponse> CreateAsync(string? username, ProductEntityDto productForCreationDto,
        CancellationToken cancellationToken = default)
    {
        var product = new ProductEntity
        {
            Code = productForCreationDto.Code,
            Name = productForCreationDto.Name,
            Description = productForCreationDto.Description,
            Price = productForCreationDto.Price,
            Stock = 1.Adapt<StockStatusType>(),
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
        return product.Adapt<ProductsResponse>();
    }

    public async Task<IEnumerable<ProductsResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<ProductEntity> products = await _repositoryManager.ProductRepository.GetAllAsync(cancellationToken);
        var productsDto = products.Adapt<IEnumerable<ProductsResponse>>();
        return productsDto;
    }
}