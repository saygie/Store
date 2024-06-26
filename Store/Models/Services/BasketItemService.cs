﻿using AutoMapper;
using Store.Data;
using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public class BasketItemService : Service<BasketItem, DataDbContext>, IBasketItemService
{
    private readonly IMapper mapper;

    public BasketItemService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async Task<IResult> Add(BasketItemDTO dto)
    {
        try
        {
            var data = mapper.Map<BasketItem>(dto);
            await Add(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Update(BasketItemDTO dto)
    {
        try
        {
            var data = mapper.Map<BasketItem>(dto);
            await Update(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Delete(BasketItemDTO dto)
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

    public async Task<IDataResult<BasketItemDTO?>> GetById(int Id)
    {
        try
        {
            var data = await Get(a => a.Id == Id && a.IsDeleted == false);
            return new DataResult<BasketItemDTO?>(mapper.Map<BasketItemDTO>(data), true);
        }
        catch (Exception)
        {
            return new DataResult<BasketItemDTO?>(null, false);
        }
    }

    public async Task<IDataResult<List<BasketItemDTO>>> List()
    {
        try
        {
            var data = await List(a => a.IsDeleted == false);
            return new DataResult<List<BasketItemDTO>>(mapper.Map<List<BasketItemDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<BasketItemDTO>>(new List<BasketItemDTO>(), false, ex.Message);
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
