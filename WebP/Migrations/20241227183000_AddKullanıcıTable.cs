using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebP.Migrations
{
    /// <inheritdoc />
    public partial class AddKullanıcıTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_catalog.adminpack", ",,");

            migrationBuilder.CreateTable(
                name: "Kullanıcı",
                columns: table => new
                {
                    KullanıcıId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdSoyad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Sifre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcı", x => x.KullanıcıId);
                });

           
            migrationBuilder.CreateIndex(
                name: "IX_Calisan_salonid",
                table: "Calisan",
                column: "salonid");

            migrationBuilder.CreateIndex(
                name: "IX_hizmet_salonid",
                table: "hizmet",
                column: "salonid");

            migrationBuilder.CreateIndex(
                name: "IX_randevu_Calisanid",
                table: "randevu",
                column: "Calisanid");

            migrationBuilder.CreateIndex(
                name: "IX_randevu_hizmetid",
                table: "randevu",
                column: "hizmetid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanıcı");

            migrationBuilder.DropTable(
                name: "randevu");

            migrationBuilder.DropTable(
                name: "Calisan");

            migrationBuilder.DropTable(
                name: "hizmet");

            migrationBuilder.DropTable(
                name: "salon");
        }
    }
}
