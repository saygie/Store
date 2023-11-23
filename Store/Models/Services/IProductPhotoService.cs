using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Results;
using Store.Models.Services.Common;
using IResult = Store.Models.Results.IResult;

namespace Store.Models.Services;

public interface IProductPhotoService : IService<ProductPhoto>
{
    Task<IDataResult<List<ProductPhotoDTO>>> List();
    Task<IDataResult<ProductPhotoDTO?>> GetById(int Id);
    Task<IResult> Add(ProductPhotoDTO dto);
    Task<IResult> Update(ProductPhotoDTO dto);
    Task<IResult> Delete(ProductPhotoDTO dto);
    Task<IDataResult<int>> Count();
    Task<IDataResult<bool>> Upload(Stream stream, string fileName, int ProductId);
    IDataResult<bool> Upload2(int productId,Stream originalImageStream, string extension, string mainFolder, List<string> sizes);
    Image<Rgba32> Resize(Image<Rgba32> originalImage, int w, int h);
}
