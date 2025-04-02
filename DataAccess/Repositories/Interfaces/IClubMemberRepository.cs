using SportGroups.Data.Entities;
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
        Task<bool> AddMemberAsync(ClubMember member);
        // 取得使用者參與的所有社團
        Task<List<Club>> GetAllClubsOfUserAsync(Guid userId);
    }
}
