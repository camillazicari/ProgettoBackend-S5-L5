using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProgettoBackend_S5_L5.Models;

[Table("VERBALE_VIOLAZIONE")]
public partial class VerbaleViolazione
{
    [Key]
    [Column("id_verbale_violazione")]
    public int IdVerbaleViolazione { get; set; }

    [Column("idverbale")]
    public int Idverbale { get; set; }

    [Column("idviolazione")]
    public int Idviolazione { get; set; }

    [ForeignKey("Idverbale")]
    [InverseProperty("VerbaleViolaziones")]
    public virtual Verbale IdverbaleNavigation { get; set; } = null!;

    [ForeignKey("Idviolazione")]
    [InverseProperty("VerbaleViolaziones")]
    public virtual TipoViolazione IdviolazioneNavigation { get; set; } = null!;
}
