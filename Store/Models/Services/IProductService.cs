﻿using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public interface IProductService : IService<Product>
{
    Task<IDataResult<List<ProductDTO>>> List();
    Task<IDataResult<ProductDTO?>> GetById(int Id);
    Task<IResult> Add(ProductDTO dto);
    Task<IResult> Update(ProductDTO dto);
    Task<IResult> Delete(ProductDTO dto);
    Task<IDataResult<int>> Count();
}
