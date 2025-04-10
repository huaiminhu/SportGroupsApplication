using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;
        public MediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public Task<bool> AddMediaAsync(MediaDto media)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ChangeUrlAsync(int mediaId, string newUrl)
        {
            return await _mediaRepository.UpdateUrlAsync(mediaId, newUrl); 
        }

        public async Task<bool> DeleteMediaAsync(int mediaId)
        {
            return await _mediaRepository.DeleteMediaAsync(mediaId);
        }

        public Task<MediaDto?> GetMediaAsync(int mediaId)
        {
            throw new NotImplementedException();
        }
    }
}
