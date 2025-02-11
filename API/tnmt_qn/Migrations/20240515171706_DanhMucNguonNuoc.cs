using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class DanhMucNguonNuoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaSong",
                table: "NN_LuuVucSong",
                newName: "MaSong5");

            migrationBuilder.RenameColumn(
                name: "MaSong",
                table: "NN_CNNN_SongSuoi",
                newName: "PhanDoan");

            migrationBuilder.RenameColumn(
                name: "MaSong",
                table: "DanhMucNN_LienTinh",
                newName: "MaSong5");

            migrationBuilder.AddColumn<string>(
                name: "MaSong1",
                table: "NN_LuuVucSong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSong2",
                table: "NN_LuuVucSong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSong3",
                table: "NN_LuuVucSong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSong4",
                table: "NN_LuuVucSong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGianThucHien",
                table: "NN_HanhLangBaoVeNN_SongSuoi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenSong",
                table: "NN_HanhLangBaoVeNN_SongSuoi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSong1",
                table: "NN_CNNN_SongSuoi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSong2",
                table: "NN_CNNN_SongSuoi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSong3",
                table: "NN_CNNN_SongSuoi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSong4",
                table: "NN_CNNN_SongSuoi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSong5",
                table: "NN_CNNN_SongSuoi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSong6",
                table: "NN_CNNN_SongSuoi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSong1",
                table: "DanhMucNN_LienTinh",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSong2",
                table: "DanhMucNN_LienTinh",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSong3",
                table: "DanhMucNN_LienTinh",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSong4",
                table: "DanhMucNN_LienTinh",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaSong1",
                table: "NN_LuuVucSong");

            migrationBuilder.DropColumn(
                name: "MaSong2",
                table: "NN_LuuVucSong");

            migrationBuilder.DropColumn(
                name: "MaSong3",
                table: "NN_LuuVucSong");

            migrationBuilder.DropColumn(
                name: "MaSong4",
                table: "NN_LuuVucSong");

            migrationBuilder.DropColumn(
                name: "TenSong",
                table: "NN_HanhLangBaoVeNN_SongSuoi");

            migrationBuilder.DropColumn(
                name: "MaSong1",
                table: "NN_CNNN_SongSuoi");

            migrationBuilder.DropColumn(
                name: "MaSong2",
                table: "NN_CNNN_SongSuoi");

            migrationBuilder.DropColumn(
                name: "MaSong3",
                table: "NN_CNNN_SongSuoi");

            migrationBuilder.DropColumn(
                name: "MaSong4",
                table: "NN_CNNN_SongSuoi");

            migrationBuilder.DropColumn(
                name: "MaSong5",
                table: "NN_CNNN_SongSuoi");

            migrationBuilder.DropColumn(
                name: "MaSong6",
                table: "NN_CNNN_SongSuoi");

            migrationBuilder.DropColumn(
                name: "MaSong1",
                table: "DanhMucNN_LienTinh");

            migrationBuilder.DropColumn(
                name: "MaSong2",
                table: "DanhMucNN_LienTinh");

            migrationBuilder.DropColumn(
                name: "MaSong3",
                table: "DanhMucNN_LienTinh");

            migrationBuilder.DropColumn(
                name: "MaSong4",
                table: "DanhMucNN_LienTinh");

            migrationBuilder.RenameColumn(
                name: "MaSong5",
                table: "NN_LuuVucSong",
                newName: "MaSong");

            migrationBuilder.RenameColumn(
                name: "PhanDoan",
                table: "NN_CNNN_SongSuoi",
                newName: "MaSong");

            migrationBuilder.RenameColumn(
                name: "MaSong5",
                table: "DanhMucNN_LienTinh",
                newName: "MaSong");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianThucHien",
                table: "NN_HanhLangBaoVeNN_SongSuoi",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
