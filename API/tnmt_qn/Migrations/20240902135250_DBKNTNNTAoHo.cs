using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class DBKNTNNTAoHo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThongSoCLNDuBao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOD = table.Column<double>(type: "float", nullable: true),
                    COD = table.Column<double>(type: "float", nullable: true),
                    TSS = table.Column<double>(type: "float", nullable: true),
                    Amoni = table.Column<double>(type: "float", nullable: true),
                    TongP = table.Column<double>(type: "float", nullable: true),
                    TongN = table.Column<double>(type: "float", nullable: true),
                    TongColiform = table.Column<double>(type: "float", nullable: true),
                    MucPLCLNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoCLNDuBao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DuBaoKhaNangTiepNhanNuocHo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHoChua = table.Column<int>(type: "int", nullable: false),
                    IdMucPL = table.Column<int>(type: "int", nullable: false),
                    CnnBOD = table.Column<double>(type: "float", nullable: true),
                    CnnCOD = table.Column<double>(type: "float", nullable: true),
                    CnnAmoni = table.Column<double>(type: "float", nullable: true),
                    CnnTongN = table.Column<double>(type: "float", nullable: true),
                    CnnTongP = table.Column<double>(type: "float", nullable: true),
                    CnnTSS = table.Column<double>(type: "float", nullable: true),
                    CnnColiform = table.Column<double>(type: "float", nullable: true),
                    VH = table.Column<double>(type: "float", nullable: true),
                    FS = table.Column<double>(type: "float", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuBaoKhaNangTiepNhanNuocHo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuBaoKhaNangTiepNhanNuocHo_CT_ThongTin_IdHoChua",
                        column: x => x.IdHoChua,
                        principalTable: "CT_ThongTin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DuBaoKhaNangTiepNhanNuocHo_ThongSoCLNDuBao_IdMucPL",
                        column: x => x.IdMucPL,
                        principalTable: "ThongSoCLNDuBao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuBaoKhaNangTiepNhanNuocHo_IdHoChua",
                table: "DuBaoKhaNangTiepNhanNuocHo",
                column: "IdHoChua");

            migrationBuilder.CreateIndex(
                name: "IX_DuBaoKhaNangTiepNhanNuocHo_IdMucPL",
                table: "DuBaoKhaNangTiepNhanNuocHo",
                column: "IdMucPL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuBaoKhaNangTiepNhanNuocHo");

            migrationBuilder.DropTable(
                name: "ThongSoCLNDuBao");
        }
    }
}
