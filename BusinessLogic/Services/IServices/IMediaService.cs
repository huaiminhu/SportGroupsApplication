using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IMediaService
    {
        Task<bool> AddMediaAsync(MediaDto media);
        Task<MediaDto?> GetMediaAsync(int mediaId);
        Task<bool> ChangeUrlAsync(int mediaId, string newUrl);
        Task<bool> DeleteMediaAsync(int mediaId);
    }
}
