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
        Task CreateClubAsync(Club club);

        // 取得指定運動項目類別的所有社團
        Task<List<Club>> GetAllClubsBySportAsync(Sport sport);
        Task UpdateClubAsync(Club club);
        Task DeleteClubAsync(int clubId);
    }
}
