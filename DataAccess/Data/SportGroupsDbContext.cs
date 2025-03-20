using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
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
    }
}
