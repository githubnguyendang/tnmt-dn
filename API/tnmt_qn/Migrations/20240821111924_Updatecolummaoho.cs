using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class Updatecolummaoho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MtnTongP",
                table: "ThongTinAoHo",
                newName: "Wtru2");

            migrationBuilder.RenameColumn(
                name: "MtnTongN",
                table: "ThongTinAoHo",
                newName: "Wtru1");

            migrationBuilder.RenameColumn(
                name: "MtnTSS",
                table: "ThongTinAoHo",
                newName: "VH");

            migrationBuilder.RenameColumn(
                name: "MtnColiform",
                table: "ThongTinAoHo",
                newName: "Ftuoi2");

            migrationBuilder.RenameColumn(
                name: "MtnCOD",
                table: "ThongTinAoHo",
                newName: "Ftuoi1");

            migrationBuilder.RenameColumn(
                name: "MtnBOD",
                table: "ThongTinAoHo",
                newName: "FS");

            migrationBuilder.RenameColumn(
                name: "MtnAmoni",
                table: "ThongTinAoHo",
                newName: "CghTongP");

            migrationBuilder.AddColumn<double>(
                name: "CghAmoni",
                table: "ThongTinAoHo",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CghBOD",
                table: "ThongTinAoHo",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CghCOD",
                table: "ThongTinAoHo",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CghColiform",
                table: "ThongTinAoHo",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CghTSS",
                table: "ThongTinAoHo",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CghTongN",
                table: "ThongTinAoHo",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TranXaLu",
                table: "ThongTinAoHo",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CghAmoni",
                table: "ThongTinAoHo");

            migrationBuilder.DropColumn(
                name: "CghBOD",
                table: "ThongTinAoHo");

            migrationBuilder.DropColumn(
                name: "CghCOD",
                table: "ThongTinAoHo");

            migrationBuilder.DropColumn(
                name: "CghColiform",
                table: "ThongTinAoHo");

            migrationBuilder.DropColumn(
                name: "CghTSS",
                table: "ThongTinAoHo");

            migrationBuilder.DropColumn(
                name: "CghTongN",
                table: "ThongTinAoHo");

            migrationBuilder.DropColumn(
                name: "TranXaLu",
                table: "ThongTinAoHo");

            migrationBuilder.RenameColumn(
                name: "Wtru2",
                table: "ThongTinAoHo",
                newName: "MtnTongP");

            migrationBuilder.RenameColumn(
                name: "Wtru1",
                table: "ThongTinAoHo",
                newName: "MtnTongN");

            migrationBuilder.RenameColumn(
                name: "VH",
                table: "ThongTinAoHo",
                newName: "MtnTSS");

            migrationBuilder.RenameColumn(
                name: "Ftuoi2",
                table: "ThongTinAoHo",
                newName: "MtnColiform");

            migrationBuilder.RenameColumn(
                name: "Ftuoi1",
                table: "ThongTinAoHo",
                newName: "MtnCOD");

            migrationBuilder.RenameColumn(
                name: "FS",
                table: "ThongTinAoHo",
                newName: "MtnBOD");

            migrationBuilder.RenameColumn(
                name: "CghTongP",
                table: "ThongTinAoHo",
                newName: "MtnAmoni");
        }
    }
}
