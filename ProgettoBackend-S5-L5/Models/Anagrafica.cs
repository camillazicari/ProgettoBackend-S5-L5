using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProgettoBackend_S5_L5.Models;

[Table("ANAGRAFICA")]
[Index("CodFisc", Name = "UQ__ANAGRAFI__063721E18C083097", IsUnique = true)]
public partial class Anagrafica
{
    [Key]
    [Column("idanagrafica")]
    public int Idanagrafica { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Cognome { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Indirizzo { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string Citta { get; set; } = null!;

    [Column("CAP")]
    [StringLength(5)]
    [Unicode(false)]
    public string Cap { get; set; } = null!;

    [Column("Cod_Fisc")]
    [StringLength(16)]
    [Unicode(false)]
    public string CodFisc { get; set; } = null!;

    [InverseProperty("IdanagraficaNavigation")]
    public virtual ICollection<Verbale> Verbales { get; set; } = new List<Verbale>();
}
