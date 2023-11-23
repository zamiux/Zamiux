using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zamiux.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddModel_Social : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSocials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSocials", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSocials");
        }
    }
}
