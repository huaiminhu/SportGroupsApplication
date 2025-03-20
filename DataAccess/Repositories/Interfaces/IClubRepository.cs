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

        // 取得指定運動項目類別的所有社團
        Task<List<Club>> GetAllClubsBySport(Sport sport);
        Task UpdateClub(Club club);
        Task DeleteClub(int clubId);
    }
}
