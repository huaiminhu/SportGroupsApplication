using DataAccess.Entities;
using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IClubRepository
    {
        Task CreateClub(Club club);
        List<Club> GetAllClubsOfUser(int userId);
        List<Club> GetAllClubsBySport(Sport sport);
        Task UpdateClub(Club club);
        Task DeleteClub(int clubId);
    }
}
