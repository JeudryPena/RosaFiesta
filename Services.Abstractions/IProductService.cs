using Contracts.Model;

namespace Services.Abstractions;

public interface IProductService
{
    Task<ProductEntityDto> CreateAsync(ProductEntityDto productForCreationDto);
}