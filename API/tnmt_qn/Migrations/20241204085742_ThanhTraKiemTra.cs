using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class ThanhTraKiemTra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThanhTraKiemTra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGP = table.Column<int>(type: "int", nullable: true),
                    IdCT = table.Column<int>(type: "int", nullable: false),
                    IdTCCN = table.Column<int>(type: "int", nullable: false),
                    SoVanBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TienPhat = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiLieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhTraKiemTra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanhTraKiemTra_CT_ThongTin_IdCT",
                        column: x => x.IdCT,
                        principalTable: "CT_ThongTin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThanhTraKiemTra_GP_ThongTin_IdGP",
                        column: x => x.IdGP,
                        principalTable: "GP_ThongTin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThanhTraKiemTra_ToChuc_CaNhan_IdTCCN",
                        column: x => x.IdTCCN,
                        principalTable: "ToChuc_CaNhan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThanhTraKiemTra_IdCT",
                table: "ThanhTraKiemTra",
                column: "IdCT");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhTraKiemTra_IdGP",
                table: "ThanhTraKiemTra",
                column: "IdGP");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhTraKiemTra_IdTCCN",
                table: "ThanhTraKiemTra",
                column: "IdTCCN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThanhTraKiemTra");
        }
    }
}
