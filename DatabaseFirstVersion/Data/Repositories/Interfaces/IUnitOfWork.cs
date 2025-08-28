// 使用 UnitOfWork 統一管理多個 Repository
namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository Articles { get; }
        IClubEventRepository ClubEvents { get; }
        IClubMemberRepository ClubMembers { get; }
        IClubRepository Clubs { get; }
        IEnrollmentRepository Enrollments { get; }
        IMediaRepository Medias { get; }
        IMessageRepository Messages { get; }
        IUserRepository Users { get; }
        Task<int> SaveChangesAsync();
    }
}
