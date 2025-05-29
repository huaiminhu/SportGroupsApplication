using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.MediaDTOs;
using SportGroups.Shared.Enums;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaService _mediaService;
        private readonly IMapper _mapper;
        public MediaController(IUnitOfWork unitOfWork, 
            IMediaService mediaService, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mediaService = mediaService; 
            _mapper = mapper;
        }

        [Authorize(Roles = "ClubManager")]
        [HttpPost("upload")]
        public async Task<IActionResult> NewMedia([FromForm]IFormFile file)
        {
            var fileUrl = _mediaService.SaveMediaAsync(file).ToString();
            
            if(fileUrl == null)
            {
                return BadRequest();
            }

            var nowTime = DateTime.UtcNow;
            Media media = new Media
            {
                FileName = Guid.NewGuid() + Path.GetExtension(file.FileName),
                MediaType = file.ContentType.StartsWith("video") ? MediaType.Video : MediaType.Image,
                FileUrl = fileUrl, 
                AddedDate = nowTime,
            };

            await _unitOfWork.Medias.AddMediaAsync(media);
            await _unitOfWork.SaveChangesAsync();
            return Created(string.Empty, media);
        }

        [HttpGet("medias")]
        public async Task<ActionResult<List<MediaInfoDto>>> GetMediasOfArticle([FromBody] int articleId)
        {
            var medias = await _unitOfWork.Medias.GetAllMediasOfArticleAsync(articleId);
            if(medias == null)
            {
                return NotFound();
            }
            var transferedMedias = _mapper.Map<List<MediaInfoDto>>(medias);
            return Ok(transferedMedias);
        }

        [Authorize(Roles = "ClubManager")]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMedia([FromBody] int MediaId)
        {
            var media = await _unitOfWork.Medias.GetMediaByIdAsync(MediaId);
            if(media == null)
            {
                return BadRequest();
            }

            _unitOfWork.Medias.DeleteMedia(media);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
