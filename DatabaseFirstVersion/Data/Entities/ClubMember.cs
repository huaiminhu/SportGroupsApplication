using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SportGroups.Data.Entities;

[PrimaryKey("UserId", "ClubId")]
[Index("ClubId", "UserId", Name = "IX_ClubMembers_ClubId_UserId")]
[Index("UserId", Name = "IX_ClubMembers_UserId")]
public partial class ClubMember
{
    [Key]
    public int UserId { get; set; }

    [Key]
    public int ClubId { get; set; }

    public DateTime? JoinedDate { get; set; }

    [ForeignKey("ClubId")]
    [InverseProperty("ClubMembers")]
    public virtual Club Club { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("ClubMembers")]
    public virtual User User { get; set; } = null!;
}
