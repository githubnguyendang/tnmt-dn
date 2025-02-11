using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class ThongSoDiemQuanTrac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThongSoDiemQuanTrac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDiemQT = table.Column<int>(type: "int", nullable: true),
                    Dot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PH = table.Column<double>(type: "float", nullable: true),
                    DO = table.Column<double>(type: "float", nullable: true),
                    TSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BOD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NO3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NO2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PO4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NH4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coliform = table.Column<double>(type: "float", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoDiemQuanTrac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongSoDiemQuanTrac_DiemQuanTrac_IdDiemQT",
                        column: x => x.IdDiemQT,
                        principalTable: "DiemQuanTrac",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoDiemQuanTrac_IdDiemQT",
                table: "ThongSoDiemQuanTrac",
                column: "IdDiemQT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThongSoDiemQuanTrac");
        }
    }
}
