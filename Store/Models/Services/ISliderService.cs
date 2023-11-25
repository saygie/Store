using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public interface ISliderService : IService<Slider>
{
    Task<IDataResult<List<SliderDTO>>> List();
    Task<IDataResult<SliderDTO?>> GetById(int Id);
    Task<IResult> Add(SliderDTO dto);
    Task<IResult> Update(SliderDTO dto);
    Task<IResult> Delete(SliderDTO dto);
    Task<IDataResult<int>> Count();
}