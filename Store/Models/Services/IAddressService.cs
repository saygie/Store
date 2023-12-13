using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public interface IAddressService : IService<Address>
{
    Task<IDataResult<List<AddressDTO>>> List();
    Task<IDataResult<AddressDTO?>> GetById(int Id);
    Task<IDataResult<AddressDTO?>> GetById(int Id, string userId);
    Task<IDataResult<AddressDTO?>> GetByGId(string GId);
    Task<IDataResult<AddressDTO?>> GetByGId(string GId, string userId);
    Task<IDataResult<List<AddressDTO>>> GetByUserId(string userId);
    Task<IResult> Add(AddressDTO dto);
    Task<IResult> Update(AddressDTO dto);
    Task<IResult> Delete(AddressDTO dto);
    Task<IDataResult<int>> Count();
}


