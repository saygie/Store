using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public interface ICountyService : IService<County>
{
    Task<IDataResult<List<CountyDTO>>> List();
    Task<IDataResult<List<CountyDTO>>> ListByCityId(int cityId);
    Task<IDataResult<CountyDTO?>> GetById(int Id);
    Task<IResult> Add(CountyDTO dto);
    Task<IResult> Update(CountyDTO dto);
    Task<IResult> Delete(CountyDTO dto);
    Task<IDataResult<int>> Count();
}
