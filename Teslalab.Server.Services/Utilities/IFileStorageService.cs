using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Teslalab.Server.Services.Utilities
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(IFormFile formFile, string folderName);

        void RemoveFile(string filePath);
    }
}