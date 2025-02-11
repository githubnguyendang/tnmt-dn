using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class TaiLuongNguonThaiSongDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaiLuongNuocThaiSongDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    DuLieuNguonNuocNhanDBId = table.Column<int>(type: "int", nullable: true),
                    DuLieuNguonNuocThaiDiemDBId = table.Column<int>(type: "int", nullable: true),
                    DuLieuNguonNuocThaiSinhHoatDBId = table.Column<int>(type: "int", nullable: true),
                    DuLieuNguonNuocThaiGiaCamDBId = table.Column<int>(type: "int", nullable: true),
                    DuLieuNguonNuocThaiLonDBId = table.Column<int>(type: "int", nullable: true),
                    DuLieuNguonNuocThaiTrauBoDBId = table.Column<int>(type: "int", nullable: true),
                    DuLieuNguonNuocThaiTrongCayDBId = table.Column<int>(type: "int", nullable: true),
                    DuLieuNguonNuocThaiTrongLuaDBId = table.Column<int>(type: "int", nullable: true),
                    DuLieuNguonNuocThaiTrongRungDBId = table.Column<int>(type: "int", nullable: true),
                    DuLieuNguonNuocThaiThuySanDBId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiLuongNuocThaiSongDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiLuongNuocThaiSongDB_DuLieuNguonNuocNhanDB_DuLieuNguonNuocNhanDBId",
                        column: x => x.DuLieuNguonNuocNhanDBId,
                        principalTable: "DuLieuNguonNuocNhanDB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiDiemDB_DuLieuNguonNuocThaiDiemDBId",
                        column: x => x.DuLieuNguonNuocThaiDiemDBId,
                        principalTable: "DuLieuNguonNuocThaiDiemDB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiGiaCamDB_DuLieuNguonNuocThaiGiaCamDBId",
                        column: x => x.DuLieuNguonNuocThaiGiaCamDBId,
                        principalTable: "DuLieuNguonNuocThaiGiaCamDB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiLonDB_DuLieuNguonNuocThaiLonDBId",
                        column: x => x.DuLieuNguonNuocThaiLonDBId,
                        principalTable: "DuLieuNguonNuocThaiLonDB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiSinhHoatDB_DuLieuNguonNuocThaiSinhHoatDBId",
                        column: x => x.DuLieuNguonNuocThaiSinhHoatDBId,
                        principalTable: "DuLieuNguonNuocThaiSinhHoatDB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiThuySanDB_DuLieuNguonNuocThaiThuySanDBId",
                        column: x => x.DuLieuNguonNuocThaiThuySanDBId,
                        principalTable: "DuLieuNguonNuocThaiThuySanDB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiTrauBoDB_DuLieuNguonNuocThaiTrauBoDBId",
                        column: x => x.DuLieuNguonNuocThaiTrauBoDBId,
                        principalTable: "DuLieuNguonNuocThaiTrauBoDB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiTrongCayDB_DuLieuNguonNuocThaiTrongCayDBId",
                        column: x => x.DuLieuNguonNuocThaiTrongCayDBId,
                        principalTable: "DuLieuNguonNuocThaiTrongCayDB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiTrongLuaDB_DuLieuNguonNuocThaiTrongLuaDBId",
                        column: x => x.DuLieuNguonNuocThaiTrongLuaDBId,
                        principalTable: "DuLieuNguonNuocThaiTrongLuaDB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiTrongRungDB_DuLieuNguonNuocThaiTrongRungDBId",
                        column: x => x.DuLieuNguonNuocThaiTrongRungDBId,
                        principalTable: "DuLieuNguonNuocThaiTrongRungDB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaiLuongNuocThaiSongDB_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaiLuongNuocThaiSongDB_DuLieuNguonNuocNhanDBId",
                table: "TaiLuongNuocThaiSongDB",
                column: "DuLieuNguonNuocNhanDBId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiDiemDBId",
                table: "TaiLuongNuocThaiSongDB",
                column: "DuLieuNguonNuocThaiDiemDBId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiGiaCamDBId",
                table: "TaiLuongNuocThaiSongDB",
                column: "DuLieuNguonNuocThaiGiaCamDBId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiLonDBId",
                table: "TaiLuongNuocThaiSongDB",
                column: "DuLieuNguonNuocThaiLonDBId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiSinhHoatDBId",
                table: "TaiLuongNuocThaiSongDB",
                column: "DuLieuNguonNuocThaiSinhHoatDBId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiThuySanDBId",
                table: "TaiLuongNuocThaiSongDB",
                column: "DuLieuNguonNuocThaiThuySanDBId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiTrauBoDBId",
                table: "TaiLuongNuocThaiSongDB",
                column: "DuLieuNguonNuocThaiTrauBoDBId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiTrongCayDBId",
                table: "TaiLuongNuocThaiSongDB",
                column: "DuLieuNguonNuocThaiTrongCayDBId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiTrongLuaDBId",
                table: "TaiLuongNuocThaiSongDB",
                column: "DuLieuNguonNuocThaiTrongLuaDBId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLuongNuocThaiSongDB_DuLieuNguonNuocThaiTrongRungDBId",
                table: "TaiLuongNuocThaiSongDB",
                column: "DuLieuNguonNuocThaiTrongRungDBId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLuongNuocThaiSongDB_IdPhanDoanSong",
                table: "TaiLuongNuocThaiSongDB",
                column: "IdPhanDoanSong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaiLuongNuocThaiSongDB");
        }
    }
}
