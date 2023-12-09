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

public class AddressService : Service<Address, DataDbContext>, IAddressService
{
    private readonly IProductService productService;
    private readonly UserManager<IdentityUser> userManager;
    SignInManager<IdentityUser> signInManager;
    private const string AddressSessionKey = "Address";
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IMapper mapper;

    public AddressService(IProductService productService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        this.mapper = mapper;
        this.httpContextAccessor = httpContextAccessor;
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.productService = productService;
    }
    private ISession Session => httpContextAccessor.HttpContext.Session;

    public async Task<IResult> Add(AddressDTO dto)
    {
        try
        {
            var data = mapper.Map<Address>(dto);
            await Add(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }

    public async Task<IResult> Update(AddressDTO dto)
    {
        try
        {
            var data = mapper.Map<Address>(dto);
            await Update(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Delete(AddressDTO dto)
    {
        try
        {
            var data = await Get(a => a.Id == dto.Id && a.UserId == dto.UserId);
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

    public async Task<IDataResult<AddressDTO?>> GetById(int Id)
    {
        try
        {
            var data = await Get(a => a.Id == Id && a.IsDeleted == false,
                "Neighborhood,Neighborhood.County,Neighborhood.County.City");
            return new DataResult<AddressDTO?>(mapper.Map<AddressDTO>(data), true);
        }
        catch (Exception)
        {
            return new DataResult<AddressDTO?>(null, false);
        }
    }
    public async Task<IDataResult<List<AddressDTO>>> GetByUserId(string userId)
    {
        try
        {
            var data = await List(a =>
            a.UserId == userId && a.IsDeleted == false,null,
            "Neighborhood,Neighborhood.County,Neighborhood.County.City");
            return new DataResult<List<AddressDTO>>(mapper.Map<List<AddressDTO>>(data), true);
        }
        catch (Exception)
        {
            return new DataResult<List<AddressDTO>>(new List<AddressDTO>(), false);
        }
    }
    public async Task<IDataResult<List<AddressDTO>>> List()
    {
        try
        {
            var data = await List(a => a.IsDeleted == false,null,
                "Neighborhood,Neighborhood.County,Neighborhood.County.City");
            return new DataResult<List<AddressDTO>>(mapper.Map<List<AddressDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<AddressDTO>>(new List<AddressDTO>(), false, ex.Message);
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
