using SportGroups.Data.Entities;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IClubRepository
    {
        Task<bool> CreateClubAsync(Club club);
        Task<Club?> GetClubByIdAsync(int clubId);

        // 取得指定運動項目類別的所有社團
        Task<List<Club>> GetAllClubsBySportAsync(Sport sport);

        // 取得包含指定關鍵字的所有社團
        Task<List<Club>> GetAllClubsByKeywordAsync(string keyword);
        Task<bool> UpdateNameAsync(int clubId, string newName);
        Task<bool> UpdatePhoneAsync(int clubId, string newPhoneNum);
        Task<bool> UpdateEmailAsync(int clubId, string newEmail);
        Task<bool> UpdateDescrptionAsync(int clubId, string newDescription);
        Task<bool> DeleteClubAsync(int clubId);
    }
}
