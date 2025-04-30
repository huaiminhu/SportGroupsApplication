using SportGroups.Data.Data;
using SportGroups.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SportGroupsDbContext _context;
        public IArticleRepository Articles { get; }
        public IClubEventRepository ClubEvents { get; }
        public IClubMemberRepository ClubMembers { get; }
        public IClubRepository Clubs { get; }
        public IEnrollmentRepository Enrollments { get; }
        public IMessageRepository Messages { get; }
        public IMediaRepository Medias { get; }
        public IUserRepository Users { get; }
        public UnitOfWork(SportGroupsDbContext context,
            IArticleRepository articleRepository,
            IClubEventRepository clubEventRepository,
            IClubMemberRepository clubMemberRepository,
            IClubRepository clubRepository,
            IEnrollmentRepository enrollmentRepository,
            IMessageRepository messagesRepository, 
            IMediaRepository mediaRepository, 
            IUserRepository userRepository)
        {
            _context = context;
            Articles = articleRepository;
            ClubEvents = clubEventRepository;
            ClubMembers = clubMemberRepository;
            Clubs = clubRepository;
            Enrollments = enrollmentRepository;
            Messages = messagesRepository;
            Medias = mediaRepository;
            Users = userRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
