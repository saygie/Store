using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public interface IBasketService : IService<Basket>
{
    Task<IDataResult<BasketDTO?>> CreateOrGet();
    Task<IDataResult<List<BasketDTO>>> List();
    Task<IDataResult<BasketDTO?>> GetById(int Id);
    Task<IDataResult<BasketDTO?>> GetByUserId(string userId);
    Task<IResult> Add(BasketDTO dto);
    Task<IResult> Update(BasketDTO dto);
    Task<IResult> Delete(BasketDTO dto);
    Task<IDataResult<int>> Count();
}

