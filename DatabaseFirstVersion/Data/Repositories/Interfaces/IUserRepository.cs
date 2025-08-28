using SportGroups.Data.Entities;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        
        // 以使用者名稱取得使用者
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByIdAsync(int userId);
        void UpdateUser(User user);

        // 以更新Token取得使用者
        Task<User?> GetUserByRefreshTokenAsync(string refreshToken);
    }
}
