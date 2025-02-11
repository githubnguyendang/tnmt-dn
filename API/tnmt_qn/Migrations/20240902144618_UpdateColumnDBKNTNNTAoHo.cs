using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnDBKNTNNTAoHo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MtnAmoni",
                table: "DuBaoKhaNangTiepNhanNuocHo",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MtnBOD",
                table: "DuBaoKhaNangTiepNhanNuocHo",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MtnCOD",
                table: "DuBaoKhaNangTiepNhanNuocHo",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MtnColiform",
                table: "DuBaoKhaNangTiepNhanNuocHo",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MtnTSS",
                table: "DuBaoKhaNangTiepNhanNuocHo",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MtnTongN",
                table: "DuBaoKhaNangTiepNhanNuocHo",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MtnTongP",
                table: "DuBaoKhaNangTiepNhanNuocHo",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MtnAmoni",
                table: "DuBaoKhaNangTiepNhanNuocHo");

            migrationBuilder.DropColumn(
                name: "MtnBOD",
                table: "DuBaoKhaNangTiepNhanNuocHo");

            migrationBuilder.DropColumn(
                name: "MtnCOD",
                table: "DuBaoKhaNangTiepNhanNuocHo");

            migrationBuilder.DropColumn(
                name: "MtnColiform",
                table: "DuBaoKhaNangTiepNhanNuocHo");

            migrationBuilder.DropColumn(
                name: "MtnTSS",
                table: "DuBaoKhaNangTiepNhanNuocHo");

            migrationBuilder.DropColumn(
                name: "MtnTongN",
                table: "DuBaoKhaNangTiepNhanNuocHo");

            migrationBuilder.DropColumn(
                name: "MtnTongP",
                table: "DuBaoKhaNangTiepNhanNuocHo");
        }
    }
}
