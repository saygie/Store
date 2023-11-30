
using Store.Models.Entities;
using Store.Models.Results;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

namespace Store.Models.Services;

public class HelperService : IHelperService
{
    public string PhotoUpload(Stream originalImageStream, string extension, string mainFolder, List<string> sizes)
    {
        var imageName = Guid.NewGuid().ToString() + extension;
        try
        {
            using (Image<Rgba32> orijinalImage = Image.Load<Rgba32>(originalImageStream))
            {
                foreach (var size in sizes) //0x0
                {
                    int w = Convert.ToInt16(size.Split('x')[0]);
                    int h = Convert.ToInt16(size.Split('x')[1]);

                    Image image = PhotoResize(orijinalImage, w, h);

                    var folderPath = Path.Combine("wwwroot", "uploads", mainFolder, size);
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var savePath = Path.Combine(folderPath, imageName);
                    image.Save(savePath);
                    image.Dispose();

                }
            }
            return imageName;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public bool PhotoUpload(Stream originalImageStream, string imageName, string extension, string mainFolder, string size)
    {
        try
        {
            using (Image<Rgba32> orijinalImage = Image.Load<Rgba32>(originalImageStream))
            {
                int w = Convert.ToInt16(size.Split('x')[0]);
                int h = Convert.ToInt16(size.Split('x')[1]);

                Image image = PhotoResize(orijinalImage, w, h);

                var folderPath = Path.Combine("wwwroot", "uploads", mainFolder, size);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var savePath = Path.Combine(folderPath, imageName + extension);
                image.Save(savePath);
                image.Dispose();


            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public Image<Rgba32> PhotoResize(Image<Rgba32> originalImage, int w, int h)
    {
        return originalImage.Clone(x => x.Resize(new ResizeOptions
        {
            Size = new Size(w, h),
            Mode = ResizeMode.Crop
        }));
    }

    public string ConvertToSeoSentence(string sentence)
    {
        try
        {
            string normalizedSentence = sentence.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalizedSentence)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            string withoutTurkishChars = sb.ToString().Normalize(NormalizationForm.FormC);
            string lowercaseSentence = withoutTurkishChars.ToLower();
            string seoFriendlySentence = Regex.Replace(lowercaseSentence, @"\s", "-");
            string generatedUniqueCode = GenerateUniqueCode();

            return seoFriendlySentence + "-" + generatedUniqueCode;

        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public string GenerateUniqueCode()
    {
        long timestamp = DateTime.Now.Ticks;
        string uniqueCode = timestamp.ToString();
        uniqueCode = uniqueCode.Substring(uniqueCode.Length - 8);
        return uniqueCode;
    }

}
