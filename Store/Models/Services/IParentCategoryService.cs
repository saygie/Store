using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public interface IParentCategoryService : IService<ParentCategory>
{
    Task<IDataResult<List<ParentCategoryDTO>>> List();
    Task<IDataResult<ParentCategoryDTO?>> GetById(int Id);
    Task<IResult> Add(ParentCategoryDTO dto);
    Task<IResult> Update(ParentCategoryDTO dto);
    Task<IResult> Delete(ParentCategoryDTO dto);
    Task<IDataResult<int>> Count();
    Task<IDataResult<ParentCategoryDTO?>> GetBySlugWithCategoriesAndProducts(string parentCategorySlug, string? categorySlug);
}
