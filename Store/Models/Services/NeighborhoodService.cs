using AutoMapper;
using Store.Data;
using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public class NeighborhoodService : Service<Neighborhood, DataDbContext>, INeighborhoodService
{
    private readonly IMapper mapper;

    public NeighborhoodService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async Task<IResult> Add(NeighborhoodDTO dto)
    {
        try
        {
            var data = mapper.Map<Neighborhood>(dto);
            await Add(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Update(NeighborhoodDTO dto)
    {
        try
        {
            var data = mapper.Map<Neighborhood>(dto);
            await Update(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Delete(NeighborhoodDTO dto)
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

    public async Task<IDataResult<NeighborhoodDTO?>> GetById(int Id)
    {
        try
        {
            var data = await Get(a => a.Id == Id && a.IsDeleted == false);
            return new DataResult<NeighborhoodDTO?>(mapper.Map<NeighborhoodDTO>(data), true);
        }
        catch (Exception)
        {
            return new DataResult<NeighborhoodDTO?>(null, false);
        }
    }

    public async Task<IDataResult<List<NeighborhoodDTO>>> List()
    {
        try
        {
            var data = await List(a => a.IsDeleted == false);
            return new DataResult<List<NeighborhoodDTO>>(mapper.Map<List<NeighborhoodDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<NeighborhoodDTO>>(new List<NeighborhoodDTO>(), false, ex.Message);
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

