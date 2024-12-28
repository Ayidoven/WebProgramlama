using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebP.Models;

namespace WebP.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Kullanıcı> Kullanıcı { get; set; }
    public virtual DbSet<Hizmet> Hizmet { get; set; }

    public virtual DbSet<Randevu> Randevu { get; set; }

    public virtual DbSet<Salon> Salon { get; set; }

    public virtual DbSet<Calisan> Calisan { get; set; }  // "Çalışan" -> "Calisan"

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=Bk20032511");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Hizmet>(entity =>
        {
            entity.HasKey(e => e.Hizmetid).HasName("hizmet_pkey");

            entity.ToTable("hizmet");

            entity.Property(e => e.Hizmetid).HasColumnName("hizmetid");
            entity.Property(e => e.Hizmetadı)
                .HasMaxLength(100)
                .HasColumnName("hizmetadı");
            entity.Property(e => e.Salonid).HasColumnName("salonid");
            entity.Property(e => e.Süre).HasColumnName("süre");
            entity.Property(e => e.Ücret).HasPrecision(10, 2);

            entity.HasOne(d => d.salon).WithMany(p => p.Hizmet)
                .HasForeignKey(d => d.Salonid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hizmet_salonid_fkey");
        });

        modelBuilder.Entity<Randevu>(entity =>
        {
            entity.HasKey(e => e.Randevuid).HasName("randevu_pkey");

            entity.ToTable("randevu");

            entity.Property(e => e.Randevuid).HasColumnName("randevuid");
            entity.Property(e => e.Durum)
                .HasMaxLength(50)
                .HasColumnName("durum");
            entity.Property(e => e.Hizmetid).HasColumnName("hizmetid");
            entity.Property(e => e.Kullanıcıadı)
                .HasMaxLength(100)
                .HasColumnName("kullanıcıadı");
            entity.Property(e => e.Tarih)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("tarih");

            entity.HasOne(d => d.Hizmet).WithMany(p => p.Randevu)
                .HasForeignKey(d => d.Hizmetid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("randevu_hizmetid_fkey");

            entity.HasOne(d => d.Calisan).WithMany(p => p.Randevu)
                .HasForeignKey(d => d.Calisanid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("randevu_calisanid_fkey");  // "Çalışan" -> "Calisan"
        });

        modelBuilder.Entity<Salon>(entity =>
        {
            entity.HasKey(e => e.salonid).HasName("salon_pkey");

            entity.ToTable("salon");

            entity.Property(e => e.salonid).HasColumnName("salonid");
            entity.Property(e => e.adres)
                .HasMaxLength(255)
                .HasColumnName("adres");
            entity.Property(e => e.salonadı)
                .HasMaxLength(100)
                .HasColumnName("salonadı");
            entity.Property(e => e.telefon)
                .HasMaxLength(20)
                .HasColumnName("telefon");
            entity.Property(e => e.Çalışmasaatleri).HasMaxLength(50);
        });

        modelBuilder.Entity<Calisan>(entity =>
        {
            entity.HasKey(e => e.Calisanid).HasName("calisan_pkey");  // "Çalışan" -> "Calisan"

            entity.ToTable("Calisan");  // "Çalışan" -> "Calisan"

            entity.Property(e => e.adsoyad)
                .HasMaxLength(100)
                .HasColumnName("adsoyad");
            entity.Property(e => e.salonid).HasColumnName("salonid");
            entity.Property(e => e.uygunluksaatleri)
                .HasMaxLength(100)
                .HasColumnName("uygunluksaatleri");
            entity.Property(e => e.uzmanlıkalanı)
                .HasMaxLength(255)
                .HasColumnName("uzmanlıkalanı");

            entity.HasOne(d => d.Salon).WithMany(p => p.Calisan)
                .HasForeignKey(d => d.salonid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("calisan_salonid_fkey");  // "Çalışan" -> "Calisan"
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
