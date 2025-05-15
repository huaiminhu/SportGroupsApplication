using Microsoft.AspNetCore.Http;
using SportGroups.Business.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Infrastructure.Services
{
    public class MediaService : IMediaService
    {
        private readonly string _rootPath = "wwwroot/uploads";

        public async Task<string> SaveMediaAsync(IFormFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(_rootPath, fileName);

            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

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
