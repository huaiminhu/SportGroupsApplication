using SportGroups.Shared.Entities;
using SportGroups.Shared.DTOs;
using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IClubService
    {
        // 取得使用指定運動項目所有社團
        Task<List<ClubInfoDto>> GetClubsBySportAsync(Sport sport);
        
        // 取得使用指定關鍵字所有社團
        Task<List<ClubInfoDto>> GetClubsByKeywordAsync(string keyword);
        
        // 取得社團資訊
        Task<ClubInfoDto?> GetClubInfoAsync(int clubId);
        Task<bool> CreateClubAsync(NewClubDto createDto);
        Task<bool> ChangeNameAsync(int clubId, string newName);
        Task<bool> ChangePhoneAsync(int clubId, string newPhoneNum);
        Task<bool> ChangeEmailAsync(int clubId, string newEmail);
        Task<bool> ChangeDescrptionAsync(int clubId, string newDescription);
        Task<bool> DeleteClubAsync(int clubId);
    }
}
