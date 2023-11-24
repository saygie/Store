using AutoMapper;
using Store.Data;
using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public class ParentCategoryService : Service<ParentCategory, DataDbContext>, IParentCategoryService
{
    private readonly IMapper mapper;

    public ParentCategoryService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async Task<IResult> Add(ParentCategoryDTO dto)
    {
        try
        {
            var data = mapper.Map<ParentCategory>(dto);
            await Add(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Update(ParentCategoryDTO dto)
    {
        try
        {
            var data = mapper.Map<ParentCategory>(dto);
            await Update(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Delete(ParentCategoryDTO dto)
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

    public async Task<IDataResult<ParentCategoryDTO?>> GetById(int Id)
    {
        try
        {
            var data = await Get(a => a.Id == Id && a.IsDeleted == false);
            return new DataResult<ParentCategoryDTO?>(mapper.Map<ParentCategoryDTO>(data), true);
        }
        catch (Exception)
        {
            return new DataResult<ParentCategoryDTO?>(null, false);
        }
    }

    public async Task<IDataResult<List<ParentCategoryDTO>>> List()
    {
        try
        {
            var data = await List(a => a.IsDeleted == false, null, "Categories");
            return new DataResult<List<ParentCategoryDTO>>(mapper.Map<List<ParentCategoryDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<ParentCategoryDTO>>(new List<ParentCategoryDTO>(), false, ex.Message);
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
}
