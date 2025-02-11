using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class DuLieuLuuVucLHChua : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuLieuLuuVucLHC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LVSVHH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienTichLV = table.Column<double>(type: "float", nullable: true),
                    ChieuDaiSong = table.Column<double>(type: "float", nullable: true),
                    BanDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDoCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoQT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TepDinhKem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuLuuVucLHC", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuLieuLuuVucLHC");
        }
    }
}
