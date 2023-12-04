using AutoMapper;
using Store.Data;
using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using System.IO;
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

    public async Task<IDataResult<ProductDTO?>> GetById(int Id)
    {
        try
        {
            var data = await Get(a => a.Id == Id && a.IsDeleted == false, "Category,ProductPhotos,Category.ParentCategory");
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
            var data = await List(a => a.IsDeleted == false, null, "Category,Category.ParentCategory,ProductPhotos");
            return new DataResult<List<ProductDTO>>(mapper.Map<List<ProductDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<ProductDTO>>(new List<ProductDTO>(), false, ex.Message);
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

    public async Task<IDataResult<List<ProductDTO>>> Filter(string parentCategorySlug, string? categorySlug)
    {
        try
        {
            if (string.IsNullOrEmpty(categorySlug))
            {
                var data = await List(a =>
                !a.IsDeleted
                && a.IsActive
                && a.Category.ParentCategory.Slug == parentCategorySlug
                , null, "Category.ParentCategory,Category,ProductPhotos");
                return new DataResult<List<ProductDTO>>(mapper.Map<List<ProductDTO>>(data), true);
            }
            else
            {
                var data = await List(a =>
                !a.IsDeleted
                && a.IsActive
                && a.Category.ParentCategory.Slug == parentCategorySlug
                && a.Category.Slug == categorySlug
                , null, "Category,ProductPhotos");
                return new DataResult<List<ProductDTO>>(mapper.Map<List<ProductDTO>>(data), true);
            }

        }
        catch (Exception ex)
        {
            return new DataResult<List<ProductDTO>>(new List<ProductDTO>(), false, ex.Message);
        }
    }

    public async Task<IDataResult<ProductDTO?>> GetBySlug(string slug)
    {
        try
        {
            var data = await Get(a =>
            a.Slug == slug
            && a.IsActive
            && !a.IsDeleted,
            "Category,ProductPhotos,Category.ParentCategory");
            return new DataResult<ProductDTO?>(mapper.Map<ProductDTO>(data), true);
        }
        catch (Exception)
        {
            return new DataResult<ProductDTO?>(null, false);
        }
    }

    public async Task<IDataResult<List<ProductDTO>>> ListForHomePage()
    {
        try
        {
            var data = await List(a =>
            !a.IsDeleted
            && a.IsActive
            && (a.IsSpecialOffer || a.IsDiscounted || a.IsFeatured || a.IsMostSelled || a.IsNew)
            , null, "Category,Category.ParentCategory,ProductPhotos");
            return new DataResult<List<ProductDTO>>(mapper.Map<List<ProductDTO>>(data), true);
        }
        catch (Exception ex)
        {
            return new DataResult<List<ProductDTO>>(new List<ProductDTO>(), false, ex.Message);
        }
    }
}
