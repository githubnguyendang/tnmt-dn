using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class UpdateThanhTraKiemTra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThanhTraKiemTra_CT_ThongTin_IdCT",
                table: "ThanhTraKiemTra");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhTraKiemTra_ToChuc_CaNhan_IdTCCN",
                table: "ThanhTraKiemTra");

            migrationBuilder.AlterColumn<int>(
                name: "IdTCCN",
                table: "ThanhTraKiemTra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdCT",
                table: "ThanhTraKiemTra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhTraKiemTra_CT_ThongTin_IdCT",
                table: "ThanhTraKiemTra",
                column: "IdCT",
                principalTable: "CT_ThongTin",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhTraKiemTra_ToChuc_CaNhan_IdTCCN",
                table: "ThanhTraKiemTra",
                column: "IdTCCN",
                principalTable: "ToChuc_CaNhan",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThanhTraKiemTra_CT_ThongTin_IdCT",
                table: "ThanhTraKiemTra");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhTraKiemTra_ToChuc_CaNhan_IdTCCN",
                table: "ThanhTraKiemTra");

            migrationBuilder.AlterColumn<int>(
                name: "IdTCCN",
                table: "ThanhTraKiemTra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCT",
                table: "ThanhTraKiemTra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhTraKiemTra_CT_ThongTin_IdCT",
                table: "ThanhTraKiemTra",
                column: "IdCT",
                principalTable: "CT_ThongTin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhTraKiemTra_ToChuc_CaNhan_IdTCCN",
                table: "ThanhTraKiemTra",
                column: "IdTCCN",
                principalTable: "ToChuc_CaNhan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
