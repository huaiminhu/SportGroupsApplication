using SportGroups.Shared.DTOs.MediaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IMediaService
    {
        Task<bool> AddMediaAsync(NewMediaDto newMediaDto);
        Task<List<MediaInfoDto>> GetAllMediasOfArticleAsync(int articleId);
        Task<bool> ChangeUrlAsync(int mediaId, string newUrl);
        Task<bool> DeleteMediaAsync(int mediaId);
    }
}
