using AutoMapper;
using Store.Data;
using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public class CategoryService : Service<Category, DataDbContext>, ICategoryService
{
    private readonly IMapper mapper;

    public CategoryService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async Task<IResult> Add(CategoryDTO dto)
    {
        try
        {
            var data = mapper.Map<Category>(dto);
            await Add(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Update(CategoryDTO dto)
    {
        try
        {
            var data = mapper.Map<Category>(dto);
            await Update(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Delete(CategoryDTO dto)
    {
        try
        {
            var data = await Get(a => a.Id == dto.Id);
            if (data is null)
                return new Result(false);

            data.IsDeleted = true;
            await Delete(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }

    public async Task<IDataResult<CategoryDTO?>> GetById(int Id)
    {
        try
        {
            var data = await Get(a => a.Id == Id && a.IsDeleted == false);
            return new DataResult<CategoryDTO?>(mapper.Map<CategoryDTO>(data), true);
        }
        catch (Exception)
        {
            return new DataResult<CategoryDTO?>(null, false);
        }
    }

    public async Task<IDataResult<List<CategoryDTO>>> List()
    {
        try
        {
            var data = await List(a => a.IsDeleted == false);
            return new DataResult<List<CategoryDTO>>(mapper.Map<List<CategoryDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<CategoryDTO>>(new List<CategoryDTO>(), false, ex.Message);
        }
    }

    public async Task<IDataResult<int>> Count()
    {
        try
        {
            var data = await Count(a => a.IsDeleted == false);
            return new DataResult<int>(data, true);
        }
        catch (Exception ex)
        {
            return new DataResult<int>(0, false, ex.Message);
        }
    }

    public async Task<IDataResult<List<CategoryDTO>>> ListWithProducts()
    {
        try
        {
            var data = await List(a => a.IsDeleted == false && a.IsActive, null, "Products,Products.ProductPhotos");
            return new DataResult<List<CategoryDTO>>(mapper.Map<List<CategoryDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<CategoryDTO>>(new List<CategoryDTO>(), false, ex.Message);
        }
    }
}
