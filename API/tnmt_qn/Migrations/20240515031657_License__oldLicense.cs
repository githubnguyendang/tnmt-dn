using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class License__oldLicense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GP_ThongTin_IdCon",
                table: "GP_ThongTin",
                column: "IdCon");

            migrationBuilder.AddForeignKey(
                name: "FK_GP_ThongTin_GP_ThongTin_IdCon",
                table: "GP_ThongTin",
                column: "IdCon",
                principalTable: "GP_ThongTin",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GP_ThongTin_GP_ThongTin_IdCon",
                table: "GP_ThongTin");

            migrationBuilder.DropIndex(
                name: "IX_GP_ThongTin_IdCon",
                table: "GP_ThongTin");
        }
    }
}
