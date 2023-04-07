using Domain.Entities.Product;
using Domain.Exceptions;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public class CategoryRepository: ICategoryRepository
{
    private readonly RosaFiestaContext _rosaFiestaContext;
    
    public CategoryRepository(RosaFiestaContext rosaFiestaContext)
    {
        _rosaFiestaContext = rosaFiestaContext;
    }

    public async Task<IEnumerable<CategoryEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _rosaFiestaContext.Categories.Include(x => x.SubCategories).Include(x => x.Products).ToListAsync(cancellationToken);

    public async Task<IEnumerable<SubCategoryEntity>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default) => 
        await _rosaFiestaContext.SubCategories.ToListAsync(cancellationToken);

    public void Insert(CategoryEntity category) =>
    _rosaFiestaContext.Categories.Add(category);
    
    public void InsertSubCategory(List<SubCategoryEntity> subCategory) =>
        _rosaFiestaContext.SubCategories.AddRange(subCategory);

    public async Task<SubCategoryEntity> GetSubCategoryByIdAsync(int categoryId, int subCategoryId, CancellationToken cancellationToken = default)
    {
        var subCategory = await _rosaFiestaContext.SubCategories
            .FirstOrDefaultAsync(x => x.Id == subCategoryId && x.CategoryId == categoryId, cancellationToken); 
        if (subCategory == null)
            throw new ArgumentNullException(nameof(subCategory));
        return subCategory;
    }

    public async Task<CategoryEntity> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default)
    {
        var category = await _rosaFiestaContext.Categories.Include(x => x.SubCategories).Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken);
        if (category == null)
            throw new ArgumentNullException(nameof(category));
        return category;
    }

    public void Delete(CategoryEntity category)
    {
        _rosaFiestaContext.Categories.Remove(category);
    }

    public void DeleteSubCategory(SubCategoryEntity subCategory)
    {
        _rosaFiestaContext.SubCategories.Remove(subCategory);
    }

    public void Update(CategoryEntity category)
    {
        _rosaFiestaContext.Categories.Update(category);
    }

    public void UpdateSubCategory(SubCategoryEntity subCategory)
    {
        _rosaFiestaContext.SubCategories.Update(subCategory);
    }

    public async Task<List<SubCategoryEntity>> GetSubCategoriesByIdsAsync(List<int> toList, CancellationToken cancellationToken = default)
    {
        var subCategories = await _rosaFiestaContext.SubCategories
            .Where(x => toList.Contains(x.Id)).ToListAsync(cancellationToken);
        if (subCategories == null)
            throw new ArgumentNullException(nameof(subCategories));
        return subCategories;
    }

    public void UpdateSubCategories(List<SubCategoryEntity> subCategories)
    {
        _rosaFiestaContext.SubCategories.UpdateRange(subCategories);
    }

    public async Task<CategoryEntity> GetCategoryAndSubCategoryAsync(int categoryId, CancellationToken cancellationToken)
    {
        var category = await _rosaFiestaContext.Categories
            .FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken);
        if (category == null)
            throw new ArgumentNullException(nameof(category), "Category not found");
        return category;
    }
}