﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories
{
    public class ClubMemberRepository : IClubMemberRepository
    {

        private readonly SportGroupsDbContext _context;
        public ClubMemberRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task AddMemberAsync(int userId, int clubId, string email, DateTime joinDate)
        {
            var uIdParam = new SqlParameter("@userId", userId);
            var cIdParam = new SqlParameter("@clubId", clubId);
            var emailParam = new SqlParameter("@email", email);
            var dateParam = new SqlParameter("@joinDate", joinDate);
            await _context.Database
                .ExecuteSqlRawAsync(
                "EXEC usp_Create_ClubMembers_AddMember @userId, @clubId, @email, @joinDate", 
                uIdParam, cIdParam, emailParam, dateParam);
        }

        public async Task<List<Club>> GetAllClubsOfUserAsync(int userId)
        {
            var uIdParam = new SqlParameter("@userId", userId);
            return await _context.Clubs
                .FromSqlRaw("EXEC usp_GetAll_Clubs_OfUser @userId", uIdParam)
                .ToListAsync();
        }
    }
}
