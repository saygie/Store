using AutoMapper;
using Store.Data;
using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public class SliderService : Service<Slider, DataDbContext>, ISliderService
{
    private readonly IMapper mapper;

    public SliderService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async Task<IResult> Add(SliderDTO dto)
    {
        try
        {
            var data = mapper.Map<Slider>(dto);
            await Add(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Update(SliderDTO dto)
    {
        try
        {
            var data = mapper.Map<Slider>(dto);
            await Update(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Delete(SliderDTO dto)
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

    public async Task<IDataResult<SliderDTO?>> GetById(int Id)
    {
        try
        {
            var data = await Get(a => a.Id == Id && a.IsDeleted == false);
            return new DataResult<SliderDTO?>(mapper.Map<SliderDTO>(data), true);
        }
        catch (Exception)
        {
            return new DataResult<SliderDTO?>(null, false);
        }
    }

    public async Task<IDataResult<List<SliderDTO>>> List()
    {
        try
        {
            var data = await List(a => a.IsDeleted == false, b => b.OrderBy(c => c.Order));
            return new DataResult<List<SliderDTO>>(mapper.Map<List<SliderDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<SliderDTO>>(new List<SliderDTO>(), false, ex.Message);
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
