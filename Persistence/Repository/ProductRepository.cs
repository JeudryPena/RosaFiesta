﻿using Domain.Entities;
using Domain.Entities.Product;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public class ProductRepository: IProductRepository
{
    private readonly RosaFiestaContext _dbContext;
    
    public ProductRepository(RosaFiestaContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<ProductEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
    await _dbContext.Products.Include(p => p.Category).Include(x => x.Reviews).ToListAsync(cancellationToken);

    public async Task<ProductEntity> GetByIdAsync(string productId, CancellationToken cancellationToken = default)
    {
        var product = await _dbContext.Products.Include(p => p.Category).Include(p => p.Supplier).Include(x => x.Reviews).Include(x => x.Details).Include(p => p.Warranty).Include(x => x.Reviews).FirstOrDefaultAsync(x => x.Code == productId, cancellationToken);
        if (product == null)
            throw new ArgumentNullException(nameof(product));
        return product;
    }

    public async Task<OptionEntity> GetOptionByIdAsync(int optionId, CancellationToken cancellationToken = default)
    {
        var option = await _dbContext.Options.FirstOrDefaultAsync(x => x.Id == optionId, cancellationToken);
        if (option == null)
            throw new ArgumentNullException(nameof(option));
        return option;
    }

    public void Update(ProductEntity product) => _dbContext.Products.Update(product);
    
    public void Delete(ProductEntity product) => _dbContext.Products.Remove(product);
    
    public void UpdateRange(List<ProductEntity> listProducts)
    => _dbContext.Products.UpdateRange(listProducts);

    public void InsertOptions(OptionEntity option)
    => _dbContext.Options.Add(option);

    public void DeleteOption(OptionEntity option)
    => _dbContext.Options.Remove(option);

    public void Insert(ProductEntity product) 
        => _dbContext.Products.Add(product);
}