using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SportGroups.Data.Repositories
{
    public class MediaRepository : IMediaRepository
    {

        private readonly SportGroupsDbContext _context;
        public MediaRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task AddMediaAsync(Media media)
        {
            await _context.Medias.AddAsync(media);
        }

        public void DeleteMedia(Media media)
        {
            _context.Medias.Remove(media);
        }

        public async Task<List<Media>> GetAllMediasOfArticleAsync(int articleId)
        {
            return await _context.Medias.Where(m => m.ArticleId == articleId).ToListAsync();
        }

        public async Task<Media?> GetMediaByIdAsync(int mediaId)
        {
            return await _context.Medias.FirstOrDefaultAsync(m => m.MediaId == mediaId);
        }

        public void UpdateMedia(Media media)
        {
            _context.Medias.Update(media);
        }
    }
}
