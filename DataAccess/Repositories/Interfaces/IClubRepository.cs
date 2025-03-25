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
        Task<bool> CreateClubAsync(Club club);
        Task<Club?> GetClubById(int clubId);

        // 取得指定運動項目類別的所有社團
        Task<List<Club>> GetAllClubsBySportAsync(Sport sport);
        Task<bool> UpdateNameAsync(int clubId, string newName);
        Task<bool> UpdatePhoneAsync(int clubId, string newPhoneNum);
        Task<bool> UpdateEmailAsync(int clubId, string newEmail);
        Task<bool> UpdateDescrptionAsync(int clubId, string newDescription);
        Task<bool> DeleteClubAsync(int clubId);
    }
}
