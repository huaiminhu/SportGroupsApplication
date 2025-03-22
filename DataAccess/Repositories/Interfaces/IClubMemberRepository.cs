﻿using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IClubMemberRepository
    {
        // 新增社團成員
        Task AddMemberAsync(int userId, int clubId);
        
        // 取得使用者參與的所有社團
        Task<List<Club>> GetAllClubsOfUserAsync(int userId);
    }
}
