using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLuuVucSong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BanDo",
                table: "LuuVucSong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChieuDaiSongChinh",
                table: "LuuVucSong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DienTich",
                table: "LuuVucSong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileKML",
                table: "LuuVucSong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoQuyTrinh",
                table: "LuuVucSong",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BanDo",
                table: "LuuVucSong");

            migrationBuilder.DropColumn(
                name: "ChieuDaiSongChinh",
                table: "LuuVucSong");

            migrationBuilder.DropColumn(
                name: "DienTich",
                table: "LuuVucSong");

            migrationBuilder.DropColumn(
                name: "FileKML",
                table: "LuuVucSong");

            migrationBuilder.DropColumn(
                name: "SoQuyTrinh",
                table: "LuuVucSong");
        }
    }
}
