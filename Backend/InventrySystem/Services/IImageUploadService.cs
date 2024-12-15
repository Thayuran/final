
using CloudinaryDotNet.Actions;

namespace MagicPOS.Services
{
    public interface IImageUploadService
    {
        Task <List<ImageUploadResult>> AddPhoto(IFormFile[] file);
        Task<DeletionResult> DeletePhoto(string publicId);
    }
}
