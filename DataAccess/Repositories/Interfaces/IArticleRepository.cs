﻿using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        Task CreateArticle(Article article);
        List<Article> GetAllArticleOfClub(int clubId);
        Task UpdateArticle(Article article);
        Task DeleteArticle(int articleId);
    }
}
