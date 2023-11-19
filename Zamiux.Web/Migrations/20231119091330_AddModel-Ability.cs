using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zamiux.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddModelAbility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userAbilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AbilityPercent = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    AbilityPriority = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAbilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userIntros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntroTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userIntros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userAbilities");

            migrationBuilder.DropTable(
                name: "userIntros");
        }
    }
}
