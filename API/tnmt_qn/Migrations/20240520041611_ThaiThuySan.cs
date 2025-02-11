using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class ThaiThuySan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DienTichThuySan",
                table: "DuLieuNguonNuocThaiThuySan",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DienTichThuySan",
                table: "DuLieuNguonNuocThaiThuySan",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
