using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class DuLieuNguonNuocThaiThuySan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiThuySan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    DienTichThuySan = table.Column<int>(type: "int", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtThuySanBOD = table.Column<double>(type: "float", nullable: true),
                    CtThuySanCOD = table.Column<double>(type: "float", nullable: true),
                    CtThuySanAmoni = table.Column<double>(type: "float", nullable: true),
                    CtThuySanTongN = table.Column<double>(type: "float", nullable: true),
                    CtThuySanTongP = table.Column<double>(type: "float", nullable: true),
                    CtThuySanTSS = table.Column<double>(type: "float", nullable: true),
                    CtThuySanColiform = table.Column<double>(type: "float", nullable: true),
                    LtThuySanBOD = table.Column<double>(type: "float", nullable: true),
                    LtThuySanCOD = table.Column<double>(type: "float", nullable: true),
                    LtThuySanAmoni = table.Column<double>(type: "float", nullable: true),
                    LtThuySanTongN = table.Column<double>(type: "float", nullable: true),
                    LtThuySanTongP = table.Column<double>(type: "float", nullable: true),
                    LtThuySanTSS = table.Column<double>(type: "float", nullable: true),
                    LtThuySanColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiThuySan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiThuySan_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiThuySan_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiThuySan",
                column: "IdPhanDoanSong",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiThuySan");
        }
    }
}
