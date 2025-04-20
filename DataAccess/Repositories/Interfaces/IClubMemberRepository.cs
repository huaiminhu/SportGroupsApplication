using SportGroups.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IClubMemberRepository
    {
        // 新增社團成員
        Task<bool> AddMemberAsync(int userId, int clubId, string email, DateTime joinDate);
        // 取得使用者參與的所有社團
        Task<List<Club>> GetAllClubsOfUserAsync(int userId);
    }
}
