using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories
{
    public class ClubMemberRepository : IClubMemberRepository
    {

        private readonly SportGroupsDbContext _context;
        public ClubMemberRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public Task<bool> AddMemberAsync(int userId, int clubId)
        {
            // stored procedures
            throw new NotImplementedException();
        }

        public Task<List<Club>> GetAllClubsOfUserAsync(int userId)
        {
            // stored procedures
            throw new NotImplementedException();
        }
    }
}
