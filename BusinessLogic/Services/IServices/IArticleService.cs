﻿using SportGroups.Shared.DTOs.ArticleDTOs;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IArticleService
    {
        // 取得使用指定運動項目所有文章
        Task<List<ArticleInfoDto>> GetArticlesBySportAsync(Sport sport);
        
        // 取得使用指定關鍵字所有文章
        Task<List<ArticleInfoDto>> GetArticlesByKeywordAsync(string keyword);
        Task<ArticleInfoDto?> GetArticleByIdAsync(int articleId);
        Task<bool> CreateArticleAsync(NewArticleDto createDto);
        Task<bool> ChangeTitleAsync(int articleId, string newTitle);
        Task<bool> ChangeContentAsync(int articleId, string newContent);
        Task<bool> ChangeDateAsync(int articleId, DateTime latestEdit);
        Task<bool> DeleteArticleAsync(int articleId);
    }
}
