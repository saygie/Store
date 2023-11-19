using AutoMapper;
using Store.Data;
using Store.Models.DTOs.Product;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public class ProductService : Service<Product, DataDbContext>, IProductService
{
    private readonly IMapper mapper;

    public ProductService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async Task<IResult> Add(ProductDTO dto)
    {
        try
        {
            var data = mapper.Map<Product>(dto);
            await Add(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Update(ProductDTO dto)
    {
        try
        {
            var data = mapper.Map<Product>(dto);
            await Update(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Delete(ProductDTO dto)
    {
        try
        {
            var data = mapper.Map<Product>(dto);
            await Delete(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }

    public async Task<IDataResult<ProductDTO?>> GetById(int Id)
    {
        try
        {
            var data = await Get(a => a.Id == Id && a.IsDeleted == false);
            return new DataResult<ProductDTO?>(mapper.Map<ProductDTO>(data), true);
        }
        catch (Exception)
        {
            return new DataResult<ProductDTO?>(null, false);
        }
    }

    public async Task<IDataResult<List<ProductDTO>>> List()
    {
        try
        {
            var data = await List(a => a.IsDeleted == false);
            return new DataResult<List<ProductDTO>>(mapper.Map<List<ProductDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<ProductDTO>>(new List<ProductDTO>(), false, ex.Message);
        }
    }
}
