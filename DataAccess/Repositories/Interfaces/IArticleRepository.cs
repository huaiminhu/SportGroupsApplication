using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        Task<bool> CreateArticleAsync(Article article);

        // 取得社團所有發布的文章
        Task<List<Article>> GetAllArticleOfClubAsync(int clubId);
        Task<bool> UpdateTitleAsync(int articleId, string newTitle);
        Task<bool> UpdateContentAsync(int articleId, string newContent);
        Task<bool> UpdateDateAsync(int articleId, DateTime latestEdit);
        Task<bool> DeleteArticleAsync(int articleId);
    }
}
