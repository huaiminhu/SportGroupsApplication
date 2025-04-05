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
    }
}
