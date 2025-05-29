using SportGroups.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IMediaRepository
    {
        Task AddMediaAsync(Media media);
        Task<List<Media>> GetAllMediasOfArticleAsync(int articleId);
        Task<Media?> GetMediaByIdAsync(int mediaId);
        void UpdateMedia(Media media);
        //Task<bool> UpdateNameAsync(int mediaId, string newName);
        //Task<bool> UpdateUrlAsync(int mediaId, string newUrl);
        void DeleteMedia(Media media);
    }
}
