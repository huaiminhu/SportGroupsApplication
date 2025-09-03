using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SportGroups.Data.Entities;

public partial class SportGroupsDbContext : DbContext
{
    public SportGroupsDbContext()
    {
    }

    public SportGroupsDbContext(DbContextOptions<SportGroupsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<ClubEvent> ClubEvents { get; set; }

    public virtual DbSet<ClubMember> ClubMembers { get; set; }

    public virtual DbSet<ClubMessage> ClubMessages { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Media> Medias { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-MCD6VS3S\\SQLEXPRESS;Database=SportGroupDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.ArticleId).HasName("PK__Articles__9C6270E82ED9293A");

            entity.Property(e => e.EditedDate).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.PostedDate).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Club).WithMany(p => p.Articles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Articles__ClubId__5AEE82B9");
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.ClubId).HasName("PK__Clubs__D35058E73335A83E");

            entity.Property(e => e.EstablishedTime).HasDefaultValueSql("(sysdatetime())");
        });

        modelBuilder.Entity<ClubEvent>(entity =>
        {
            entity.HasKey(e => e.ClubEventId).HasName("PK__ClubEven__D67B34602AFDEF1C");

            entity.HasOne(d => d.Club).WithMany(p => p.ClubEvents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClubEvent__ClubI__5629CD9C");
        });

        modelBuilder.Entity<ClubMember>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.ClubId }).HasName("PK__ClubMemb__7ABDC9C2E8ADB579");

            entity.Property(e => e.JoinedDate).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Club).WithMany(p => p.ClubMembers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClubMembe__ClubI__6A30C649");

            entity.HasOne(d => d.User).WithMany(p => p.ClubMembers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClubMembe__UserI__693CA210");
        });

        modelBuilder.Entity<ClubMessage>(entity =>
        {
            entity.HasKey(e => e.ClubMessageId).HasName("PK__ClubMess__47F9E50DD770B36F");

            entity.Property(e => e.PostedDate).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Club).WithMany(p => p.ClubMessages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClubMessa__ClubI__656C112C");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.ClubEventId }).HasName("PK__Enrollme__0AEF7F0AB0D1D9C9");

            entity.Property(e => e.EnrolledDate).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.ClubEvent).WithMany(p => p.Enrollments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enrollmen__ClubE__6EF57B66");

            entity.HasOne(d => d.User).WithMany(p => p.Enrollments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enrollmen__UserI__6E01572D");
        });

        modelBuilder.Entity<Media>(entity =>
        {
            entity.HasKey(e => e.MediaId).HasName("PK__Medias__B2C2B5CF6601E556");

            entity.Property(e => e.AddedDate).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Article).WithMany(p => p.Media)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medias__ArticleI__5FB337D6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CD3E25B21");

            entity.Property(e => e.RegisterDate).HasDefaultValueSql("(sysdatetime())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
