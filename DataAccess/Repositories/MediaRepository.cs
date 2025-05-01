using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories
{
    public class MediaRepository : IMediaRepository
    {

        private readonly SportGroupsDbContext _context;
        public MediaRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMediaAsync(Media media)
        {
            await _context.Medias.AddAsync(media);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteMediaAsync(int mediaId)
        {
            var existing = await _context.Medias.FirstOrDefaultAsync(m => m.ArticleMediaId == mediaId);
            if (existing == null)
            {
                return false;
            }
            _context.Medias.Remove(existing);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Media>> GetAllMediasOfArticleAsync(int articleId)
        {
            return await _context.Medias.Include(m => m.ArticleId == articleId).ToListAsync();
        }

        public async Task<bool> UpdateUrlAsync(int mediaId, string newUrl)
        {
            var existing = await _context.Medias.FirstOrDefaultAsync(m => m.ArticleMediaId == mediaId);
            if(existing == null)
            {
                return false;
            }
            existing.FileUrl = newUrl;
            _context.Entry(existing).Property(m => m.FileUrl).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateNameAsync(int mediaId, string newName)
        {
            var existing = await _context.Medias.FirstOrDefaultAsync(m => m.ArticleMediaId == mediaId);
            if (existing == null)
            {
                return false;
            }
            existing.FileName = newName;
            _context.Entry(existing).Property(m => m.FileName).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
