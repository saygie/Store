namespace Store.Models.Services;

public interface IHelperService
{
    string PhotoUpload(Stream originalImageStream, string extension, string mainFolder, List<string> sizes);
    bool PhotoUpload(Stream originalImageStream,string name, string extension, string mainFolder, string size);
    Image<Rgba32> PhotoResize(Image<Rgba32> originalImage, int w, int h);

    string ConvertToSeoSentence(string sentence);

    string GenerateUniqueCode();


}
