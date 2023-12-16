using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zamiux.Web.Migrations
{
    /// <inheritdoc />
    public partial class updateModelDownloadCounter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Counter",
                table: "resumeDls",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Counter",
                table: "resumeDls");
        }
    }
}
