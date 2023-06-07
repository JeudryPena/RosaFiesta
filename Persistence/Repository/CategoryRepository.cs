using Domain.Entities.Product;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly RosaFiestaContext _rosaFiestaContext;

    public CategoryRepository(RosaFiestaContext rosaFiestaContext)
    {
        _rosaFiestaContext = rosaFiestaContext;
    }

    public async Task<IEnumerable<CategoryEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _rosaFiestaContext.Categories.Include(x => x.SubCategories).Include(x => x.Products).Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);

    public async Task<IEnumerable<CategoryEntity>> GetAllManagementAsync(CancellationToken cancellationToken) => await _rosaFiestaContext.Categories.ToListAsync(cancellationToken);

    public async Task<IEnumerable<SubCategoryEntity>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default) =>
        await _rosaFiestaContext.SubCategories.Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);

    public void Insert(CategoryEntity category) =>
    _rosaFiestaContext.Categories.Add(category);

    public void InsertSubCategory(List<SubCategoryEntity> subCategory) =>
        _rosaFiestaContext.SubCategories.AddRange(subCategory);

    public async Task<SubCategoryEntity> GetSubCategoryByIdAsync(int categoryId, int subCategoryId, CancellationToken cancellationToken = default)
    {
        var subCategory = await _rosaFiestaContext.Categories.Include(x => x.SubCategories).Where(x => x.IsDeleted == false).SelectMany(x => x.SubCategories).FirstOrDefaultAsync(x => x.Id == subCategoryId && x.CategoryId == categoryId, cancellationToken);
        if (subCategory == null)
            throw new ArgumentNullException(nameof(subCategory));
        if (subCategory.IsDeleted)
            throw new InvalidOperationException("The subcategory is deleted");
        return subCategory;
    }

    public async Task<CategoryEntity> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default)
    {
        var category = await _rosaFiestaContext.Categories.Include(x => x.SubCategories).Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken);
        if (category == null)
            throw new ArgumentNullException(nameof(category));
        if (category.IsDeleted)
            throw new InvalidOperationException("The category is deleted");
        return category;
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