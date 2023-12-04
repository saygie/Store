using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public interface IBasketItemService : IService<BasketItem>
{
    Task<IDataResult<List<BasketItemDTO>>> List();
    Task<IDataResult<BasketItemDTO?>> GetById(int Id);
    Task<IResult> Add(BasketItemDTO dto);
    Task<IResult> Update(BasketItemDTO dto);
    Task<IResult> Delete(BasketItemDTO dto);
    Task<IDataResult<int>> Count();
}

