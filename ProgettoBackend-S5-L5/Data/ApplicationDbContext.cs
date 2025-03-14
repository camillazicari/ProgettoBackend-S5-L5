using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProgettoBackend_S5_L5.Models;

namespace ProgettoBackend_S5_L5.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anagrafica> Anagraficas { get; set; }

    public virtual DbSet<TipoViolazione> TipoViolaziones { get; set; }

    public virtual DbSet<Verbale> Verbales { get; set; }

    public virtual DbSet<VerbaleViolazione> VerbaleViolaziones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=WIN-BG5QTDS27CD\\SQLEXPRESS;Database=PoliziaMunicipale;User Id=sa;Password=sa;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anagrafica>(entity =>
        {
            entity.HasKey(e => e.Idanagrafica).HasName("PK__ANAGRAFI__7AB1023CB4FE541D");
        });

        modelBuilder.Entity<TipoViolazione>(entity =>
        {
            entity.HasKey(e => e.Idviolazione).HasName("PK__TIPO_VIO__AF77BD92DA791D85");
        });

        modelBuilder.Entity<Verbale>(entity =>
        {
            entity.HasKey(e => e.Idverbale).HasName("PK__VERBALE__073D2A450787FA15");

            entity.HasOne(d => d.IdanagraficaNavigation).WithMany(p => p.Verbales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_ANAGRAFICA");
        });

        modelBuilder.Entity<VerbaleViolazione>(entity =>
        {
            entity.HasKey(e => e.IdVerbaleViolazione).HasName("PK__VERBALE___E27ED24645659F1C");

            entity.HasOne(d => d.IdverbaleNavigation).WithMany(p => p.VerbaleViolaziones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_VERBALE");

            entity.HasOne(d => d.IdviolazioneNavigation).WithMany(p => p.VerbaleViolaziones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_VIOLAZIONE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
