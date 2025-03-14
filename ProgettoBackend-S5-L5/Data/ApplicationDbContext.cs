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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WIN-BG5QTDS27CD\\SQLEXPRESS;Database=PoliziaMunicipale;User Id=sa;Password=sa;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anagrafica>(entity =>
        {
            entity.HasKey(e => e.Idanagrafica).HasName("PK__ANAGRAFI__7AB1023C760D54CA");
        });

        modelBuilder.Entity<TipoViolazione>(entity =>
        {
            entity.HasKey(e => e.Idviolazione).HasName("PK__TIPO_VIO__AF77BD921F6677AD");
        });

        modelBuilder.Entity<Verbale>(entity =>
        {
            entity.HasKey(e => e.Idverbale).HasName("PK__VERBALE__073D2A45DE6A3E74");

            entity.HasOne(d => d.IdanagraficaNavigation).WithMany(p => p.Verbales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_ANAGRAFICA");
        });

        modelBuilder.Entity<VerbaleViolazione>(entity =>
        {
            entity.HasKey(e => e.IdVerbaleViolazione).HasName("PK__VERBALE___E27ED246FEEF887E");

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
