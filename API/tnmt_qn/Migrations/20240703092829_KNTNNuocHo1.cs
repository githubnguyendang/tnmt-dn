using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class KNTNNuocHo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wtru",
                table: "KhaNangTiepNhanNuocHo",
                newName: "Wtru2");

            migrationBuilder.RenameColumn(
                name: "Ftuoi",
                table: "KhaNangTiepNhanNuocHo",
                newName: "Wtru1");

            migrationBuilder.AddColumn<double>(
                name: "Ftuoi1",
                table: "KhaNangTiepNhanNuocHo",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Ftuoi2",
                table: "KhaNangTiepNhanNuocHo",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ftuoi1",
                table: "KhaNangTiepNhanNuocHo");

            migrationBuilder.DropColumn(
                name: "Ftuoi2",
                table: "KhaNangTiepNhanNuocHo");

            migrationBuilder.RenameColumn(
                name: "Wtru2",
                table: "KhaNangTiepNhanNuocHo",
                newName: "Wtru");

            migrationBuilder.RenameColumn(
                name: "Wtru1",
                table: "KhaNangTiepNhanNuocHo",
                newName: "Ftuoi");
        }
    }
}
