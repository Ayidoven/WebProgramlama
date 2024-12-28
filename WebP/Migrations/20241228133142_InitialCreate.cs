using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebP.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Salon Tablosu Oluşturuluyor
            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    salonid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salonadı = table.Column<string>(nullable: false),
                    adres = table.Column<string>(nullable: true),
                    Çalışmasaatleri = table.Column<string>(nullable: true),
                    telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.salonid);
                });

            // Calisan Tablosu Oluşturuluyor
            migrationBuilder.CreateTable(
                name: "Calisan",
                columns: table => new
                {
                    Calisanid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salonid = table.Column<int>(nullable: false),
                    adsoyad = table.Column<string>(nullable: false),
                    uzmanlıkalanı = table.Column<string>(nullable: true),
                    uygunluksaatleri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisanlar", x => x.Calisanid);
                    table.ForeignKey(
                        name: "FK_Calisan_Salon_salonid",
                        column: x => x.salonid,
                        principalTable: "Salon",
                        principalColumn: "salonid",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
               name: "Randevu",
               columns: table => new
               {
                   Randevuid = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Calisanid = table.Column<int>(type: "int", nullable: false),
                   Hizmetid = table.Column<int>(type: "int", nullable: false),
                   Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Kullanıcıadı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Durum = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Randevu", x => x.Randevuid);
                   table.ForeignKey(
                       name: "FK_Randevu_Calisan_Calisanid",
                       column: x => x.Calisanid,
                       principalTable: "Calisan",
                       principalColumn: "Calisanid",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_Randevu_Hizmet_Hizmetid",
                       column: x => x.Hizmetid,
                       principalTable: "Hizmet",
                       principalColumn: "Hizmetid",
                       onDelete: ReferentialAction.Cascade);
               });

            migrationBuilder.CreateTable(
                name: "Hizmet",
                columns: table => new
                {
                    Hizmetid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salonid = table.Column<int>(type: "int", nullable: false),
                    Hizmetadı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Süre = table.Column<int>(type: "int", nullable: false),
                    Ücret = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hizmet", x => x.Hizmetid);
                    table.ForeignKey(
                        name: "FK_Hizmet_Salon_Salonid",
                        column: x => x.Salonid,
                        principalTable: "Salon",
                        principalColumn: "Salonid",
                        onDelete: ReferentialAction.Cascade);
                });
        }
           

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calisan");

            migrationBuilder.DropTable(
                name: "Salon");
           
            migrationBuilder.DropTable(
                name: "Randevu");

            migrationBuilder.DropTable(
                name: "Hizmet");
        }
    }
}
