using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SportGroups.Data.Entities;

[Index("FileUrl", Name = "UQ__Medias__098A0CEAF7741D0A", IsUnique = true)]
public partial class Media
{
    [Key]
    public int MediaId { get; set; }

    [StringLength(255)]
    public string MediaFileName { get; set; } = null!;

    public int MediaType { get; set; }

    [StringLength(255)]
    public string FileUrl { get; set; } = null!;

    public DateTime? AddedDate { get; set; }

    public int ArticleId { get; set; }

    [ForeignKey("ArticleId")]
    [InverseProperty("Media")]
    public virtual Article Article { get; set; } = null!;
}
