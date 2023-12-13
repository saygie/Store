using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public interface ICityService : IService<City>
{
    Task<IDataResult<List<CityDTO>>> List();
    Task<IDataResult<List<CityDTO>>> ListWithCountiesAndNeighborhoods();
    Task<IDataResult<CityDTO?>> GetById(int Id);
    Task<IResult> Add(CityDTO dto);
    Task<IResult> Update(CityDTO dto);
    Task<IResult> Delete(CityDTO dto);
    Task<IDataResult<int>> Count();
}

