using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class Thongtinao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinAoHo_ThongSoCLNAo_IdCLNQC",
                table: "ThongTinAoHo");

            migrationBuilder.DropIndex(
                name: "IX_ThongTinAoHo_IdCLNQC",
                table: "ThongTinAoHo");

            migrationBuilder.DropColumn(
                name: "IdCLNQC",
                table: "ThongTinAoHo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCLNQC",
                table: "ThongTinAoHo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinAoHo_IdCLNQC",
                table: "ThongTinAoHo",
                column: "IdCLNQC");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinAoHo_ThongSoCLNAo_IdCLNQC",
                table: "ThongTinAoHo",
                column: "IdCLNQC",
                principalTable: "ThongSoCLNAo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
