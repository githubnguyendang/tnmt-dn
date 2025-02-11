using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class HTTT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HTTT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    Thang = table.Column<int>(type: "int", nullable: true),
                    Ngay = table.Column<int>(type: "int", nullable: true),
                    Gio = table.Column<int>(type: "int", nullable: true),
                    PhanCapLu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STTLu = table.Column<int>(type: "int", nullable: true),
                    NhanDangLu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HinhTheThoiTiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayHinhThanh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TamBaoVungAnhHuongManh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDoBo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ViTriDoBo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapDoBao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongLuongMua = table.Column<double>(type: "float", nullable: true),
                    ChiTietTranLu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTTT", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HTTT");
        }
    }
}
