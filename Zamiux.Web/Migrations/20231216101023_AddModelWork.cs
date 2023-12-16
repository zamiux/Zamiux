using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zamiux.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddModelWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WorkName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WorkExternalUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WorkImgThumb = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WorkImg = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WorkDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Works");
        }
    }
}
