using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class KKTNNCLN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BOD5Max",
                table: "KKTNN_NuocMat_ChatLuong");

            migrationBuilder.DropColumn(
                name: "BOD5Min",
                table: "KKTNN_NuocMat_ChatLuong");

            migrationBuilder.DropColumn(
                name: "CODMax",
                table: "KKTNN_NuocMat_ChatLuong");

            migrationBuilder.DropColumn(
                name: "CODMin",
                table: "KKTNN_NuocMat_ChatLuong");

            migrationBuilder.DropColumn(
                name: "DOMax",
                table: "KKTNN_NuocMat_ChatLuong");

            migrationBuilder.DropColumn(
                name: "DOMin",
                table: "KKTNN_NuocMat_ChatLuong");

            migrationBuilder.DropColumn(
                name: "GiaTriWQI",
                table: "KKTNN_NuocMat_ChatLuong");

            migrationBuilder.DropColumn(
                name: "IdHuyen",
                table: "KKTNN_NuocMat_ChatLuong");

            migrationBuilder.DropColumn(
                name: "IdLuuVucSong",
                table: "KKTNN_NuocMat_ChatLuong");

            migrationBuilder.DropColumn(
                name: "IdTinh",
                table: "KKTNN_NuocMat_ChatLuong");

            migrationBuilder.DropColumn(
                name: "IdXa",
                table: "KKTNN_NuocMat_ChatLuong");

            migrationBuilder.RenameColumn(
                name: "ViTriQuanTrac",
                table: "KKTNN_NuocMat_ChatLuong",
                newName: "Xa");

            migrationBuilder.RenameColumn(
                name: "GhiChu",
                table: "KKTNN_NuocMat_ChatLuong",
                newName: "ThuocLVS");

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGian",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Huyen",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguonNuoc",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Huyen",
                table: "KKTNN_NuocMat_ChatLuong");

            migrationBuilder.DropColumn(
                name: "NguonNuoc",
                table: "KKTNN_NuocMat_ChatLuong");

            migrationBuilder.RenameColumn(
                name: "Xa",
                table: "KKTNN_NuocMat_ChatLuong",
                newName: "ViTriQuanTrac");

            migrationBuilder.RenameColumn(
                name: "ThuocLVS",
                table: "KKTNN_NuocMat_ChatLuong",
                newName: "GhiChu");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGian",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BOD5Max",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BOD5Min",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CODMax",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CODMin",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DOMax",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DOMin",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GiaTriWQI",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdHuyen",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdLuuVucSong",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTinh",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdXa",
                table: "KKTNN_NuocMat_ChatLuong",
                type: "int",
                nullable: true);
        }
    }
}
