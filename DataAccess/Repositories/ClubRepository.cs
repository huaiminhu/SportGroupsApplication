using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Enums;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ClubRepository : IClubRepository
    {

        private readonly SportGroupsDbContext _context;
        public ClubRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public Task CreateClubAsync(Club club)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClubAsync(int clubId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Club>> GetAllClubsBySportAsync(Sport sport)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClubAsync(Club club)
        {
            throw new NotImplementedException();
        }
    }
}
