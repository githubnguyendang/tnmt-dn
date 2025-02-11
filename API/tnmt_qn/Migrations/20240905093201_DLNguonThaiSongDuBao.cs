using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class DLNguonThaiSongDuBao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocNhanDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    IdMucPL = table.Column<int>(type: "int", nullable: false),
                    LuuLuongDongChayDB = table.Column<double>(type: "float", nullable: true),
                    CnnBODDB = table.Column<double>(type: "float", nullable: true),
                    CnnCODDB = table.Column<double>(type: "float", nullable: true),
                    CnnAmoniDB = table.Column<double>(type: "float", nullable: true),
                    CnnTongNDB = table.Column<double>(type: "float", nullable: true),
                    CnnTongPDB = table.Column<double>(type: "float", nullable: true),
                    CnnTSSDB = table.Column<double>(type: "float", nullable: true),
                    CnnColiformDB = table.Column<double>(type: "float", nullable: true),
                    LnnBODDB = table.Column<double>(type: "float", nullable: true),
                    LnnCODDB = table.Column<double>(type: "float", nullable: true),
                    LnnAmoniDB = table.Column<double>(type: "float", nullable: true),
                    LnnTongNDB = table.Column<double>(type: "float", nullable: true),
                    LnnTongPDB = table.Column<double>(type: "float", nullable: true),
                    LnnTSSDB = table.Column<double>(type: "float", nullable: true),
                    LnnColiformDB = table.Column<double>(type: "float", nullable: true),
                    LtdBODDB = table.Column<double>(type: "float", nullable: true),
                    LtdCODDB = table.Column<double>(type: "float", nullable: true),
                    LtdAmoniDB = table.Column<double>(type: "float", nullable: true),
                    LtdTongNDB = table.Column<double>(type: "float", nullable: true),
                    LtdTongPDB = table.Column<double>(type: "float", nullable: true),
                    LtdTSSDB = table.Column<double>(type: "float", nullable: true),
                    LtdColiformDB = table.Column<double>(type: "float", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocNhanDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocNhanDB_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocNhanDB_ThongSoCLNDuBao_IdMucPL",
                        column: x => x.IdMucPL,
                        principalTable: "ThongSoCLNDuBao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiDiemDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    LuuLuongXaThaiDB = table.Column<double>(type: "float", nullable: true),
                    CtdiemBODDB = table.Column<double>(type: "float", nullable: true),
                    CtdiemCODDB = table.Column<double>(type: "float", nullable: true),
                    CtdiemAmoniDB = table.Column<double>(type: "float", nullable: true),
                    CtdiemTongNDB = table.Column<double>(type: "float", nullable: true),
                    CtdiemTongPDB = table.Column<double>(type: "float", nullable: true),
                    CtdiemTSSDB = table.Column<double>(type: "float", nullable: true),
                    CtdiemColiformDB = table.Column<double>(type: "float", nullable: true),
                    LtdiemBODDB = table.Column<double>(type: "float", nullable: true),
                    LtdiemCODDB = table.Column<double>(type: "float", nullable: true),
                    LtdiemAmoniDB = table.Column<double>(type: "float", nullable: true),
                    LtdiemTongNDB = table.Column<double>(type: "float", nullable: true),
                    LtdiemTongPDB = table.Column<double>(type: "float", nullable: true),
                    LtdiemTSSDB = table.Column<double>(type: "float", nullable: true),
                    LtdiemColiformDB = table.Column<double>(type: "float", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiDiemDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiDiemDB_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiGiaCamDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    SoGiaCamDB = table.Column<int>(type: "int", nullable: true),
                    HeSoSuyGiamDB = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamBODDB = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamCODDB = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamAmoniDB = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamTongNDB = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamTongPDB = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamTSSDB = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamColiformDB = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamBODDB = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamCODDB = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamAmoniDB = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamTongNDB = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamTongPDB = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamTSSDB = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamColiformDB = table.Column<double>(type: "float", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiGiaCamDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiGiaCamDB_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiLonDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    SoLonDB = table.Column<int>(type: "int", nullable: true),
                    SoDeDB = table.Column<int>(type: "int", nullable: true),
                    SoGiaSucKhacDB = table.Column<int>(type: "int", nullable: true),
                    HeSoSuyGiamDB = table.Column<double>(type: "float", nullable: true),
                    CtLonBODDB = table.Column<double>(type: "float", nullable: true),
                    CtLonCODDB = table.Column<double>(type: "float", nullable: true),
                    CtLonAmoniDB = table.Column<double>(type: "float", nullable: true),
                    CtLonTongNDB = table.Column<double>(type: "float", nullable: true),
                    CtLonTongPDB = table.Column<double>(type: "float", nullable: true),
                    CtLonTSSDB = table.Column<double>(type: "float", nullable: true),
                    CtLonColiformDB = table.Column<double>(type: "float", nullable: true),
                    LtLonBODDB = table.Column<double>(type: "float", nullable: true),
                    LtLonCODDB = table.Column<double>(type: "float", nullable: true),
                    LtLonAmoniDB = table.Column<double>(type: "float", nullable: true),
                    LtLonTongNDB = table.Column<double>(type: "float", nullable: true),
                    LtLonTongPDB = table.Column<double>(type: "float", nullable: true),
                    LtLonTSSDB = table.Column<double>(type: "float", nullable: true),
                    LtLonColiformDB = table.Column<double>(type: "float", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiLonDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiLonDB_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiSinhHoatDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    SoDanDB = table.Column<int>(type: "int", nullable: true),
                    HeSoSuyGiamDB = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatBODDB = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatCODDB = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatAmoniDB = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatTongNDB = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatTongPDB = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatTSSDB = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatColiformDB = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatBODDB = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatCODDB = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatAmoniDB = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatTongNDB = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatTongPDB = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatTSSDB = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatColiformDB = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiSinhHoatDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiSinhHoatDB_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiThuySanDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    DienTichThuySanDB = table.Column<double>(type: "float", nullable: true),
                    HeSoSuyGiamDB = table.Column<double>(type: "float", nullable: true),
                    CtThuySanBODDB = table.Column<double>(type: "float", nullable: true),
                    CtThuySanCODDB = table.Column<double>(type: "float", nullable: true),
                    CtThuySanAmoniDB = table.Column<double>(type: "float", nullable: true),
                    CtThuySanTongNDB = table.Column<double>(type: "float", nullable: true),
                    CtThuySanTongPDB = table.Column<double>(type: "float", nullable: true),
                    CtThuySanTSSDB = table.Column<double>(type: "float", nullable: true),
                    CtThuySanColiformDB = table.Column<double>(type: "float", nullable: true),
                    LtThuySanBODDB = table.Column<double>(type: "float", nullable: true),
                    LtThuySanCODDB = table.Column<double>(type: "float", nullable: true),
                    LtThuySanAmoniDB = table.Column<double>(type: "float", nullable: true),
                    LtThuySanTongNDB = table.Column<double>(type: "float", nullable: true),
                    LtThuySanTongPDB = table.Column<double>(type: "float", nullable: true),
                    LtThuySanTSSDB = table.Column<double>(type: "float", nullable: true),
                    LtThuySanColiformDB = table.Column<double>(type: "float", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiThuySanDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiThuySanDB_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiTrauBoDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    SoTrauDB = table.Column<int>(type: "int", nullable: true),
                    SoBoDB = table.Column<int>(type: "int", nullable: true),
                    HeSoSuyGiamDB = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoBODDB = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoCODDB = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoAmoniDB = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoTongNDB = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoTongPDB = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoTSSDB = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoColiformDB = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoBODDB = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoCODDB = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoAmoniDB = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoTongNDB = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoTongPDB = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoTSSDB = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoColiformDB = table.Column<double>(type: "float", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiTrauBoDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiTrauBoDB_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiTrongCayDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    DienTichTrongCayDB = table.Column<double>(type: "float", nullable: true),
                    HeSoSuyGiamDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayBODDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayCODDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayAmoniDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayTongNDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayTongPDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayTSSDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayColiformDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayBODDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayCODDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayAmoniDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayTongNDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayTongPDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayTSSDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayColiformDB = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiTrongCayDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiTrongCayDB_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiTrongLuaDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    DienTichTrongLuaDB = table.Column<double>(type: "float", nullable: true),
                    HeSoSuyGiamDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaBODDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaCODDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaAmoniDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaTongNDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaTongPDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaTSSDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaColiformDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaBODDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaCODDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaAmoniDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaTongNDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaTongPDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaTSSDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaColiformDB = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiTrongLuaDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiTrongLuaDB_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiTrongRungDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    DienTichTrongRungDB = table.Column<double>(type: "float", nullable: true),
                    HeSoSuyGiamDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungBODDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungCODDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungAmoniDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungTongNDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungTongPDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungTSSDB = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungColiformDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungBODDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungCODDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungAmoniDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungTongNDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungTongPDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungTSSDB = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungColiformDB = table.Column<double>(type: "float", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiTrongRungDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiTrongRungDB_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocNhanDB_IdMucPL",
                table: "DuLieuNguonNuocNhanDB",
                column: "IdMucPL");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocNhanDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocNhanDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiDiemDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiDiemDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiGiaCamDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiGiaCamDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiLonDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiLonDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiSinhHoatDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiSinhHoatDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiThuySanDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiThuySanDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrauBoDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrauBoDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongCayDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongCayDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongLuaDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongLuaDB",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongRungDB_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongRungDB",
                column: "IdPhanDoanSong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocNhanDB");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiDiemDB");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiGiaCamDB");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiLonDB");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiSinhHoatDB");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiThuySanDB");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiTrauBoDB");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiTrongCayDB");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiTrongLuaDB");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiTrongRungDB");
        }
    }
}
