using Microsoft.EntityFrameworkCore.Migrations;

namespace MediatorPattern.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ImageId = table.Column<int>(nullable: false),
                    Size_Width = table.Column<double>(nullable: true),
                    Size_Height = table.Column<double>(nullable: true),
                    Position_X = table.Column<double>(nullable: true),
                    Position_Y = table.Column<double>(nullable: true),
                    Position_Z = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elements");
        }
    }
}
