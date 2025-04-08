using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Ingresso.Domain.Integrations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Ingresso.Infra.Data.Integrations
{
    public class SaveCloudinary : ISaveCloudinary
    {
        private readonly Cloudinary _cloudinary;
        public SaveCloudinary(IConfiguration config)
        {
            _cloudinary = new Cloudinary(config["MySettings:CloudinaryUrl"]);
        }

        public async Task<string> SaveImageAsync(string slug, string publicId, IFormFile file)
        {
            return await UploadImage(slug, publicId, file);
        }

        public async Task DeleteMovieImageAsync(string[] publicId)
        {
            await _cloudinary.DestroyAsync(new DeletionParams(publicId[0]));
            await _cloudinary.DestroyAsync(new DeletionParams(publicId[1]));
        }

        private async Task<string> UploadImage(string name, string publicId, IFormFile file)
        {
            byte[] img;

            using (var stream = new MemoryStream())
            {
                await file.OpenReadStream().CopyToAsync(stream);
                img = stream.ToArray();
            }

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(name, new MemoryStream(img)),
                Overwrite = true,
                PublicId = publicId,
                //Transformation = new Transformation()
                //                    .Crop("limit").Quality("auto").FetchFormat("auto")
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult.SecureUrl.ToString();
        }
    }
}
