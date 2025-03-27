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

        public async Task<Media?> GetMediaAsync(int mediaId)
        {
            return await _context.Medias.FirstOrDefaultAsync(m => m.ArticleMediaId == mediaId);
        }

        public async Task<bool> UpdateUrlAsync(int mediaId, string newUrl)
        {
            var existing = await _context.Medias.FirstOrDefaultAsync(m => m.ArticleMediaId == mediaId);
            if(existing == null)
            {
                return false;
            }
            existing.Url = newUrl;
            _context.Entry(existing).Property(m => m.Url).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
