using SportGroups.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
