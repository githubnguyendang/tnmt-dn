using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class DLNguonThaiSongDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrongRungDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongRungDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrongLuaDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongLuaDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrongCayDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongCayDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrauBoDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrauBoDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiThuySanDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiThuySanDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiSinhHoatDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiSinhHoatDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiLonDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiLonDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiGiaCamDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiGiaCamDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiDiemDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiDiemDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocNhanDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocNhanDB");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongRungDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongRungDB",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongLuaDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongLuaDB",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongCayDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongCayDB",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrauBoDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrauBoDB",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiThuySanDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiThuySanDB",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiSinhHoatDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiSinhHoatDB",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiLonDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiLonDB",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiGiaCamDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiGiaCamDB",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiDiemDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiDiemDB",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocNhanDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocNhanDB",
                column: "IdPhanDoanSong",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrongRungDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongRungDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrongLuaDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongLuaDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrongCayDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongCayDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrauBoDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrauBoDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiThuySanDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiThuySanDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiSinhHoatDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiSinhHoatDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiLonDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiLonDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiGiaCamDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiGiaCamDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiDiemDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiDiemDB");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocNhanDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocNhanDB");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongRungDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongRungDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongLuaDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongLuaDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongCayDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongCayDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrauBoDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrauBoDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiThuySanDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiThuySanDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiSinhHoatDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiSinhHoatDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiLonDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiLonDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiGiaCamDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiGiaCamDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiDiemDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiDiemDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocNhanDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocNhanDB",
                column: "IdPhanDoanSong");
        }
    }
}
