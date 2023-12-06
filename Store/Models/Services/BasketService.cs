using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using NuGet.ContentModel;
using Store.Data;
using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using System.Text.Json;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public class BasketService : Service<Basket, DataDbContext>, IBasketService
{
    private readonly IProductService productService;
    private readonly UserManager<IdentityUser> userManager;
    SignInManager<IdentityUser> signInManager;
    private const string BasketSessionKey = "Basket";
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IMapper mapper;

    public BasketService(IProductService productService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        this.mapper = mapper;
        this.httpContextAccessor = httpContextAccessor;
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.productService = productService;
    }
    private ISession Session => httpContextAccessor.HttpContext.Session;

    public async Task<BasketDTO> CreateOrGetSession()
    {
        try
        {
            var basketSession = Session.GetString(BasketSessionKey);
            if (basketSession is null)
            {
                var basket = new BasketDTO();
                basket.BasketItems = new List<BasketItemDTO>();
                Session.SetString(BasketSessionKey, JsonSerializer.Serialize(basket));
                return basket;
            }
            else
            {
                return JsonSerializer.Deserialize<BasketDTO>(basketSession);
            }
        }
        catch (Exception ex)
        {
            return null;
        }

    }
    public async Task<IResult> RemoveItemInSession(int productId)
    {
        try
        {
            var basketSession = await CreateOrGetSession();
            var product = basketSession.BasketItems.Where(a => a.ProductId == productId).FirstOrDefault();
            if (product is not null)
            {
                basketSession.BasketItems.Remove(product);
                basketSession.Total = basketSession.BasketItems.Sum(b => b.Total);
                Session.SetString(BasketSessionKey, JsonSerializer.Serialize(basketSession));
            }
            return new Result(true);
        }
        catch (Exception ex)
        {
            return new Result(false);
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
    public async Task<IResult> AddToSession(int productId, int quantity)
    {
        try
        {
            var basket = await CreateOrGetSession();
            var product = await productService.GetById(productId);
            if (product is null)
                return new Result(false);

            var productInBasket = basket.BasketItems?.Where(a => a.ProductId == productId).FirstOrDefault();
            if (productInBasket is not null)
            {
                productInBasket.Quantity += quantity;
                productInBasket.Total = product.Data.Price * productInBasket.Quantity;
            }
            else
            {
                var basketItem = new BasketItemDTO();
                basketItem.BasketId = basket.Id;
                basketItem.IsActive = true;
                basketItem.IsDeleted = false;
                basketItem.Quantity = quantity;
                basketItem.ProductId = productId;

                basketItem.Photo = product.Data.ProductPhotos.FirstOrDefault()?.Url;
                basketItem.Total = product.Data.Price * quantity;
                basketItem.Product = new ProductDTO()
                {
                    Id = productId,
                    Name = product.Data.Name,
                    Price = product.Data.Price,
                    Slug = product.Data.Slug,
                    Discount = product.Data.Discount,
                };
                basket?.BasketItems?.Add(basketItem);
            }
            basket.Total = basket.BasketItems.Sum(b => b.Total);
            Session.SetString(BasketSessionKey, JsonSerializer.Serialize(basket));

            return new Result(true);
        }
        catch (Exception ex)
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
