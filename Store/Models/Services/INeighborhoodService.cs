using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public interface INeighborhoodService : IService<Neighborhood>
{
    Task<IDataResult<List<NeighborhoodDTO>>> List();
    Task<IDataResult<List<NeighborhoodDTO>>> ListByCountyId(int countyId);
    Task<IDataResult<NeighborhoodDTO?>> GetById(int Id);
    Task<IResult> Add(NeighborhoodDTO dto);
    Task<IResult> Update(NeighborhoodDTO dto);
    Task<IResult> Delete(NeighborhoodDTO dto);
    Task<IDataResult<int>> Count();
}
