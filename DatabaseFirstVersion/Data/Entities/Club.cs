using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SportGroups.Data.Entities;

[Index("ClubName", Name = "IX_Clubs_ClubName")]
[Index("Sport", Name = "IX_Clubs_Sport")]
[Index("ClubName", Name = "UQ__Clubs__7A58A9CF7DD63992", IsUnique = true)]
[Index("ClubDescription", Name = "UQ__Clubs__F50BB8BEE9B527FB", IsUnique = true)]
public partial class Club
{
    [Key]
    public int ClubId { get; set; }

    [StringLength(100)]
    public string ClubName { get; set; } = null!;

    public int Sport { get; set; }

    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string ClubDescription { get; set; } = null!;

    public DateTime? EstablishedDate { get; set; }

    [InverseProperty("Club")]
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    [InverseProperty("Club")]
    public virtual ICollection<ClubEvent> ClubEvents { get; set; } = new List<ClubEvent>();

    [InverseProperty("Club")]
    public virtual ICollection<ClubMember> ClubMembers { get; set; } = new List<ClubMember>();

    [InverseProperty("Club")]
    public virtual ICollection<ClubMessage> ClubMessages { get; set; } = new List<ClubMessage>();
}
