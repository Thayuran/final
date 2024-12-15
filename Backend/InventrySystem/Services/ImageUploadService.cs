using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Entities.Models;
using MagicPOS.CloudinaryStore;
using Microsoft.Extensions.Options;

namespace MagicPOS.Services
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly Cloudinary _cloudinary;


        public ImageUploadService(IOptions<CloudinarySettings> _cloudinarySettings)
        {
            var account = new Account(
            //"dtm5fjebv", "863748169153569", "rCWQU-T3dJDIOWP2KMMOAPsFSvg"
            _cloudinarySettings.Value.CloudName,
            _cloudinarySettings.Value.ApiKey,
            _cloudinarySettings.Value.ApiSecret
          );

            _cloudinary = new Cloudinary(account);
        }

        public async Task<List<ImageUploadResult>> AddPhoto(IFormFile[] files)
        {
            var imageupload = new List<ImageUploadResult>();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using var stream = file.OpenReadStream();

                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.FileName, stream),
                        Transformation = new Transformation().Height(100).Width(100).Crop("fill").Gravity("face"),

                    };

                    var upload = await _cloudinary.UploadAsync(uploadParams);
                    imageupload.Add(upload);

                    /*var uploadResult imageupload.Url = uploadResult.SecureUrl;
                        imageupload.PublicId = uploadResult.PublicId;*/
                    //imageupload.Format = uploadResult.Format;

                    /*var imageUrl = uploadResult.SecureUrl.ToString();
                    *//* var imageRecord = new Device { ImagePath = imageUrl };*/

                    // _repository.Device.CreateDevice(imageRecord);
                    /* return Ok(new Device { ImagePath = imageUrl });*/
                    /* _context.Images.Add(imageRecord);
                     await _context.SaveChangesAsync();*/
                    /* return Ok(new { ImageUrl = imageUrl });*/
                }

            }
                return imageupload;
        }


        public async Task<DeletionResult> DeletePhoto(string publicId)
        {
            var deleteParam = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParam);
            return result;
        }

    }

}
