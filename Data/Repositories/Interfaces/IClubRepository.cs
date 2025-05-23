using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs.ClubDTOs;
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
        Task CreateClubAsync(Club club);
        Task<Club?> GetClubByIdAsync(int clubId);

        // 依條件取得指定社團
        Task<List<Club>> GetClubsByConditionAsync(ClubsQueryConditions condition);

        //// 取得指定運動項目類別的所有社團
        //Task<List<Club>> GetAllClubsBySportAsync(Sport sport);

        //// 取得包含指定關鍵字的所有社團
        //Task<List<Club>> GetAllClubsByKeywordAsync(string keyword);
        void UpdateClub(Club club);
        //Task<bool> UpdateNameAsync(int clubId, string newName);
        //Task<bool> UpdatePhoneAsync(int clubId, string newPhoneNum);
        //Task<bool> UpdateEmailAsync(int clubId, string newEmail);
        //Task<bool> UpdateDescrptionAsync(int clubId, string newDescription);
        void DeleteClub(Club club);
    }
}
