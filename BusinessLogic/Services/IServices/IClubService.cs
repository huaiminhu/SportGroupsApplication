using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs;
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
        Task<List<ClubDto>> GetClubsBySportAsync(Sport sport);
        Task<List<ClubDto>> GetClubsByKeywordAsync(string keyword);
        Task<ClubDto?> GetClubInfoAsync(int clubId);
        Task<bool> CreateClubAsync(ClubDto clubDto);
        Task<bool> ChangeNameAsync(int clubId, string newName);
        Task<bool> ChangePhoneAsync(int clubId, string newPhoneNum);
        Task<bool> ChangeEmailAsync(int clubId, string newEmail);
        Task<bool> ChangeDescrptionAsync(int clubId, string newDescription);
        Task<bool> DeleteClubAsync(int clubId);
    }
}
