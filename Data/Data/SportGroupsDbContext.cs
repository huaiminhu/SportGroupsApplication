using SportGroups.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace SportGroups.Data.Data
{
    public class SportGroupsDbContext : DbContext
    {
        public SportGroupsDbContext(DbContextOptions<SportGroupsDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ClubMember> ClubMembers { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<ClubEvent> ClubEvents { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Media> Medias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 設定社團成員(ClubMember)的複合主鍵
            modelBuilder.Entity<ClubMember>()
                .HasKey(cm => new { cm.ClubId, cm.UserId });

            modelBuilder.Entity<ClubMember>()
                .HasOne(cm => cm.Club)
                .WithMany(c => c.Members)
                .HasForeignKey(cm => cm.ClubId);

            modelBuilder.Entity<ClubMember>()
                .HasOne(cm => cm.User)
                .WithMany(u => u.Clubs)
                .HasForeignKey(cm => cm.UserId);

            // 設定報名資訊(Enrollment)的複合主鍵
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.ClubEventId, e.UserId });

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.ClubEvent)
                .WithMany(ce => ce.Enrollments)
                .HasForeignKey(e => e.ClubEventId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.User)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.UserId);
        }

    }
}
