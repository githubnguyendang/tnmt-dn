using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class KhaNangTiepNhanNuocHo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "CT_ThongSo");

            migrationBuilder.DropColumn(
                name: "TaiKhoanSua",
                table: "CT_ThongSo");

            migrationBuilder.DropColumn(
                name: "TaiKhoanTao",
                table: "CT_ThongSo");

            migrationBuilder.DropColumn(
                name: "ThoiGianSua",
                table: "CT_ThongSo");

            migrationBuilder.DropColumn(
                name: "ThoiGianTao",
                table: "CT_ThongSo");

            migrationBuilder.CreateTable(
                name: "KhaNangTiepNhanNuocHo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flv = table.Column<double>(type: "float", nullable: true),
                    Ftuoi = table.Column<double>(type: "float", nullable: true),
                    Wtru = table.Column<double>(type: "float", nullable: true),
                    TranXaLu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CnnBOD = table.Column<double>(type: "float", nullable: true),
                    CnnCOD = table.Column<double>(type: "float", nullable: true),
                    CnnAmoni = table.Column<double>(type: "float", nullable: true),
                    CnnTongN = table.Column<double>(type: "float", nullable: true),
                    CnnTongP = table.Column<double>(type: "float", nullable: true),
                    CnnTSS = table.Column<double>(type: "float", nullable: true),
                    CnnColiform = table.Column<double>(type: "float", nullable: true),
                    CqcBOD = table.Column<double>(type: "float", nullable: true),
                    CqcCOD = table.Column<double>(type: "float", nullable: true),
                    CqcAmoni = table.Column<double>(type: "float", nullable: true),
                    CqcTongN = table.Column<double>(type: "float", nullable: true),
                    CqcTongP = table.Column<double>(type: "float", nullable: true),
                    CqcTSS = table.Column<double>(type: "float", nullable: true),
                    CqcColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhaNangTiepNhanNuocHo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhaNangTiepNhanNuocHo");

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "CT_ThongSo",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaiKhoanSua",
                table: "CT_ThongSo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaiKhoanTao",
                table: "CT_ThongSo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianSua",
                table: "CT_ThongSo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianTao",
                table: "CT_ThongSo",
                type: "datetime2",
                nullable: true);
        }
    }
}
