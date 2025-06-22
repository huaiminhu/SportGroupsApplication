using SportGroups.Data.Entities;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IMediaRepository
    {
        Task AddMediaAsync(Media media);
        Task<List<Media>> GetAllMediasOfArticleAsync(int articleId);
        Task<Media?> GetMediaByIdAsync(int mediaId);
        void UpdateMedia(Media media);
        void DeleteMedia(Media media);
    }
}
