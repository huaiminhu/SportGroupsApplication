using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SportGroups.Data.Entities;

[Index("RefreshToken", Name = "IX_Users_RefreshToken")]
[Index("UserName", Name = "IX_Users_UserName")]
[Index("NickName", Name = "UQ__Users__01E67C8B334D0819", IsUnique = true)]
[Index("Email", Name = "UQ__Users__A9D10534D88F4875", IsUnique = true)]
[Index("UserName", Name = "UQ__Users__C9F28456E18C6954", IsUnique = true)]
public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(50)]
    public string NickName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [StringLength(60)]
    public string PasswordHash { get; set; } = null!;

    public int UserRole { get; set; }

    public DateTime? RegisterDate { get; set; }

    [StringLength(255)]
    public string RefreshToken { get; set; } = null!;

    public DateTime? RefreshTokenExpiry { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<ClubMember> ClubMembers { get; set; } = new List<ClubMember>();

    [InverseProperty("User")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
