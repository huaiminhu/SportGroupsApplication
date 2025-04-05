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
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetArticlesBySportAsync(Sport sport);
        Task<List<ArticleDto>> GetArticlesByKeywordAsync(string keyword);
    }
}
