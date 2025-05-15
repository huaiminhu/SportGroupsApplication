using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IMediaService
    {
        Task<string> SaveMediaAsync(IFormFile file);
        Task DeleteMediaAsync(string path);
    }
}
