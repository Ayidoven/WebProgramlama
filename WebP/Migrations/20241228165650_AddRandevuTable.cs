using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebP.Migrations
{
    /// <inheritdoc />
    public partial class AddRandevuTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.CreateTable(
             name: "Kullanıcı",
             columns: table => new
             {
                 Kullanıcıid = table.Column<int>(nullable: false)
                      .Annotation("Npgsql:Serial", "true"),
                 // Diğer sütunlar
             },
              constraints: table =>
             {
              table.PrimaryKey("PK_Kullanıcı", x => x.Kullanıcıid);
             });
             
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
