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
    public class ClubMemberRepository : IClubMemberRepository
    {

        private readonly SportGroupsDbContext _context;
        public ClubMemberRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public Task AddMember(int userId, int clubId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Club>> GetAllClubsOfUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
