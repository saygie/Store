using AutoMapper;
using Store.Data;
using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using System.IO;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public class ProductPhotoService : Service<ProductPhoto, DataDbContext>, IProductPhotoService
{
    private readonly IMapper mapper;

    public ProductPhotoService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async Task<IResult> Add(ProductPhotoDTO dto)
    {
        try
        {
            var data = mapper.Map<ProductPhoto>(dto);
            await Add(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Update(ProductPhotoDTO dto)
    {
        try
        {
            var data = mapper.Map<ProductPhoto>(dto);
            await Update(data);
            return new Result(true);
        }
        catch (Exception)
        {
            return new Result(false);
        }
    }
    public async Task<IResult> Delete(ProductPhotoDTO dto)
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

    public async Task<IDataResult<ProductPhotoDTO?>> GetById(int Id)
    {
        try
        {
            var data = await Get(a => a.Id == Id && a.IsDeleted == false, "Product");
            return new DataResult<ProductPhotoDTO?>(mapper.Map<ProductPhotoDTO>(data), true);
        }
        catch (Exception)
        {
            return new DataResult<ProductPhotoDTO?>(null, false);
        }
    }

    public async Task<IDataResult<List<ProductPhotoDTO>>> List()
    {
        try
        {
            var data = await List(a => a.IsDeleted == false, null, "Product");
            return new DataResult<List<ProductPhotoDTO>>(mapper.Map<List<ProductPhotoDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<ProductPhotoDTO>>(new List<ProductPhotoDTO>(), false, ex.Message);
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

    public async Task<IDataResult<bool>> Upload(Stream stream, string fileName, int ProductId)
    {
        try
        {
            var filePath = Path.Combine("wwwroot", "uploads", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await Add(new ProductPhoto() { 
                IsActive = true,
                IsDeleted = false,
                Url = fileName,
                ProductId = ProductId,
                });
                await stream.CopyToAsync(fileStream);
            }
            return new DataResult<bool>(true, true);
        }
        catch (Exception ex)
        {
            return new DataResult<bool>(false, false, ex.Message);
        }
    }
}
