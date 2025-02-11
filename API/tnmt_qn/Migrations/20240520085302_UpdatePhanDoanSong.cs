using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhanDoanSong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileKML",
                table: "PhanDoanSong",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileKML",
                table: "PhanDoanSong");
        }
    }
}
