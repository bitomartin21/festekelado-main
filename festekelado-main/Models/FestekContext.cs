using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace festekelado_main.Models;

public partial class FestekContext : DbContext
{
    public FestekContext()
    {
    }

    public FestekContext(DbContextOptions<FestekContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Futarok> Futaroks { get; set; }

    public virtual DbSet<Rendelesek> Rendeleseks { get; set; }

    public virtual DbSet<Szinek> Szineks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=festek;user=root;password=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Futarok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("futarok");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(30)
                .HasColumnName("nev");
        });

        modelBuilder.Entity<Rendelesek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rendelesek");

            entity.HasIndex(e => e.Futarid, "futarid");

            entity.HasIndex(e => e.Szinid, "szinid");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Címzett)
                .HasMaxLength(50)
                .HasColumnName("címzett");
            entity.Property(e => e.Futarid)
                .HasColumnType("int(11)")
                .HasColumnName("futarid");
            entity.Property(e => e.Rendeltdb)
                .HasColumnType("int(11)")
                .HasColumnName("rendeltdb");
            entity.Property(e => e.Szinid)
                .HasColumnType("int(11)")
                .HasColumnName("szinid");
            entity.Property(e => e.osszar)
                .HasColumnType("int(11)")
                .HasColumnName("osszar");

            entity.HasOne(d => d.Futar).WithMany(p => p.Rendeleseks)
                .HasForeignKey(d => d.Futarid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("rendelesek_ibfk_1");

            entity.HasOne(d => d.Szin).WithMany(p => p.Rendeleseks)
                .HasForeignKey(d => d.Szinid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("rendelesek_ibfk_2");
        });

        modelBuilder.Entity<Szinek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("szinek");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Db)
                .HasColumnType("int(11)")
                .HasColumnName("db");
            entity.Property(e => e.Szin)
                .HasMaxLength(30)
                .HasColumnName("szin");
            entity.Property(e => e.ar)
                .HasColumnType("int(11)")
                .HasColumnName("ar");
            entity.Property(e => e.kepurl)
                .HasMaxLength(255)
                .HasColumnName("kepurl");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
