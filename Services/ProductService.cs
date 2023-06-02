using Contracts.Model.Product;
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

    public async Task<ICollection<ProductAndOptionsPreviewResponse>> GetAllAsyncPreview(CancellationToken cancellationToken = default)
    {
        IEnumerable<ProductEntity> products = await _repositoryManager.ProductRepository.GetAllAsync(cancellationToken);
        ICollection<ProductAndOptionsPreviewResponse> productPreviewResponse =
            new List<ProductAndOptionsPreviewResponse>();
        foreach (ProductEntity product in products)
        {
            if (product.Options == null)
                throw new Exception("Product has no options");
            foreach (OptionEntity option in product.Options)
            {
                ProductAndOptionsPreviewResponse productAndOptionsPreviewResponse = new();
                productAndOptionsPreviewResponse.Adapt(product);
                productAndOptionsPreviewResponse.Adapt(option);
                productAndOptionsPreviewResponse.Adapt(option.Reviews);
                productPreviewResponse.Add(productAndOptionsPreviewResponse);
            }
        }
        return productPreviewResponse;
    }

    public async Task<ProductAndOptionResponse> GetByIdAsync(string productId, int optionId,
        CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, optionId, cancellationToken);
        OptionEntity? option = product.Options.FirstOrDefault(x => x.Id == optionId);
        if (option == null)
            throw new Exception("Option not found");
        ProductAndOptionResponse productAndOptionResponse = new();
        productAndOptionResponse.Adapt(product);
        productAndOptionResponse.Adapt(option);
        return productAndOptionResponse;
    }

    public async Task<ProductAndOptionResponse> CreateAsync(string userId, ProductDto productForCreationDto,
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
        ProductAndOptionResponse productResponse = new();
        productResponse.Adapt(product);
        productResponse.Adapt(product.Options.FirstOrDefault());

        return productResponse;
    }

    public async Task<ProductAndOptionResponse> UpdateAsync(string userId, int optionId, string productId,
        ProductUpdateDto productForUpdateDto, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetProductAndOption(productId, optionId, cancellationToken);
        OptionEntity? option = product.Options.FirstOrDefault(x => x.Id == optionId);
        if (option == null)
            throw new Exception("Option not found");
        // adapt productForUpdateDto to product and option
        option.Adapt(productForUpdateDto);
        product.Adapt(productForUpdateDto.Option);
        _repositoryManager.ProductRepository.Update(product);
        ActionLogEntity actionLog = new()
        {
            Action = ActivityAction.Updated,
            UserId = userId,
            ActivityType = Activities.Product,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        ProductAndOptionResponse productAndOptionResponse = product.Adapt<ProductAndOptionResponse>();
        productAndOptionResponse.Adapt(option);
        return productAndOptionResponse;
    }

    public async Task DeleteAsync(string userId, string productId, int? optionId,
        CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetProductById(productId, cancellationToken);
        ActionLogEntity actionLog = new()
        {
            Action = ActivityAction.Deleted,
            UserId = userId,
        };
        if (optionId == null)
        {
            OptionEntity? option = product.Options.FirstOrDefault(x => x.Id == optionId);
            if (option == null)
                throw new Exception("Option not found");
            product.Options.Remove(option);
            _repositoryManager.ProductRepository.Update(product);
            actionLog.ActivityType = Activities.Option;
        }
        else
        {
            _repositoryManager.ProductRepository.Delete(product);
            actionLog.ActivityType = Activities.Option;
        }
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

    }

    public async Task<ProductAndOptionDetailResponse> GetProductDetail(string productCode, int optionId,
        CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repositoryManager.ProductRepository.GetProductAndOption(productCode, optionId, cancellationToken);
        ProductAndOptionDetailResponse productAndOptionResponse = new();
        productAndOptionResponse.Adapt(product);
        productAndOptionResponse.Adapt(product.Options.FirstOrDefault(x => x.Id == optionId));
        productAndOptionResponse.WarrantyName = product.Warranty?.Name;
        return productAndOptionResponse;
    }

    public async Task<OptionAdjustResponse> AdjustOptionQuantityAsync(string userId, int optionId, string productId, int count,
        CancellationToken cancellationToken = default)
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

    public async Task<ProductAndOptionResponse> CreateOptionAsync(string userId, string productId,
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
        ProductAndOptionResponse optionResponse = new();
        optionResponse.Adapt(product);
        optionResponse.Adapt(option);
        return optionResponse;
    }
}