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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calisan");

            migrationBuilder.DropTable(
                name: "Salon");
        }
    }
}
