using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Store.Data;
using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public class BasketService : Service<Basket, DataDbContext>, IBasketService
{
    private readonly UserManager<IdentityUser> userManager;
    SignInManager<IdentityUser> signInManager;
    private const string BasketSessionKey = "Basket";
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IMapper mapper;

    public BasketService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        this.mapper = mapper;
        this.httpContextAccessor = httpContextAccessor;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }
    private ISession Session => httpContextAccessor.HttpContext.Session;

    public async Task<IDataResult<BasketDTO?>> CreateOrGet()
    {

        var cart = Session.GetString(BasketSessionKey);
        if (cart is null)
        {
            var newBasket = new BasketDTO();
            newBasket.BasketItems = new List<BasketItemDTO>();
            return new DataResult<BasketDTO?>(newBasket, true);
        }
        else
        {
            return JsonConvert.DeserializeObject<DataResult<BasketDTO?>>(cart);
        }
    }

    public async Task<IResult> Add(BasketDTO dto)
    {
        try
        {
            var data = mapper.Map<Basket>(dto);
            await Add(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Update(BasketDTO dto)
    {
        try
        {
            var data = mapper.Map<Basket>(dto);
            await Update(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Delete(BasketDTO dto)
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

    public async Task<IDataResult<BasketDTO?>> GetById(int Id)
    {
        try
        {
            var data = await Get(a => a.Id == Id && a.IsDeleted == false);
            return new DataResult<BasketDTO?>(mapper.Map<BasketDTO>(data), true);
        }
        catch (Exception)
        {
            return new DataResult<BasketDTO?>(null, false);
        }
    }
    public async Task<IDataResult<BasketDTO?>> GetByUserId(string userId)
    {
        try
        {
            var data = await Get(a =>
            a.UserId == userId && a.IsDeleted == false,
            "BasketItems,BasketItems.Product");
            return new DataResult<BasketDTO?>(mapper.Map<BasketDTO>(data), true);
        }
        catch (Exception)
        {
            return new DataResult<BasketDTO?>(null, false);
        }
    }
    public async Task<IDataResult<List<BasketDTO>>> List()
    {
        try
        {
            var data = await List(a => a.IsDeleted == false);
            return new DataResult<List<BasketDTO>>(mapper.Map<List<BasketDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<BasketDTO>>(new List<BasketDTO>(), false, ex.Message);
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
