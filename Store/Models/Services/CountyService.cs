using AutoMapper;
using Store.Data;
using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public class CountyService : Service<County, DataDbContext>, ICountyService
{
    private readonly IMapper mapper;

    public CountyService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async Task<IResult> Add(CountyDTO dto)
    {
        try
        {
            var data = mapper.Map<County>(dto);
            await Add(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Update(CountyDTO dto)
    {
        try
        {
            var data = mapper.Map<County>(dto);
            await Update(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Delete(CountyDTO dto)
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

    public async Task<IDataResult<CountyDTO?>> GetById(int Id)
    {
        try
        {
            var data = await Get(a => a.Id == Id && a.IsDeleted == false);
            return new DataResult<CountyDTO?>(mapper.Map<CountyDTO>(data), true);
        }
        catch (Exception)
        {
            return new DataResult<CountyDTO?>(null, false);
        }
    }

    public async Task<IDataResult<List<CountyDTO>>> List()
    {
        try
        {
            var data = await List(a => a.IsDeleted == false);
            return new DataResult<List<CountyDTO>>(mapper.Map<List<CountyDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<CountyDTO>>(new List<CountyDTO>(), false, ex.Message);
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

    public async Task<IDataResult<List<CountyDTO>>> ListByCityId(int cityId)
    {
        try
        {
            var data = await List(a => a.IsDeleted == false && a.CityId == cityId);
            return new DataResult<List<CountyDTO>>(mapper.Map<List<CountyDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<CountyDTO>>(new List<CountyDTO>(), false, ex.Message);
        }
    }
}


