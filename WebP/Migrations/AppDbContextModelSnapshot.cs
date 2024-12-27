﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebP.Data;

#nullable disable

namespace WebP.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pg_catalog", "adminpack");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebP.Models.Calisan", b =>
                {
                    b.Property<int>("Calisanid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Calisanid"));

                    b.Property<string>("adsoyad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("adsoyad");

                    b.Property<int>("salonid")
                        .HasColumnType("integer")
                        .HasColumnName("salonid");

                    b.Property<string>("uygunluksaatleri")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("uygunluksaatleri");

                    b.Property<string>("uzmanlıkalanı")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("uzmanlıkalanı");

                    b.HasKey("Calisanid")
                        .HasName("calisan_pkey");

                    b.HasIndex("salonid");

                    b.ToTable("Calisan", (string)null);
                });

            modelBuilder.Entity("WebP.Models.Hizmet", b =>
                {
                    b.Property<int>("Hizmetid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("hizmetid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Hizmetid"));

                    b.Property<string>("Hizmetadı")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("hizmetadı");

                    b.Property<int>("Salonid")
                        .HasColumnType("integer")
                        .HasColumnName("salonid");

                    b.Property<int>("Süre")
                        .HasColumnType("integer")
                        .HasColumnName("süre");

                    b.Property<decimal>("Ücret")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("Hizmetid")
                        .HasName("hizmet_pkey");

                    b.HasIndex("Salonid");

                    b.ToTable("hizmet", (string)null);
                });

            modelBuilder.Entity("WebP.Models.Kullanıcı", b =>
                {
                    b.Property<int>("KullanıcıId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("KullanıcıId"));

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("KullanıcıId");

                    b.ToTable("Kullanıcı");
                });

            modelBuilder.Entity("WebP.Models.Randevu", b =>
                {
                    b.Property<int>("Randevuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("randevuid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Randevuid"));

                    b.Property<int>("Calisanid")
                        .HasColumnType("integer");

                    b.Property<string>("Durum")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("durum");

                    b.Property<int>("Hizmetid")
                        .HasColumnType("integer")
                        .HasColumnName("hizmetid");

                    b.Property<string>("Kullanıcıadı")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("kullanıcıadı");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("tarih");

                    b.HasKey("Randevuid")
                        .HasName("randevu_pkey");

                    b.HasIndex("Calisanid");

                    b.HasIndex("Hizmetid");

                    b.ToTable("randevu", (string)null);
                });

            modelBuilder.Entity("WebP.Models.Salon", b =>
                {
                    b.Property<int>("salonid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("salonid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("salonid"));

                    b.Property<string>("adres")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("adres");

                    b.Property<string>("salonadı")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("salonadı");

                    b.Property<string>("telefon")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("telefon");

                    b.Property<string>("çalışmasaatleri")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("salonid")
                        .HasName("salon_pkey");

                    b.ToTable("salon", (string)null);
                });

            modelBuilder.Entity("WebP.Models.Calisan", b =>
                {
                    b.HasOne("WebP.Models.Salon", "Salon")
                        .WithMany("Calisan")
                        .HasForeignKey("salonid")
                        .IsRequired()
                        .HasConstraintName("calisan_salonid_fkey");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("WebP.Models.Hizmet", b =>
                {
                    b.HasOne("WebP.Models.Salon", "Salon")
                        .WithMany("Hizmet")
                        .HasForeignKey("Salonid")
                        .IsRequired()
                        .HasConstraintName("hizmet_salonid_fkey");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("WebP.Models.Randevu", b =>
                {
                    b.HasOne("WebP.Models.Calisan", "Calisan")
                        .WithMany("Randevu")
                        .HasForeignKey("Calisanid")
                        .IsRequired()
                        .HasConstraintName("randevu_calisanid_fkey");

                    b.HasOne("WebP.Models.Hizmet", "Hizmet")
                        .WithMany("Randevu")
                        .HasForeignKey("Hizmetid")
                        .IsRequired()
                        .HasConstraintName("randevu_hizmetid_fkey");

                    b.Navigation("Calisan");

                    b.Navigation("Hizmet");
                });

            modelBuilder.Entity("WebP.Models.Calisan", b =>
                {
                    b.Navigation("Randevu");
                });

            modelBuilder.Entity("WebP.Models.Hizmet", b =>
                {
                    b.Navigation("Randevu");
                });

            modelBuilder.Entity("WebP.Models.Salon", b =>
                {
                    b.Navigation("Calisan");

                    b.Navigation("Hizmet");
                });
#pragma warning restore 612, 618
        }
    }
}
