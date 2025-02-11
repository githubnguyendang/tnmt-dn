using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class KNTNNuocHo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "HeSoFs",
                table: "KhaNangTiepNhanNuocHo",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Vh",
                table: "KhaNangTiepNhanNuocHo",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeSoFs",
                table: "KhaNangTiepNhanNuocHo");

            migrationBuilder.DropColumn(
                name: "Vh",
                table: "KhaNangTiepNhanNuocHo");
        }
    }
}
