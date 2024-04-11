using Microsoft.EntityFrameworkCore;
using Sofidy.Unicia.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unicia.Model.Models;

[PrimaryKey(nameof(ITyparam), nameof(IClient))]
[Table("PIMPORT")]
public record PImport: BaseEntity
{ 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public decimal ITyparam { get; set; }
     
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string IClient { get; set; } = null!;

    public string? ICorresp1 { get; set; }

    public string? ICorresp2 { get; set; }

    public string? ICorresp3 { get; set; }

    /// <summary>
    /// Descritptif du Transcodage saisi
    /// </summary>
    public string? TDescriptif { get; set; }
}
