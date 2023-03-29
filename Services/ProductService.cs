using Contracts.Model;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Domain.Entities;
using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Domain.Entities.Security;
using Domain.Exceptions;
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
        return productPreviewResponse;
    }
    
    public async Task<ICollection<OptionPreviewResponse>> GetAllOptionsPreview(CancellationToken cancellationToken = default)
    {
        IEnumerable<OptionEntity> options = await _repositoryManager.ProductRepository.GetAllOptionAsync(cancellationToken);
        ICollection<OptionPreviewResponse> optionPreviewResponse = options.Adapt<ICollection<OptionPreviewResponse>>();
        return optionPreviewResponse;
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
        ProductEntity product = productForCreationDto.Adapt<ProductEntity>();
        product.CreatedAt = DateTimeOffset.UtcNow;
        product.CreatedBy = username;
        if (productForCreationDto.Options != null)
            product.Options = productForCreationDto.Options.Adapt<List<OptionEntity>>();
        if (productForCreationDto.Category != null)
        {
            CategoryEntity category = productForCreationDto.Category.Adapt<CategoryEntity>();
            category.CreatedAt = DateTimeOffset.UtcNow;
            category.CreatedBy = username;
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
        product.Title = productForUpdateDto.Tittle ?? product.Title;
        product.Price = productForUpdateDto.Price ?? product.Price;
        product.Adapt<ProductUpdateDto>();
        product.UpdatedAt = DateTimeOffset.UtcNow;
        product.UpdatedBy = username;
        if (productForUpdateDto.Type != null) product.Type = productForUpdateDto.Type.Adapt<ProductType>();
        if (productForUpdateDto.Condition != null)
            product.Condition = productForUpdateDto.Condition.Adapt<ConditionType>();

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

    public async Task DeleteOptionAsync(string productId, int optionId, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
        if (product.Options == null)
            throw new Exception("Product has no options");
        OptionEntity? option = product.Options.FirstOrDefault(x => x.Id == optionId);
        if (option == null)
            throw new Exception("Option not found");
        product.Options.Remove(option);
        _repositoryManager.ProductRepository.Update(product);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteOptionsAsync(string productId, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
        if (product.Options == null)
            throw new Exception("Product has no options");
        product.Options.Clear();
        _repositoryManager.ProductRepository.Update(product);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<OptionAdjustResponse> AdjustOptionQuantityAsync(string? username, int optionId, string productId, int count,
        CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
        if(product.Options == null)
            throw new Exception("Product has no options");
        OptionEntity? option = product.Options.FirstOrDefault(x => x.Id == optionId);
        if (option == null)
            throw new Exception("Option not found");
        option.QuantityAvaliable += count;
        product.UpdatedBy = username;
        product.UpdatedAt = DateTimeOffset.UtcNow;
        _repositoryManager.ProductRepository.Update(product);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        OptionAdjustResponse optionAdjustResponse = option.Adapt<OptionAdjustResponse>();
        return optionAdjustResponse;
    }

    public async Task<OptionResponse> UpdateOptionAsync(string? username, int optionId, string productId,
        OptionUpdateDto optionForCreationDto,
        CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
        if (product.Options == null)
            throw new Exception("Product has no options");
        OptionEntity? option = product.Options.FirstOrDefault(x => x.Id == optionId);
        if (option == null)
            throw new Exception("Option not found");
        option.Description = optionForCreationDto.Description;
        option.Brand = optionForCreationDto.Brand;
        option.Color = optionForCreationDto.Color;
        option.Size = optionForCreationDto.Size;
        product.UpdatedBy = username;
        product.UpdatedAt = DateTimeOffset.UtcNow;
        if (optionForCreationDto.GenderFor != null)
            option.GenderFor = optionForCreationDto.GenderFor.Adapt<GenderType>();
        if (optionForCreationDto.Material != null)
            option.Material = optionForCreationDto.Material.Adapt<MaterialType>();
        if (optionForCreationDto.Condition != null)
            option.Condition = optionForCreationDto.Condition.Adapt<ConditionType>();
        _repositoryManager.ProductRepository.Update(product);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        OptionResponse optionResponse = option.Adapt<OptionResponse>();
        return optionResponse;
    }

    public async Task<OptionResponse> CreateOptionAsync(string? username, string productId, OptionDto optionForCreationDto,
        CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
        var option = optionForCreationDto.Adapt<OptionEntity>();
        product.Options.Add(option);
        _repositoryManager.ProductRepository.Update(product);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        OptionResponse optionResponse = option.Adapt<OptionResponse>();
        return optionResponse;
    }

    public async Task<ProductsResponse> GetOptionByIdAsync(string productId, int optionId, CancellationToken cancellationToken)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
        if (product.Options == null)
            throw new Exception("Product has no options");
        OptionEntity? option = product.Options.FirstOrDefault(x => x.Id == optionId);
        if (option == null)
            throw new Exception("Option not found");
        product.Title = option.Title;
        product.Description = option.Description;
        product.EndedAt = option.EndedAt;
        product.Price = option.Price;
        product.Brand = option.Brand;
        product.Color = option.Color;
        product.Size = option.Size;
        product.Weight = option.Weight;
        product.GenderFor = option.GenderFor;
        product.Condition = option.Condition;
        product.Material = option.Material;
        product.QuantityAvaliable = option.QuantityAvaliable;
        ProductsResponse productsResponse = option.Adapt<ProductsResponse>();
        return productsResponse;
    }

    public async Task<ProductDetailResponse> GetOptionDetailAsync(string productId, int optionId, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
        if (product.Options == null)
            throw new Exception("Product has no options");
        OptionEntity? option = product.Options.FirstOrDefault(x => x.Id == optionId);
        if (option == null)
            throw new Exception("Option not found");
        product.Title = option.Title;
        product.Description = option.Description;
        product.EndedAt = option.EndedAt;
        product.Price = option.Price;
        product.Brand = option.Brand;
        product.Color = option.Color;
        product.Size = option.Size;
        product.Weight = option.Weight;
        product.GenderFor = option.GenderFor;
        product.Condition = option.Condition;
        product.Material = option.Material;
        product.QuantityAvaliable = option.QuantityAvaliable;
        ProductDetailResponse productDetailResponse = option.Adapt<ProductDetailResponse>();
        productDetailResponse.OptionId = option.Id;
        return productDetailResponse;
    }
}