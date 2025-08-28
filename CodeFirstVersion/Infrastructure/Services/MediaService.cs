using Microsoft.AspNetCore.Http;
using SportGroups.Business.Services.IServices;

namespace SportGroups.Infrastructure.Services
{
    public class MediaService : IMediaService
    {
        // 設定媒體檔案存放路徑
        private readonly string _rootPath = "wwwroot/uploads";

        public async Task<string> SaveMediaAsync(IFormFile file)
        {
            // 辨識路徑是否存在
            if (!Directory.Exists(_rootPath))
            {
                Directory.CreateDirectory(_rootPath);
            }

            // 定義檔名
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            // 定義檔案路徑
            var fullPath = Path.Combine(_rootPath, fileName);
            // 建立實體檔案
            using var stream = new FileStream(fullPath, FileMode.Create);
            // 寫入實體檔案
            await file.CopyToAsync(stream);
            // 回傳檔案儲存路徑
            return $"/uploads/{fileName}";
        }

        public Task DeleteMediaAsync(string path)
        {
            var fullPath = Path.Combine("wwwroot", path.TrimStart('/'));
            if (File.Exists(fullPath))
                File.Delete(fullPath);
            return Task.CompletedTask;
        }
    }
}
