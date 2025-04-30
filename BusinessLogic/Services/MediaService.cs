using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.MediaDTOs;
using SportGroups.Shared.Entities;
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
        private readonly IMapper _mapper;
        public MediaService(IMediaRepository mediaRepository, IMapper mapper)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
        }

        public async Task<bool> UploadMediaAsync(NewMediaDto newMediaDto)
        {
            var newMedia = _mapper.Map<Media>(newMediaDto);
            newMedia.AddedDate = DateTime.Now;
            return await _mediaRepository.AddMediaAsync(newMedia);
        }

        public async Task<bool> ChangeNameAsync(int mediaId, string newName)
        {
            return await _mediaRepository.UpdateNameAsync(mediaId, newName);
        }

        public async Task<bool> ChangeUrlAsync(int mediaId, string newUrl)
        {
            return await _mediaRepository.UpdateUrlAsync(mediaId, newUrl); 
        }

        public async Task<bool> DeleteMediaAsync(int mediaId)
        {
            return await _mediaRepository.DeleteMediaAsync(mediaId);
        }

        public async Task<List<MediaInfoDto>> GetAllMediasOfArticleAsync(int articleId)
        {
            var medias = await _mediaRepository.GetAllMediasOfArticleAsync(articleId);
            return _mapper.Map<List<MediaInfoDto>>(medias);
        }
    }
}
