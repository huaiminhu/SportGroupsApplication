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

        public void DeleteMedia(Media media)
        {
            _context.Medias.Remove(media);
        }

    }
}
