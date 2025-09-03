using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SportGroups.Data.Entities;

[Index("ClubId", Name = "IX_Articles_ClubId")]
[Index("Sport", Name = "IX_Articles_Sport")]
[Index("Title", Name = "IX_Articles_Title")]
public partial class Article
{
    [Key]
    public int ArticleId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public int Sport { get; set; }

    public string ArticleContent { get; set; } = null!;

    public DateTime? PostedDate { get; set; }

    public DateTime? EditedDate { get; set; }

    public int ClubId { get; set; }

    [ForeignKey("ClubId")]
    [InverseProperty("Articles")]
    public virtual Club Club { get; set; } = null!;

    [InverseProperty("Article")]
    public virtual ICollection<Media> Media { get; set; } = new List<Media>();
}
