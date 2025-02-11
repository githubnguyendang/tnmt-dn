using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class VHH_HC_DLHC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MNC",
                table: "VHHC_HoChua_ThongSoKT");

            migrationBuilder.DropColumn(
                name: "MNDBT",
                table: "VHHC_HoChua_ThongSoKT");

            migrationBuilder.DropColumn(
                name: "QDamBao",
                table: "VHHC_HoChua_ThongSoKT");

            migrationBuilder.DropColumn(
                name: "QMax",
                table: "VHHC_HoChua_ThongSoKT");

            migrationBuilder.DropColumn(
                name: "QMin",
                table: "VHHC_HoChua_ThongSoKT");

            migrationBuilder.DropColumn(
                name: "TenHoChua",
                table: "VHHC_HoChua_ThongSoKT");

            migrationBuilder.DropColumn(
                name: "WChet",
                table: "VHHC_HoChua_ThongSoKT");

            migrationBuilder.DropColumn(
                name: "WHuuIch",
                table: "VHHC_HoChua_ThongSoKT");

            migrationBuilder.DropColumn(
                name: "WToanBo",
                table: "VHHC_HoChua_ThongSoKT");

            migrationBuilder.AddColumn<int>(
                name: "IdHo",
                table: "VHHC_HoChua_ThongSoKT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VHHC_HoChua_ThongSoKT_IdHo",
                table: "VHHC_HoChua_ThongSoKT",
                column: "IdHo");

            migrationBuilder.AddForeignKey(
                name: "FK_VHHC_HoChua_ThongSoKT_CT_ThongTin_IdHo",
                table: "VHHC_HoChua_ThongSoKT",
                column: "IdHo",
                principalTable: "CT_ThongTin",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VHHC_HoChua_ThongSoKT_CT_ThongTin_IdHo",
                table: "VHHC_HoChua_ThongSoKT");

            migrationBuilder.DropIndex(
                name: "IX_VHHC_HoChua_ThongSoKT_IdHo",
                table: "VHHC_HoChua_ThongSoKT");

            migrationBuilder.DropColumn(
                name: "IdHo",
                table: "VHHC_HoChua_ThongSoKT");

            migrationBuilder.AddColumn<double>(
                name: "MNC",
                table: "VHHC_HoChua_ThongSoKT",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MNDBT",
                table: "VHHC_HoChua_ThongSoKT",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "QDamBao",
                table: "VHHC_HoChua_ThongSoKT",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "QMax",
                table: "VHHC_HoChua_ThongSoKT",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "QMin",
                table: "VHHC_HoChua_ThongSoKT",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenHoChua",
                table: "VHHC_HoChua_ThongSoKT",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WChet",
                table: "VHHC_HoChua_ThongSoKT",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WHuuIch",
                table: "VHHC_HoChua_ThongSoKT",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WToanBo",
                table: "VHHC_HoChua_ThongSoKT",
                type: "float",
                nullable: true);
        }
    }
}
