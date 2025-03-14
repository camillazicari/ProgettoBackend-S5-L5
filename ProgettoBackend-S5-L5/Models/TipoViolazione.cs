using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProgettoBackend_S5_L5.Models;

[Table("TIPO_VIOLAZIONE")]
public partial class TipoViolazione
{
    [Key]
    [Column("idviolazione")]
    public int Idviolazione { get; set; }

    [Column("descrizione")]
    [StringLength(200)]
    [Unicode(false)]
    public string Descrizione { get; set; } = null!;

    [InverseProperty("IdviolazioneNavigation")]
    public virtual ICollection<VerbaleViolazione> VerbaleViolaziones { get; set; } = new List<VerbaleViolazione>();
}
