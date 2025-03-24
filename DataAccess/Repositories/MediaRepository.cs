using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MediaRepository : IMediaRepository
    {

        private readonly SportGroupsDbContext _context;
        public MediaRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public Task<bool> AddMediaAsync(Media media)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMediaAsync(int mediaId)
        {
            throw new NotImplementedException();
        }

        public Task<Media> GetMediaAsync(int mediaId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUrlAsync(int mediaId, string newUrl)
        {
            throw new NotImplementedException();
        }
    }
}
