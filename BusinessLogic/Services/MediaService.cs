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

        public Task<bool> ChangeUrlAsync(int mediaId, string newUrl)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMediaAsync(int mediaId)
        {
            throw new NotImplementedException();
        }

        public Task<MediaDto?> GetMediaAsync(int mediaId)
        {
            throw new NotImplementedException();
        }
    }
}
