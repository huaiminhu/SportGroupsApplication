using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SportGroups.Data.Entities;

[Index("ClubId", Name = "IX_ClubMessages_ClubId")]
[Index("Title", Name = "UQ__ClubMess__2CB664DC609F7DAC", IsUnique = true)]
[Index("MessageContent", Name = "UQ__ClubMess__BA5BF8DCB76BBA3F", IsUnique = true)]
public partial class ClubMessage
{
    [Key]
    public int ClubMessageId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    [StringLength(255)]
    public string MessageContent { get; set; } = null!;

    public DateTime? PostedDate { get; set; }

    public int ClubId { get; set; }

    [ForeignKey("ClubId")]
    [InverseProperty("ClubMessages")]
    public virtual Club Club { get; set; } = null!;
}
