using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public interface ICategoryService : IService<Category>
{
    Task<IDataResult<List<CategoryDTO>>> List();
    Task<IDataResult<List<CategoryDTO>>> ListWithParentCategoryAndProducts();
    Task<IDataResult<List<CategoryDTO>>> ListWithParentCategory();
    Task<IDataResult<CategoryDTO?>> GetById(int Id);
    Task<IResult> Add(CategoryDTO dto);
    Task<IResult> Update(CategoryDTO dto);
    Task<IResult> Delete(CategoryDTO dto);
    Task<IDataResult<int>> Count();
    Task<IDataResult<CategoryDTO?>> GetBySlugWithParentCategoryAndProducts(string categorySlug);
}
