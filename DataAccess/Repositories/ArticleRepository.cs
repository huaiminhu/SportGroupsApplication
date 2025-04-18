﻿using SportGroups.Data.Data;
using SportGroups.Shared.Entities;
using SportGroups.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SportGroups.Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {

        private readonly SportGroupsDbContext _context;
        public ArticleRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateArticleAsync(Article article)
        {
            await _context.Articles.AddAsync(article);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Article?> GetArticleByIdAsync(int articleId)
        {
            return await _context.Articles.FirstOrDefaultAsync(a => a.ArticleId == articleId);
        }

        public async Task<bool> DeleteArticleAsync(int articleId)
        {
            var existing = await _context.Articles.FirstOrDefaultAsync(a => a.ArticleId == articleId);
            if (existing == null)
            {
                return false;
            }
            _context.Articles.Remove(existing);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Article>> GetAllArticlesOfClubAsync(int clubId)
        {
            return await _context.Articles.Include(a => a.ClubId == clubId).ToListAsync();
        }

        public async Task<List<Article>> GetAllArticlesBySportAsync(Sport sport)
        {
            var sportParam = new SqlParameter("@sport", sport);
            return await _context.Articles
                .FromSqlRaw("EXEC usp_GetAll_Articles_BySport @sport", sportParam)
                .ToListAsync();
        }

        public async Task<List<Article>> GetAllArticlesByKeywordAsync(string keyword)
        {
            var keywordParam = new SqlParameter("@keyword", keyword);
            return await _context.Articles
                .FromSqlRaw("EXEC usp_GetAll_Articles_ByKeyword @keyword", keywordParam)
                .ToListAsync();
        }

        public async Task<bool> UpdateTitleAsync(int articleId, string newTitle)
        {
            var existing = await _context.Articles.FirstOrDefaultAsync(a => a.ArticleId == articleId);
            if(existing == null)
            {
                return false;
            }
            existing.Title = newTitle;
            _context.Entry(existing).Property(a => a.Title).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateContentAsync(int articleId, string newContent)
        {
            var existing = await _context.Articles.FirstOrDefaultAsync(a => a.ArticleId == articleId);
            if (existing == null)
            {
                return false;
            }
            existing.ArticleContent = newContent;
            _context.Entry(existing).Property(a => a.ArticleContent).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateDateAsync(int articleId, DateTime latestEdit)
        {
            var existing = await _context.Articles.FirstOrDefaultAsync(a => a.ArticleId == articleId);
            if (existing == null)
            {
                return false;
            }
            existing.EditDate = latestEdit;
            _context.Entry(existing).Property(a => a.EditDate).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
