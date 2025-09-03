using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SportGroups.Data.Entities;

[PrimaryKey("UserId", "ClubEventId")]
[Index("ClubEventId", "UserId", Name = "IX_Enrollments_ClubEventId_UserId")]
[Index("UserId", Name = "IX_Enrollments_UserId")]
public partial class Enrollment
{
    [Key]
    public int UserId { get; set; }

    [Key]
    public int ClubEventId { get; set; }

    [StringLength(20)]
    public string Phone { get; set; } = null!;

    public DateTime? EnrolledDate { get; set; }

    [ForeignKey("ClubEventId")]
    [InverseProperty("Enrollments")]
    public virtual ClubEvent ClubEvent { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Enrollments")]
    public virtual User User { get; set; } = null!;
}
