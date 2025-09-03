using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SportGroups.Data.Entities;

[Index("ClubId", Name = "IX_ClubEvents_ClubId")]
[Index("EventName", Name = "IX_ClubEvents_EventName")]
[Index("Sport", Name = "IX_ClubEvents_Sport")]
[Index("EventName", Name = "UQ__ClubEven__59D2B7265A0F3E6D", IsUnique = true)]
[Index("EventDescription", Name = "UQ__ClubEven__5C81D68BE859D9FE", IsUnique = true)]
public partial class ClubEvent
{
    [Key]
    public int ClubEventId { get; set; }

    public int EventType { get; set; }

    public int Sport { get; set; }

    [StringLength(100)]
    public string EventName { get; set; } = null!;

    [StringLength(255)]
    public string EventDescription { get; set; } = null!;

    [StringLength(100)]
    public string EventAddress { get; set; } = null!;

    public DateTime? Starting { get; set; }

    public DateTime? Ending { get; set; }

    public int ClubId { get; set; }

    [ForeignKey("ClubId")]
    [InverseProperty("ClubEvents")]
    public virtual Club Club { get; set; } = null!;

    [InverseProperty("ClubEvent")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
