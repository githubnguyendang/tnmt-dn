using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class DiemQuanTrac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiemQuanTrac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDiemDo = table.Column<int>(type: "int", nullable: false),
                    ToaDoX = table.Column<double>(type: "float", nullable: false),
                    ToaDoY = table.Column<double>(type: "float", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemQuanTrac", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiemQuanTrac");
        }
    }
}
