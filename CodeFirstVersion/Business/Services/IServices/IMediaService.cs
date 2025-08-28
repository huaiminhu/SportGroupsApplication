using Microsoft.AspNetCore.Http;

namespace SportGroups.Business.Services.IServices
{
    public interface IMediaService
    {
        // 儲存媒體檔案
        Task<string> SaveMediaAsync(IFormFile file);
        Task DeleteMediaAsync(string path);
    }
}
