using AutoMapper;
using Microsoft.CodeAnalysis;
using Store.Data;
using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
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
                await Add(new ProductPhoto()
                {
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

    public Image<Rgba32> Resize(SixLabors.ImageSharp.Image<SixLabors.ImageSharp.PixelFormats.Rgba32> originalImage, int w, int h)
    {

        return originalImage.Clone(x => x.Resize(new ResizeOptions
        {
            Size = new SixLabors.ImageSharp.Size(w, h),
            Mode = ResizeMode.Crop
        }));
    }

    public IDataResult<bool> Upload2(int productId, Stream originalImageStream, string extension, string mainFolder, List<string> sizes)
    {
        try
        {
            using (Image<Rgba32> orijinalImage = Image.Load<Rgba32>(originalImageStream))
            {
                var imageName = Guid.NewGuid().ToString() + extension;
                foreach (var size in sizes) //0x0
                {
                    int w = Convert.ToInt16(size.Split('x')[0]);
                    int h = Convert.ToInt16(size.Split('x')[1]);

                    Image image = Resize(orijinalImage, w, h);

                    var folderPath = Path.Combine("wwwroot", "uploads", mainFolder, size);
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var savePath = Path.Combine(folderPath, imageName);
                    image.Save(savePath);
                    image.Dispose();

                }
                _ = Add(new ProductPhoto()
                {
                    IsActive = true,
                    IsDeleted = false,
                    Url = imageName,
                    ProductId = productId,
                });
            }
            return new DataResult<bool>(true, true);
        }
        catch (Exception ex)
        {
            return new DataResult<bool>(false, false, ex.Message);
        }
    }
}
