using Contracts.Model;
using Domain.Entities;
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

    public async Task<ProductEntityDto> CreateAsync(ProductEntityDto productForCreationDto)
    {
        var product = productForCreationDto.Adapt<ProductEntity>();
        _repositoryManager.ProductRepository.Insert(product);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return product.Adapt<ProductEntityDto>();
    }
}