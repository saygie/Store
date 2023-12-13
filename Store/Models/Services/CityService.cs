using AutoMapper;
using Store.Data;
using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public class CityService : Service<City, DataDbContext>, ICityService
{
    private readonly IMapper mapper;

    public CityService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async Task<IResult> Add(CityDTO dto)
    {
        try
        {
            var data = mapper.Map<City>(dto);
            await Add(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Update(CityDTO dto)
    {
        try
        {
            var data = mapper.Map<City>(dto);
            await Update(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Delete(CityDTO dto)
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

    public async Task<IDataResult<CityDTO?>> GetById(int Id)
    {
        try
        {
            var data = await Get(a => a.Id == Id && a.IsDeleted == false);
            return new DataResult<CityDTO?>(mapper.Map<CityDTO>(data), true);
        }
        catch (Exception)
        {
            return new DataResult<CityDTO?>(null, false);
        }
    }

    public async Task<IDataResult<List<CityDTO>>> List()
    {
        try
        {
            var data = await List(a => a.IsDeleted == false);
            return new DataResult<List<CityDTO>>(mapper.Map<List<CityDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<CityDTO>>(new List<CityDTO>(), false, ex.Message);
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

    public async Task<IDataResult<List<CityDTO>>> ListWithCountiesAndNeighborhoods()
    {
        try
        {
            var data = await List(a => a.IsDeleted == false,null, "Counties,Counties.Neighborhoods");
            return new DataResult<List<CityDTO>>(mapper.Map<List<CityDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<CityDTO>>(new List<CityDTO>(), false, ex.Message);
        }
    }
}



