using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tnmt_qn.Migrations
{
    /// <inheritdoc />
    public partial class inital_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdHuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauMuoiLam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoQuanPhatHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VanBanKyTruoc = table.Column<double>(type: "float", nullable: true),
                    VanBanKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauMuoiLam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoBa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiKyQuanTrac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuongMuaThang1 = table.Column<double>(type: "float", nullable: true),
                    LuongMuaThang2 = table.Column<double>(type: "float", nullable: true),
                    LuongMuaThang3 = table.Column<double>(type: "float", nullable: true),
                    LuongMuaThang4 = table.Column<double>(type: "float", nullable: true),
                    LuongMuaThang5 = table.Column<double>(type: "float", nullable: true),
                    LuongMuaThang6 = table.Column<double>(type: "float", nullable: true),
                    LuongMuaThang7 = table.Column<double>(type: "float", nullable: true),
                    LuongMuaThang8 = table.Column<double>(type: "float", nullable: true),
                    LuongMuaThang9 = table.Column<double>(type: "float", nullable: true),
                    LuongMuaThang10 = table.Column<double>(type: "float", nullable: true),
                    LuongMuaThang11 = table.Column<double>(type: "float", nullable: true),
                    LuongMuaThang12 = table.Column<double>(type: "float", nullable: true),
                    LuongMuaNam = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoBa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoBay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhuVuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VungDieuTra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienTichDuocDieuTra = table.Column<double>(type: "float", nullable: true),
                    TangChuaNuocDieuTra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TyLeDieuTra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoBay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoBon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LuuVucSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DongChayTBNam = table.Column<double>(type: "float", nullable: true),
                    DongChayKyTruoc = table.Column<double>(type: "float", nullable: true),
                    DongChayKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    DongChayMuaLuTB = table.Column<double>(type: "float", nullable: true),
                    DongChayMuaLuKyTruoc = table.Column<double>(type: "float", nullable: true),
                    DongChayMuaLuKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    DongChayMuaCanTB = table.Column<double>(type: "float", nullable: true),
                    DongChayMuaCanKyTruoc = table.Column<double>(type: "float", nullable: true),
                    DongChayMuaCanKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoBon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoChin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LuuVucSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongCongTrinhKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TongCongTrinhKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    CongTrinhNuocMatKyTruoc = table.Column<double>(type: "float", nullable: true),
                    CongTrinhNuocMatKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    CongTrinhNDDKyTruoc = table.Column<double>(type: "float", nullable: true),
                    CongTrinhNDDKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoChin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoHai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiKyQuanTrac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MuaNamKyTruoc = table.Column<double>(type: "float", nullable: true),
                    MuaNamBaoCao = table.Column<double>(type: "float", nullable: true),
                    MuaNamThayDoi = table.Column<double>(type: "float", nullable: true),
                    MuaMuaKyTruoc = table.Column<double>(type: "float", nullable: true),
                    MuaMuaBaoCao = table.Column<double>(type: "float", nullable: true),
                    MuaMuaThayDoi = table.Column<double>(type: "float", nullable: true),
                    MuaKhoKyTruoc = table.Column<double>(type: "float", nullable: true),
                    MuaKhoBaoCao = table.Column<double>(type: "float", nullable: true),
                    MuaKhoThayDoi = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoHai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoHaiBa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuuLuongKhaiThacLonNhat = table.Column<double>(type: "float", nullable: true),
                    LuuLuongKhaiThacNhoNhat = table.Column<double>(type: "float", nullable: true),
                    LuuLuongKTDuocCapPhep = table.Column<double>(type: "float", nullable: true),
                    SoNgayKhaiThac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucNuocKhaiThacLonNhat = table.Column<double>(type: "float", nullable: true),
                    MucNuocKhaiThacNhoNhat = table.Column<double>(type: "float", nullable: true),
                    ChieuSauMucNuocDongMax = table.Column<double>(type: "float", nullable: true),
                    TongLuongKhaiThac = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoHaiBa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoHaiHai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuuLuongKhaiThacLonNhat = table.Column<double>(type: "float", nullable: true),
                    LuuLuongKhaiThacNhoNhat = table.Column<double>(type: "float", nullable: true),
                    LuuLuongKTDuocCapPhep = table.Column<double>(type: "float", nullable: true),
                    SoNgayKhaiThac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongLuongKhaiThac = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoHaiHai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoHaiLam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThongSoQuanTrac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NongDoLonNhat = table.Column<double>(type: "float", nullable: true),
                    NongDoNhoNhat = table.Column<double>(type: "float", nullable: true),
                    NongDoQuyDinh = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoHaiLam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoHaiMot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuuLuongDenHoLonNhat = table.Column<double>(type: "float", nullable: true),
                    LuuLuongDenHoNhoNhat = table.Column<double>(type: "float", nullable: true),
                    TongLuuLuongXaLonNhat = table.Column<double>(type: "float", nullable: true),
                    TongLuuLuongXaNhoNhat = table.Column<double>(type: "float", nullable: true),
                    DongChayToiThieuLonNhat = table.Column<double>(type: "float", nullable: true),
                    DongChayToiThieuNhoNhat = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoHaiMot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoHaiTu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuuLuongXaThaiLonNhat = table.Column<double>(type: "float", nullable: true),
                    LuuLuongXaThaiNhoNhat = table.Column<double>(type: "float", nullable: true),
                    LuuLuongXaThaiChoPhep = table.Column<double>(type: "float", nullable: true),
                    SoNgayXaThai = table.Column<double>(type: "float", nullable: true),
                    TongLuongXaThai = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoHaiTu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoMot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LuuVucSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongTramQuanTracKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TongTramQuanTracBaoCao = table.Column<double>(type: "float", nullable: true),
                    TramKhiTuongKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TramKhiTuongBaoCao = table.Column<double>(type: "float", nullable: true),
                    TramThuyVanKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TramThuyVanKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    TramTNNKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TramTNNKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    TramQuanTracKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TramQuanTracKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoMot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoMuoiBay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongCTPheDuyetTCQKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TongCTPheDuyetTCQKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    TongCTPheDuyetTCQBoKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TongCTPheDuyetTCQBoKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    TongCTPheDuyetTCQDiaPhuongKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TongCTPheDuyetTCQDiaPhuongKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    TongTCQpKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TongTCQKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoMuoiBay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoMuoiChin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoCuocThanhTraKyTruoc = table.Column<double>(type: "float", nullable: true),
                    SoCuocThanhTraKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    SoDoiTuongThanhTraKyTruoc = table.Column<double>(type: "float", nullable: true),
                    SoDoiTuongThanhTraKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    SoTCCNXuPhatKyTruoc = table.Column<double>(type: "float", nullable: true),
                    SoTCCNXuPhatKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    TongTienXuPhatKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TongTienXuPhatKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoMuoiChin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoMuoiSau",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiGiayPhep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongGPCapKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TongGPCapKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    TongGPBoCapKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TongGPBoCapKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    TongGPDiaPhuongCapKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TongGPDiaPhuongCapBaoCao = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoMuoiSau", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoMuoiTam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LuuVucSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongSongPheDuyetBoKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TongSongPheDuyetBoKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    TongSongPheDuyetDiaPhuongKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TongSongPheDuyetDiaPhuongKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    TongHoPheDuyetKyTruoc = table.Column<double>(type: "float", nullable: true),
                    TongHoPheDuyetKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoMuoiTam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoNam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuuLuongThang1 = table.Column<double>(type: "float", nullable: true),
                    LuuLuongThang2 = table.Column<double>(type: "float", nullable: true),
                    LuuLuongThang3 = table.Column<double>(type: "float", nullable: true),
                    LuuLuongThang4 = table.Column<double>(type: "float", nullable: true),
                    LuuLuongThang5 = table.Column<double>(type: "float", nullable: true),
                    LuuLuongThang6 = table.Column<double>(type: "float", nullable: true),
                    LuuLuongThang7 = table.Column<double>(type: "float", nullable: true),
                    LuuLuongThang8 = table.Column<double>(type: "float", nullable: true),
                    LuuLuongThang9 = table.Column<double>(type: "float", nullable: true),
                    LuuLuongThang10 = table.Column<double>(type: "float", nullable: true),
                    LuuLuongThang11 = table.Column<double>(type: "float", nullable: true),
                    LuuLuongThang12 = table.Column<double>(type: "float", nullable: true),
                    LuuLuongNam = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoNam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoSau",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LuuVucSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLHoChua = table.Column<double>(type: "float", nullable: true),
                    DungTichToanBo = table.Column<double>(type: "float", nullable: true),
                    DungTichHuuich = table.Column<double>(type: "float", nullable: true),
                    DungTichPhongLu = table.Column<double>(type: "float", nullable: true),
                    DungTichTichDuoc = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoSau", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BieuMauSoTam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TangChuaNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLGieng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucNuocMaxKyTruoc = table.Column<double>(type: "float", nullable: true),
                    MucNuocMaxKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    MucNuocMediumKyTruoc = table.Column<double>(type: "float", nullable: true),
                    MucNuocMediumKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    MucNuocMinKyTruoc = table.Column<double>(type: "float", nullable: true),
                    MucNuocMinKyBaoCao = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuMauSoTam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLN_NDD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianQuanTrac = table.Column<int>(type: "int", nullable: true),
                    LuuVucSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TangChuaNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViTriQuanTrac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KyHieuDiemQuanTrac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<double>(type: "float", nullable: true),
                    Y = table.Column<double>(type: "float", nullable: true),
                    PhDot1 = table.Column<double>(type: "float", nullable: true),
                    PhDot2 = table.Column<double>(type: "float", nullable: true),
                    PhDot3 = table.Column<double>(type: "float", nullable: true),
                    ColiformDot1 = table.Column<double>(type: "float", nullable: true),
                    ColiformDot2 = table.Column<double>(type: "float", nullable: true),
                    ColiformDot3 = table.Column<double>(type: "float", nullable: true),
                    NitrateDot1 = table.Column<double>(type: "float", nullable: true),
                    NitrateDot2 = table.Column<double>(type: "float", nullable: true),
                    NitrateDot3 = table.Column<double>(type: "float", nullable: true),
                    AmoniDot1 = table.Column<double>(type: "float", nullable: true),
                    AmoniDot2 = table.Column<double>(type: "float", nullable: true),
                    AmoniDot3 = table.Column<double>(type: "float", nullable: true),
                    TDSDot1 = table.Column<double>(type: "float", nullable: true),
                    TDSDot2 = table.Column<double>(type: "float", nullable: true),
                    TDSDot3 = table.Column<double>(type: "float", nullable: true),
                    DoCungDot1 = table.Column<double>(type: "float", nullable: true),
                    DoCungDot2 = table.Column<double>(type: "float", nullable: true),
                    DoCungDot3 = table.Column<double>(type: "float", nullable: true),
                    ArsenicDot1 = table.Column<double>(type: "float", nullable: true),
                    ArsenicDot2 = table.Column<double>(type: "float", nullable: true),
                    ArsenicDot3 = table.Column<double>(type: "float", nullable: true),
                    ChlorideDot1 = table.Column<double>(type: "float", nullable: true),
                    ChlorideDot2 = table.Column<double>(type: "float", nullable: true),
                    ChlorideDot3 = table.Column<double>(type: "float", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLN_NDD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLN_NuocMat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LuuVucSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianQuanTrac = table.Column<int>(type: "int", nullable: true),
                    SongSuoiHoChua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViTriQuanTrac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KyHieuDiemQuanTrac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<double>(type: "float", nullable: true),
                    Y = table.Column<double>(type: "float", nullable: true),
                    PhDot1 = table.Column<double>(type: "float", nullable: true),
                    PhDot2 = table.Column<double>(type: "float", nullable: true),
                    PhDot3 = table.Column<double>(type: "float", nullable: true),
                    BOD5Dot1 = table.Column<double>(type: "float", nullable: true),
                    BOD5Dot2 = table.Column<double>(type: "float", nullable: true),
                    BOD5Dot3 = table.Column<double>(type: "float", nullable: true),
                    CODDot1 = table.Column<double>(type: "float", nullable: true),
                    CODDot2 = table.Column<double>(type: "float", nullable: true),
                    CODDot3 = table.Column<double>(type: "float", nullable: true),
                    DODot1 = table.Column<double>(type: "float", nullable: true),
                    DODot2 = table.Column<double>(type: "float", nullable: true),
                    DODot3 = table.Column<double>(type: "float", nullable: true),
                    PhotphoDot1 = table.Column<double>(type: "float", nullable: true),
                    PhotphoDot2 = table.Column<double>(type: "float", nullable: true),
                    PhotphoDot3 = table.Column<double>(type: "float", nullable: true),
                    NitoDot1 = table.Column<double>(type: "float", nullable: true),
                    NitoDot2 = table.Column<double>(type: "float", nullable: true),
                    NitoDot3 = table.Column<double>(type: "float", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLN_NuocMat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CT_Loai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCha = table.Column<int>(type: "int", nullable: true),
                    TenLoaiCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoaiCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuThich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_Loai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTKTSDN_KTNDDCuaHoGD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTCCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<double>(type: "float", nullable: true),
                    Y = table.Column<double>(type: "float", nullable: true),
                    SoThuaDat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChieuSauGieng = table.Column<double>(type: "float", nullable: true),
                    SoNguoiSD = table.Column<double>(type: "float", nullable: true),
                    TinhTrangChatLuongNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrangKeKhai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTKTSDN_KTNDDCuaHoGD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTKTSDN_PCGP_NDD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTCCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamVanHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<double>(type: "float", nullable: true),
                    Y = table.Column<double>(type: "float", nullable: true),
                    LuuVuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TangChuaNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoGieng = table.Column<int>(type: "int", nullable: true),
                    ChieuSauCacGieng = table.Column<double>(type: "float", nullable: true),
                    ToaDoCacGieng = table.Column<double>(type: "float", nullable: true),
                    MucDichKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoToMay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongLuuLuongKT = table.Column<double>(type: "float", nullable: true),
                    CheDoKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhuongThucKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianVanHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhHinhCapGP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoGP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianHieuLuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianKetThuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBatDauKetNoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTKTSDN_PCGP_NDD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTKTSDN_PCGP_NuocBien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTCCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamVanHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<double>(type: "float", nullable: true),
                    Y = table.Column<double>(type: "float", nullable: true),
                    TenVungbien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheDoLayNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiemLayNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CongSuatTho = table.Column<double>(type: "float", nullable: true),
                    CongSuatTinh = table.Column<double>(type: "float", nullable: true),
                    SoToMay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuuLuongKTMax = table.Column<double>(type: "float", nullable: true),
                    SoMayBom = table.Column<int>(type: "int", nullable: true),
                    DiemXaNuocLamMat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuuLuongXaMax = table.Column<double>(type: "float", nullable: true),
                    CongSuatThietKe = table.Column<double>(type: "float", nullable: true),
                    PhuongThucKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDichKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheDoKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoGP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianHieuLuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBatDauKetNoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTKTSDN_PCGP_NuocBien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTKTSDN_PCGP_NuocMat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamVanHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<double>(type: "float", nullable: true),
                    Y = table.Column<double>(type: "float", nullable: true),
                    TenSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuuVucSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaoTrinhDap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaoTrinhNguongTran = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuuLuongXaLuTK = table.Column<double>(type: "float", nullable: true),
                    LuuLuongXaLuKT = table.Column<double>(type: "float", nullable: true),
                    DungTichChet = table.Column<double>(type: "float", nullable: true),
                    SoToMay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoGP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianHieuLuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBatDauKetNoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheDoKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTKTSDN_PCGP_NuocMat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTKTSDN_PDK_NDD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTCCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamVanHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<double>(type: "float", nullable: true),
                    Y = table.Column<double>(type: "float", nullable: true),
                    LuuVuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TangChuaNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoGieng = table.Column<int>(type: "int", nullable: true),
                    ChieuSauCacGieng = table.Column<double>(type: "float", nullable: true),
                    ToaDoCacGieng = table.Column<double>(type: "float", nullable: true),
                    MucDichKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoToMay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongLuuLuongKT = table.Column<double>(type: "float", nullable: true),
                    CheDoKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhuongThucKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianVanHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhHinhCapGP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoGP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianHieuLuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianKetThuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBatDauKetNoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTKTSDN_PDK_NDD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTKTSDN_PDK_NuocBien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTCCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamVanHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<double>(type: "float", nullable: true),
                    Y = table.Column<double>(type: "float", nullable: true),
                    TenVungbien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheDoLayNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiemLayNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CongSuatTho = table.Column<double>(type: "float", nullable: true),
                    CongSuatTinh = table.Column<double>(type: "float", nullable: true),
                    SoToMay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuuLuongKTMax = table.Column<double>(type: "float", nullable: true),
                    SoMayBom = table.Column<int>(type: "int", nullable: true),
                    DiemXaNuocLamMat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuuLuongXaMax = table.Column<double>(type: "float", nullable: true),
                    CongSuatThietKe = table.Column<double>(type: "float", nullable: true),
                    PhuongThucKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDichKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheDoKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoGP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianHieuLuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBatDauKetNoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTKTSDN_PDK_NuocBien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTKTSDN_PDK_NuocMat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamVanHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<double>(type: "float", nullable: true),
                    Y = table.Column<double>(type: "float", nullable: true),
                    TenSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuuVucSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaoTrinhDap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaoTrinhNguongTran = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuuLuongXaLuTK = table.Column<double>(type: "float", nullable: true),
                    LuuLuongXaLuKT = table.Column<double>(type: "float", nullable: true),
                    DungTichChet = table.Column<double>(type: "float", nullable: true),
                    SoToMay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoGP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianHieuLuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBatDauKetNoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheDoKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTKTSDN_PDK_NuocMat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucNN_LienTinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenSongSuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChayRa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XDiemDau = table.Column<double>(type: "float", nullable: true),
                    YDiemDau = table.Column<double>(type: "float", nullable: true),
                    ThonDiemDau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XaPhuongTTDiemDau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuyenTPDiemDau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XDiemCuoi = table.Column<double>(type: "float", nullable: true),
                    YDiemCuoi = table.Column<double>(type: "float", nullable: true),
                    ThonDiemCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XaPhuongTTDiemCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuyenTPDiemCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucNN_LienTinh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucNN_NoiTinh_AoHo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenHoChua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XaPhuongTT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuyenTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguonNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocHeThongSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucNN_NoiTinh_AoHo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucNN_NoiTinh_SongSuoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenSongSuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChayRa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XDiemDau = table.Column<double>(type: "float", nullable: true),
                    YDiemDau = table.Column<double>(type: "float", nullable: true),
                    ThonDiemDau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XaPhuongTTDiemDau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuyenTPDiemDau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XDiemCuoi = table.Column<double>(type: "float", nullable: true),
                    YDiemCuoi = table.Column<double>(type: "float", nullable: true),
                    ThonDiemCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XaPhuongTTDiemCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuyenTPDiemCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucNN_NoiTinh_SongSuoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dashboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermitAccess = table.Column<bool>(type: "bit", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Demo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoThucTest = table.Column<double>(type: "float", nullable: false),
                    ChuGiai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonViDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViDo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermitCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GP_Loai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiGP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoaiGP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GP_Loai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_DuLieu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConstructionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParameterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeviceStatus = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_DuLieu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_TaiKhoanTruyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CameraLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FTPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Protocol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Port = table.Column<int>(type: "int", nullable: true),
                    WorkingDirectory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_TaiKhoanTruyen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSKTT_NDD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KyHieuCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTaiLieuHoSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenToChucThucHienQuanTrac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiThanhLapHoSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiKiemTraHoSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePDF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSKTT_NDD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSKTT_NuocMat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KyHieuCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTaiLieuHoSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenToChucThucHienQuanTrac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiThanhLapHoSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiKiemTraHoSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePDF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSKTT_NuocMat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Huyen",
                columns: table => new
                {
                    IdHuyen = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenHuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapHanhChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huyen", x => x.IdHuyen);
                });

            migrationBuilder.CreateTable(
                name: "KKTNN_NuocMat_ChatLuong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdXa = table.Column<int>(type: "int", nullable: true),
                    IdHuyen = table.Column<int>(type: "int", nullable: true),
                    IdTinh = table.Column<int>(type: "int", nullable: true),
                    IdLuuVucSong = table.Column<int>(type: "int", nullable: true),
                    ViTriQuanTrac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaTriWQI = table.Column<double>(type: "float", nullable: true),
                    BOD5Max = table.Column<double>(type: "float", nullable: true),
                    BOD5Min = table.Column<double>(type: "float", nullable: true),
                    CODMax = table.Column<double>(type: "float", nullable: true),
                    CODMin = table.Column<double>(type: "float", nullable: true),
                    DOMax = table.Column<double>(type: "float", nullable: true),
                    DOMin = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KKTNN_NuocMat_ChatLuong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KKTNN_NuocMat_SoLuong_AoHoDamPha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguonNuocKhaiThac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocHeThongSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienTichMatNuoc = table.Column<double>(type: "float", nullable: true),
                    DungTichToanBo = table.Column<double>(type: "float", nullable: true),
                    DungTichHuuIch = table.Column<double>(type: "float", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KKTNN_NuocMat_SoLuong_AoHoDamPha", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KKTNN_NuocMat_SoLuong_SongSuoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChayRa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChieuDai = table.Column<double>(type: "float", nullable: true),
                    ChieuDaiThuocTinh_ThanhPho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DauSongX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DauSongY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DauSongXaHuyenTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuoiSongX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuoiSongY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuoiSongXaHuyenTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KKTNN_NuocMat_SoLuong_SongSuoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LuuVucSong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdXa = table.Column<int>(type: "int", nullable: true),
                    IdHuyen = table.Column<int>(type: "int", nullable: true),
                    TenLVS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuGiai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViTriQT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<int>(type: "int", nullable: true),
                    NgayKetThuc = table.Column<int>(type: "int", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuuVucSong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MuaHienTai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TramMua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuongMua1Gio = table.Column<double>(type: "float", nullable: true),
                    NguongMua1Gio = table.Column<double>(type: "float", nullable: true),
                    LuongMua3Gio = table.Column<double>(type: "float", nullable: true),
                    NguongMua3Gio = table.Column<double>(type: "float", nullable: true),
                    LuongMua6Gio = table.Column<double>(type: "float", nullable: true),
                    NguongMua6Gio = table.Column<double>(type: "float", nullable: true),
                    LuongMua12Gio = table.Column<double>(type: "float", nullable: true),
                    NguongMua12Gio = table.Column<double>(type: "float", nullable: true),
                    LuongMua24Gio = table.Column<double>(type: "float", nullable: true),
                    NguongMua24Gio = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuaHienTai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MucDichKT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MucDich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MucDichKT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_AoHoDamPhaKhongDuocSanLap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHoChua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguonNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocLVS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiHinhChucNang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienTichMatNuoc = table.Column<double>(type: "float", nullable: true),
                    DungTichToanBo = table.Column<double>(type: "float", nullable: true),
                    DungTichHuuIch = table.Column<double>(type: "float", nullable: true),
                    DungTichPhongLu = table.Column<double>(type: "float", nullable: true),
                    MucNuocDangBinhThuong = table.Column<double>(type: "float", nullable: true),
                    MucNuocChet = table.Column<double>(type: "float", nullable: true),
                    NamHoanThanh = table.Column<int>(type: "int", nullable: true),
                    DonQuayLyVanHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocDanhMucKhongSanLap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_AoHoDamPhaKhongDuocSanLap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_CNNN_Ho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHoChua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocLVS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XaPhuongTT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuyenTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienTichMatNuoc = table.Column<double>(type: "float", nullable: true),
                    DungTichToanBo = table.Column<double>(type: "float", nullable: true),
                    DungTichHuuIch = table.Column<double>(type: "float", nullable: true),
                    NamHoanThanh = table.Column<int>(type: "int", nullable: true),
                    DonViQuanLyVanHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucNangNguonNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucTieuChatLuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_CNNN_Ho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_CNNN_SongSuoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenSongSuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChayRa = table.Column<double>(type: "float", nullable: true),
                    ChieuDai = table.Column<double>(type: "float", nullable: true),
                    DiaPhanHanhChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XDiemDau = table.Column<double>(type: "float", nullable: true),
                    YDiemDau = table.Column<double>(type: "float", nullable: true),
                    XDiemCuoi = table.Column<double>(type: "float", nullable: true),
                    YDiemCuoi = table.Column<double>(type: "float", nullable: true),
                    ChucNangNguonNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucTieuChatLuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianThucHien = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_CNNN_SongSuoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_CNNN_TangChuaNuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViTriPhamVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XaPhuongTT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuyenTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiChuaNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChieuSauPhanBo = table.Column<double>(type: "float", nullable: true),
                    ChucNangNguonNuoc = table.Column<double>(type: "float", nullable: true),
                    MucTieuChatLuongNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_CNNN_TangChuaNuoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_DCTT_HaDuHoChua",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocLVS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XaPhuongTT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuyenTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguonNuocKhaiThac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QttSauDap = table.Column<double>(type: "float", nullable: true),
                    QttSauCT = table.Column<double>(type: "float", nullable: true),
                    QttQuyDinhKhac = table.Column<double>(type: "float", nullable: true),
                    LoaiHinhCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_DCTT_HaDuHoChua", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_DCTT_SongSuoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocLVS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XaPhuongTT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuyenTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<double>(type: "float", nullable: true),
                    Y = table.Column<double>(type: "float", nullable: true),
                    DienTichViTriXacDinhQtt = table.Column<double>(type: "float", nullable: true),
                    Qtt = table.Column<double>(type: "float", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_DCTT_SongSuoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XaPhuongTT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaPhanHanhChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuyenTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DungTichHo106m3 = table.Column<double>(type: "float", nullable: true),
                    PhamViHanhLang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocDienCamMocHanhLang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiHo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XaPhuongTT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaPhanHanhChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuyenTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DungTichHo106m3 = table.Column<double>(type: "float", nullable: true),
                    PhamViHanhLang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocDienCamMocHanhLang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiHo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XaPhuongTT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaPhanHanhChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuyenTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DungTichHo106m3 = table.Column<double>(type: "float", nullable: true),
                    PhamViHanhLang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocDienCamMocHanhLang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_HanhLangBaoVeNN_SongSuoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoanSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChieuDai = table.Column<double>(type: "float", nullable: true),
                    DiaPhanHanhChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XDiemDau = table.Column<double>(type: "float", nullable: true),
                    YDiemDau = table.Column<double>(type: "float", nullable: true),
                    XDiemCuoi = table.Column<double>(type: "float", nullable: true),
                    YDiemCuoi = table.Column<double>(type: "float", nullable: true),
                    ChucNang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhamViHanhLangBaoVe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianThucHien = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_HanhLangBaoVeNN_SongSuoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_LuuVucSong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenSongSuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChayRa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChieuDai = table.Column<double>(type: "float", nullable: true),
                    DienTich = table.Column<double>(type: "float", nullable: true),
                    Tinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocLVS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiSongSuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_LuuVucSong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_MatCatSongSuoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoHieuMatCat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenSongSuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocLVS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XBoTrai = table.Column<double>(type: "float", nullable: true),
                    YBoTrai = table.Column<double>(type: "float", nullable: true),
                    XBoPhai = table.Column<double>(type: "float", nullable: true),
                    YBoPhai = table.Column<double>(type: "float", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoHieuDiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhoangCach = table.Column<double>(type: "float", nullable: true),
                    CaoDoDaySong = table.Column<double>(type: "float", nullable: true),
                    ThoiGianDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucNuocSong = table.Column<double>(type: "float", nullable: true),
                    DonViDoDacKhaoSat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_MatCatSongSuoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_NguongKhaiThacNDD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiChuaNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienTichPhanBo = table.Column<double>(type: "float", nullable: true),
                    KhoangChieuSauPhanBo = table.Column<double>(type: "float", nullable: true),
                    NguongGHKTLuuLuong = table.Column<double>(type: "float", nullable: true),
                    NguongGHKTMucNuoc = table.Column<double>(type: "float", nullable: true),
                    QDPheDuyetNguongGioiHanKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_NguongKhaiThacNDD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_NguonNuoc_AoHoDamPha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHoChua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguonNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocLVS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienTichMatNuoc = table.Column<double>(type: "float", nullable: true),
                    XaPhuongTT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuyenTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DungTichToanBo = table.Column<double>(type: "float", nullable: true),
                    DungTichHuuIch = table.Column<double>(type: "float", nullable: true),
                    DungTichPhongLu = table.Column<double>(type: "float", nullable: true),
                    MNDBT = table.Column<double>(type: "float", nullable: true),
                    MNC = table.Column<double>(type: "float", nullable: true),
                    NamXayDung = table.Column<int>(type: "int", nullable: true),
                    DonViQuanLyVanHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhamViHanhLang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocDienCamMocHanhLang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_NguonNuoc_AoHoDamPha", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_NguonNuoc_SongSuoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenSongSuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChayRa = table.Column<double>(type: "float", nullable: true),
                    ChieuDai = table.Column<double>(type: "float", nullable: true),
                    DiaPhanHanhChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XDiemDau = table.Column<double>(type: "float", nullable: true),
                    YDiemDau = table.Column<double>(type: "float", nullable: true),
                    XDiemCuoi = table.Column<double>(type: "float", nullable: true),
                    YDiemCuoi = table.Column<double>(type: "float", nullable: true),
                    ChucNang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhamViHanhLangBaoVe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianThucHien = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_NguonNuoc_SongSuoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_NguonNuoc_TangChuaNuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTangChuaNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiChuaNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocLVS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XaPhuongTT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuyenTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DungTichPhanBo = table.Column<double>(type: "float", nullable: true),
                    KhoangChieuSauPhanBo = table.Column<double>(type: "float", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_NguonNuoc_TangChuaNuoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NN_VungCamHanCheKTNDD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVungCamHanChe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienTichVungCamHanChe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhamViChieuSau = table.Column<double>(type: "float", nullable: true),
                    CacBienPhapHanCheKT = table.Column<double>(type: "float", nullable: true),
                    QDPheDuyetVungCamKT = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_VungCamHanCheKTNDD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DashboardId = table.Column<int>(type: "int", nullable: true),
                    FunctionId = table.Column<int>(type: "int", nullable: true),
                    FunctionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunctionCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhanDoanSong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LuuVucSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Song = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDoanSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhanDoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChieuDai = table.Column<double>(type: "float", nullable: true),
                    DienTichLV = table.Column<double>(type: "float", nullable: true),
                    XDau = table.Column<double>(type: "float", nullable: true),
                    YDau = table.Column<double>(type: "float", nullable: true),
                    XCuoi = table.Column<double>(type: "float", nullable: true),
                    YCuoi = table.Column<double>(type: "float", nullable: true),
                    DiaGioiHanhChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDichSuDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChatLuongNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanDoanSong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleDashboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DashboardId = table.Column<int>(type: "int", nullable: true),
                    FileControl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermitAccess = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleDashboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SLDTKTSDN_NDD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuHoCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuongGieng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UocTinhLuongNuocKT = table.Column<double>(type: "float", nullable: true),
                    LoaiCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HinhThucKT = table.Column<double>(type: "float", nullable: true),
                    ChieuSauKT = table.Column<double>(type: "float", nullable: true),
                    MucDichSD = table.Column<double>(type: "float", nullable: true),
                    TinhTrangSD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhieuDieuTraPDF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLDTKTSDN_NDD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SLDTKTSDN_NuocMat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuHoCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNguonNuocKhaiThac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDichSD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UocTinhLuongNuocKT = table.Column<double>(type: "float", nullable: true),
                    DienTichTuoi = table.Column<double>(type: "float", nullable: true),
                    DienTichNuoiTrongThuySan = table.Column<double>(type: "float", nullable: true),
                    CongSuatPhatDien = table.Column<double>(type: "float", nullable: true),
                    SoHoDanDuocCapNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheDoKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePDF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLDTKTSDN_NuocMat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SLDTKTSDN_XaThai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuHoCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiHinhNuocThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuyMo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDichSD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienTichTuoi = table.Column<double>(type: "float", nullable: true),
                    DienTichNuoiTrongThuySan = table.Column<double>(type: "float", nullable: true),
                    CongSuatPhatDien = table.Column<double>(type: "float", nullable: true),
                    SoHoDanDuocCapNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheDoKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhieuDieuTraPDF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLDTKTSDN_XaThai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SLN_TongLuongNuocMat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LuuVucSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TBNhieuNamDCNam = table.Column<double>(type: "float", nullable: true),
                    KyTruocDCNam = table.Column<double>(type: "float", nullable: true),
                    KyBaoCaoDCNam = table.Column<double>(type: "float", nullable: true),
                    ThayDoiDCNam = table.Column<double>(type: "float", nullable: true),
                    TBNhieuNamDCLu = table.Column<double>(type: "float", nullable: true),
                    KyTruocDCLu = table.Column<double>(type: "float", nullable: true),
                    KyBaoCaoDCLu = table.Column<double>(type: "float", nullable: true),
                    ThayDoiDCLu = table.Column<double>(type: "float", nullable: true),
                    TBNhieuNamDCMuaCan = table.Column<double>(type: "float", nullable: true),
                    KyTruocDCMuaCan = table.Column<double>(type: "float", nullable: true),
                    KyBaoCaoDCMuaCan = table.Column<double>(type: "float", nullable: true),
                    ThayDoiDCMuaCan = table.Column<double>(type: "float", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLN_TongLuongNuocMat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TangChuaNuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KyHieuTCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuongGiengQT = table.Column<int>(type: "int", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TangChuaNuoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TCQ_ThongTin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCon = table.Column<int>(type: "int", nullable: true),
                    SoQDTCQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayKy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoQuanCP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongTienCQ = table.Column<double>(type: "float", nullable: true),
                    FilePDF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCQ_ThongTin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongSoCLNAo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PH = table.Column<double>(type: "float", nullable: true),
                    BOD = table.Column<double>(type: "float", nullable: true),
                    Amoni = table.Column<double>(type: "float", nullable: true),
                    COD = table.Column<double>(type: "float", nullable: true),
                    TOC = table.Column<double>(type: "float", nullable: true),
                    TSS = table.Column<double>(type: "float", nullable: true),
                    DO = table.Column<double>(type: "float", nullable: true),
                    TongPhosphor = table.Column<double>(type: "float", nullable: true),
                    TongNito = table.Column<double>(type: "float", nullable: true),
                    Chiorophylla = table.Column<double>(type: "float", nullable: true),
                    TongColiform = table.Column<double>(type: "float", nullable: true),
                    ColiformChiuNhiet = table.Column<double>(type: "float", nullable: true),
                    MucPLCLNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoCLNAo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongSoCLNSong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pH = table.Column<double>(type: "float", nullable: true),
                    BOD = table.Column<double>(type: "float", nullable: true),
                    COD = table.Column<double>(type: "float", nullable: true),
                    TOC = table.Column<double>(type: "float", nullable: true),
                    TSS = table.Column<double>(type: "float", nullable: true),
                    DO = table.Column<double>(type: "float", nullable: true),
                    TongPhosphor = table.Column<double>(type: "float", nullable: true),
                    TongNito = table.Column<double>(type: "float", nullable: true),
                    TongColiform = table.Column<double>(type: "float", nullable: true),
                    ColiformChiuNhiet = table.Column<double>(type: "float", nullable: true),
                    Amoni = table.Column<double>(type: "float", nullable: true),
                    MucPLCLNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoCLNSong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TieuVungLuuVuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLuuVuc = table.Column<int>(type: "int", nullable: true),
                    TieuVungQuyHoach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuGiai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TieuVungLuuVuc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToChuc_CaNhan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTCCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaSoThue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiamDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiDuocUyQuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiDaiDienPhapLuat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToChuc_CaNhan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tram_LoaiTram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCha = table.Column<int>(type: "int", nullable: true),
                    TenLoaiTram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoaiTram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuThich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tram_LoaiTram", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDashboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DashboardId = table.Column<int>(type: "int", nullable: true),
                    FileControl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermitAccess = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDashboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VHHC_HoChua_ThongSoKT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHoChua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocLVS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FLv = table.Column<double>(type: "float", nullable: true),
                    XTbNam = table.Column<double>(type: "float", nullable: true),
                    QoTbNam = table.Column<double>(type: "float", nullable: true),
                    P002 = table.Column<double>(type: "float", nullable: true),
                    P01 = table.Column<double>(type: "float", nullable: true),
                    P02 = table.Column<double>(type: "float", nullable: true),
                    P05 = table.Column<double>(type: "float", nullable: true),
                    MNDBT = table.Column<double>(type: "float", nullable: true),
                    MNC = table.Column<double>(type: "float", nullable: true),
                    MNMaxP002 = table.Column<double>(type: "float", nullable: true),
                    MNMaxP01 = table.Column<double>(type: "float", nullable: true),
                    MNMaxP02 = table.Column<double>(type: "float", nullable: true),
                    MNMaxP05 = table.Column<double>(type: "float", nullable: true),
                    WToanBo = table.Column<double>(type: "float", nullable: true),
                    WHuuIch = table.Column<double>(type: "float", nullable: true),
                    WNam = table.Column<double>(type: "float", nullable: true),
                    WNhieuNam = table.Column<double>(type: "float", nullable: true),
                    WChet = table.Column<double>(type: "float", nullable: true),
                    QDamBao = table.Column<double>(type: "float", nullable: true),
                    QMin = table.Column<double>(type: "float", nullable: true),
                    QMax = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VHHC_HoChua_ThongSoKT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VHHC_LuuVucSong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LuuVucSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienTichLuuVuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChieuDaiSongChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BanDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDoCacCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoQuyTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TepDinhKem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VHHC_LuuVucSong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Xa",
                columns: table => new
                {
                    IdXa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenXa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapHanhChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    IdHuyen = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xa", x => x.IdXa);
                    table.ForeignKey(
                        name: "FK_Xa_Huyen_IdHuyen",
                        column: x => x.IdHuyen,
                        principalTable: "Huyen",
                        principalColumn: "IdHuyen");
                });

            migrationBuilder.CreateTable(
                name: "KKTNN_NuocMat_TongLuong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLuuVucSong = table.Column<int>(type: "int", nullable: true),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    Thang1 = table.Column<double>(type: "float", nullable: true),
                    Thang2 = table.Column<double>(type: "float", nullable: true),
                    Thang3 = table.Column<double>(type: "float", nullable: true),
                    Thang4 = table.Column<double>(type: "float", nullable: true),
                    Thang5 = table.Column<double>(type: "float", nullable: true),
                    Thang6 = table.Column<double>(type: "float", nullable: true),
                    Thang7 = table.Column<double>(type: "float", nullable: true),
                    Thang8 = table.Column<double>(type: "float", nullable: true),
                    Thang9 = table.Column<double>(type: "float", nullable: true),
                    Thang10 = table.Column<double>(type: "float", nullable: true),
                    Thang11 = table.Column<double>(type: "float", nullable: true),
                    Thang12 = table.Column<double>(type: "float", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KKTNN_NuocMat_TongLuong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KKTNN_NuocMat_TongLuong_LuuVucSong_IdLuuVucSong",
                        column: x => x.IdLuuVucSong,
                        principalTable: "LuuVucSong",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLuuVuc = table.Column<int>(type: "int", nullable: true),
                    TenSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XDauSong = table.Column<double>(type: "float", nullable: true),
                    YDauSong = table.Column<double>(type: "float", nullable: true),
                    IdXaDauSong = table.Column<int>(type: "int", nullable: true),
                    IdHuyenDauSong = table.Column<int>(type: "int", nullable: true),
                    XCuoiSong = table.Column<double>(type: "float", nullable: true),
                    YCuoiSong = table.Column<double>(type: "float", nullable: true),
                    IdXaCuoiSong = table.Column<int>(type: "int", nullable: true),
                    IdHuyenCuoiSong = table.Column<int>(type: "int", nullable: true),
                    MaSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qtt = table.Column<double>(type: "float", nullable: true),
                    ChuGiai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Song_LuuVucSong_IdLuuVuc",
                        column: x => x.IdLuuVuc,
                        principalTable: "LuuVucSong",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocNhan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    LuuLuongDongChay = table.Column<double>(type: "float", nullable: true),
                    CnnBOD = table.Column<double>(type: "float", nullable: true),
                    CnnCOD = table.Column<double>(type: "float", nullable: true),
                    CnnAmoni = table.Column<double>(type: "float", nullable: true),
                    CnnTongN = table.Column<double>(type: "float", nullable: true),
                    CnnTongP = table.Column<double>(type: "float", nullable: true),
                    CnnTSS = table.Column<double>(type: "float", nullable: true),
                    CnnColiform = table.Column<double>(type: "float", nullable: true),
                    LnnBOD = table.Column<double>(type: "float", nullable: true),
                    LnnCOD = table.Column<double>(type: "float", nullable: true),
                    LnnAmoni = table.Column<double>(type: "float", nullable: true),
                    LnnTongN = table.Column<double>(type: "float", nullable: true),
                    LnnTongP = table.Column<double>(type: "float", nullable: true),
                    LnnTSS = table.Column<double>(type: "float", nullable: true),
                    LnnColiform = table.Column<double>(type: "float", nullable: true),
                    CqcBOD = table.Column<double>(type: "float", nullable: true),
                    CqcCOD = table.Column<double>(type: "float", nullable: true),
                    CqcAmoni = table.Column<double>(type: "float", nullable: true),
                    CqcTongN = table.Column<double>(type: "float", nullable: true),
                    CqcTongP = table.Column<double>(type: "float", nullable: true),
                    CqcTSS = table.Column<double>(type: "float", nullable: true),
                    CqcColiform = table.Column<double>(type: "float", nullable: true),
                    LtdBOD = table.Column<double>(type: "float", nullable: true),
                    LtdCOD = table.Column<double>(type: "float", nullable: true),
                    LtdAmoni = table.Column<double>(type: "float", nullable: true),
                    LtdTongN = table.Column<double>(type: "float", nullable: true),
                    LtdTongP = table.Column<double>(type: "float", nullable: true),
                    LtdTSS = table.Column<double>(type: "float", nullable: true),
                    LtdColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocNhan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocNhan_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiDiem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    LuuLuongXaThai = table.Column<double>(type: "float", nullable: true),
                    NguonThaiCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToaDoX = table.Column<double>(type: "float", nullable: true),
                    ToaDoY = table.Column<double>(type: "float", nullable: true),
                    CtdiemBOD = table.Column<double>(type: "float", nullable: true),
                    CtdiemCOD = table.Column<double>(type: "float", nullable: true),
                    CtdiemAmoni = table.Column<double>(type: "float", nullable: true),
                    CtdiemTongN = table.Column<double>(type: "float", nullable: true),
                    CtdiemTongP = table.Column<double>(type: "float", nullable: true),
                    CtdiemTSS = table.Column<double>(type: "float", nullable: true),
                    CtdiemColiform = table.Column<double>(type: "float", nullable: true),
                    LtdiemBOD = table.Column<double>(type: "float", nullable: true),
                    LtdiemCOD = table.Column<double>(type: "float", nullable: true),
                    LtdiemAmoni = table.Column<double>(type: "float", nullable: true),
                    LtdiemTongN = table.Column<double>(type: "float", nullable: true),
                    LtdiemTongP = table.Column<double>(type: "float", nullable: true),
                    LtdiemTSS = table.Column<double>(type: "float", nullable: true),
                    LtdiemColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiDiem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiDiem_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiGiaCam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    SoGiaCam = table.Column<int>(type: "int", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamBOD = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamCOD = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamAmoni = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamTongN = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamTongP = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamTSS = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamColiform = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamBOD = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamCOD = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamAmoni = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamTongN = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamTongP = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamTSS = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiGiaCam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiGiaCam_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiLon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    SoLon = table.Column<int>(type: "int", nullable: true),
                    SoDe = table.Column<int>(type: "int", nullable: true),
                    SoGiaSucKhac = table.Column<int>(type: "int", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtLonBOD = table.Column<double>(type: "float", nullable: true),
                    CtLonCOD = table.Column<double>(type: "float", nullable: true),
                    CtLonAmoni = table.Column<double>(type: "float", nullable: true),
                    CtLonTongN = table.Column<double>(type: "float", nullable: true),
                    CtLonTongP = table.Column<double>(type: "float", nullable: true),
                    CtLonTSS = table.Column<double>(type: "float", nullable: true),
                    CtLonColiform = table.Column<double>(type: "float", nullable: true),
                    LtLonBOD = table.Column<double>(type: "float", nullable: true),
                    LtLonCOD = table.Column<double>(type: "float", nullable: true),
                    LtLonAmoni = table.Column<double>(type: "float", nullable: true),
                    LtLonTongN = table.Column<double>(type: "float", nullable: true),
                    LtLonTongP = table.Column<double>(type: "float", nullable: true),
                    LtLonTSS = table.Column<double>(type: "float", nullable: true),
                    LtLonColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiLon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiLon_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiSinhHoat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    SoDan = table.Column<int>(type: "int", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatBOD = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatCOD = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatAmoni = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatTongN = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatTongP = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatTSS = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatColiform = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatBOD = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatCOD = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatAmoni = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatTongN = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatTongP = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatTSS = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiSinhHoat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiSinhHoat_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiTrauBo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    SoTrau = table.Column<int>(type: "int", nullable: true),
                    SoBo = table.Column<int>(type: "int", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoBOD = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoCOD = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoAmoni = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoTongN = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoTongP = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoTSS = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoColiform = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoBOD = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoCOD = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoAmoni = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoTongN = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoTongP = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoTSS = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiTrauBo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiTrauBo_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiTrongCay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    DienTichTrongCay = table.Column<double>(type: "float", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayBOD = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayCOD = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayAmoni = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayTongN = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayTongP = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayTSS = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayColiform = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayBOD = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayCOD = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayAmoni = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayTongN = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayTongP = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayTSS = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiTrongCay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiTrongCay_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiTrongLua",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    DienTichTrongLua = table.Column<double>(type: "float", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaBOD = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaCOD = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaAmoni = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaTongN = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaTongP = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaTSS = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaColiform = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaBOD = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaCOD = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaAmoni = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaTongN = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaTongP = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaTSS = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiTrongLua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiTrongLua_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiTrongRung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    DienTichTrongRung = table.Column<double>(type: "float", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungBOD = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungCOD = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungAmoni = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungTongN = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungTongP = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungTSS = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungColiform = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungBOD = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungCOD = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungAmoni = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungTongN = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungTongP = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungTSS = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiTrongRung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiTrongRung_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CT_ThongTin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLoaiCT = table.Column<int>(type: "int", nullable: true),
                    IdSong = table.Column<int>(type: "int", nullable: true),
                    IdLuuVuc = table.Column<int>(type: "int", nullable: true),
                    IdTieuLuuVuc = table.Column<int>(type: "int", nullable: true),
                    IdTangChuaNuoc = table.Column<int>(type: "int", nullable: true),
                    TenCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViTriCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<double>(type: "float", nullable: true),
                    Y = table.Column<double>(type: "float", nullable: true),
                    CapCT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamBatDauVanHanh = table.Column<int>(type: "int", nullable: true),
                    NguonNuocKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhuongThucKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianHNK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDichKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDichHNK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDichhTD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuyMoHNK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianXD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuongGiengKT = table.Column<int>(type: "int", nullable: true),
                    SoLuongGiengQT = table.Column<int>(type: "int", nullable: true),
                    SoDiemXaThai = table.Column<int>(type: "int", nullable: true),
                    SoLuongGieng = table.Column<int>(type: "int", nullable: true),
                    KhoiLuongCacHangMucTD = table.Column<int>(type: "int", nullable: true),
                    QKTThietKe = table.Column<int>(type: "int", nullable: true),
                    QKTThucTe = table.Column<int>(type: "int", nullable: true),
                    ViTriXT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuThich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_ThongTin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CT_ThongTin_CT_Loai_IdLoaiCT",
                        column: x => x.IdLoaiCT,
                        principalTable: "CT_Loai",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CT_ThongTin_LuuVucSong_IdLuuVuc",
                        column: x => x.IdLuuVuc,
                        principalTable: "LuuVucSong",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CT_ThongTin_TangChuaNuoc_IdTangChuaNuoc",
                        column: x => x.IdTangChuaNuoc,
                        principalTable: "TangChuaNuoc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KKTNN_NuocDuoiDat_SoLuong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTangChuaNuoc = table.Column<int>(type: "int", nullable: true),
                    SoLuongGieng = table.Column<int>(type: "int", nullable: true),
                    HmaxKyTruoc = table.Column<double>(type: "float", nullable: true),
                    HmaxBaoCao = table.Column<double>(type: "float", nullable: true),
                    HTBKyTruoc = table.Column<double>(type: "float", nullable: true),
                    HTBBaoCao = table.Column<double>(type: "float", nullable: true),
                    HminKyTruoc = table.Column<double>(type: "float", nullable: true),
                    HminBaoCao = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KKTNN_NuocDuoiDat_SoLuong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KKTNN_NuocDuoiDat_SoLuong_TangChuaNuoc_IdTangChuaNuoc",
                        column: x => x.IdTangChuaNuoc,
                        principalTable: "TangChuaNuoc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KKTNN_NuocDuoiDat_TongLuong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTangChuaNuoc = table.Column<int>(type: "int", nullable: true),
                    NuocNgot_DienTichPhanBo = table.Column<float>(type: "real", nullable: true),
                    NuocNgot_IdXa = table.Column<int>(type: "int", nullable: true),
                    NuocNgot_IdHuyen = table.Column<int>(type: "int", nullable: true),
                    NuocNgot_TLTiemNang = table.Column<double>(type: "float", nullable: true),
                    NuocNgot_TLCoTheKhaiThac = table.Column<double>(type: "float", nullable: true),
                    NuocMan_DienTichPhanBo = table.Column<double>(type: "float", nullable: true),
                    NuocMan_IdXa = table.Column<int>(type: "int", nullable: true),
                    NuocMan_IdHuyen = table.Column<int>(type: "int", nullable: true),
                    NuocMan_TruLuong = table.Column<double>(type: "float", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KKTNN_NuocDuoiDat_TongLuong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KKTNN_NuocDuoiDat_TongLuong_TangChuaNuoc_IdTangChuaNuoc",
                        column: x => x.IdTangChuaNuoc,
                        principalTable: "TangChuaNuoc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tram_ThongTin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdXa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdHuyen = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdLoaiTram = table.Column<int>(type: "int", nullable: true),
                    MaTram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiTram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<double>(type: "float", nullable: true),
                    Y = table.Column<double>(type: "float", nullable: true),
                    NgayBatDau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayKetThuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoSoThanhLap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoSoHoatDong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CameraLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineStatus = table.Column<bool>(type: "bit", nullable: true),
                    ChuThich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tram_ThongTin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tram_ThongTin_Huyen_IdHuyen",
                        column: x => x.IdHuyen,
                        principalTable: "Huyen",
                        principalColumn: "IdHuyen");
                    table.ForeignKey(
                        name: "FK_Tram_ThongTin_Tram_LoaiTram_IdLoaiTram",
                        column: x => x.IdLoaiTram,
                        principalTable: "Tram_LoaiTram",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tram_ThongTin_Xa_IdXa",
                        column: x => x.IdXa,
                        principalTable: "Xa",
                        principalColumn: "IdXa");
                });

            migrationBuilder.CreateTable(
                name: "DoanSong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDoanSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdLVSong = table.Column<int>(type: "int", nullable: true),
                    IdSong = table.Column<int>(type: "int", nullable: true),
                    ChieuDai = table.Column<double>(type: "float", nullable: true),
                    DienTichLV = table.Column<double>(type: "float", nullable: true),
                    DiaGioiHanhChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDichSuDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XDau = table.Column<double>(type: "float", nullable: true),
                    YDau = table.Column<double>(type: "float", nullable: true),
                    XCuoi = table.Column<double>(type: "float", nullable: true),
                    YCuoi = table.Column<double>(type: "float", nullable: true),
                    Qs = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanSong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoanSong_Song_IdSong",
                        column: x => x.IdSong,
                        principalTable: "Song",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CT_HangMuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCT = table.Column<int>(type: "int", nullable: true),
                    IdTangChuaNuoc = table.Column<int>(type: "int", nullable: true),
                    TenHangMuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VịTriHangMuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    X = table.Column<double>(type: "float", nullable: true),
                    Y = table.Column<double>(type: "float", nullable: true),
                    ChuThich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_HangMuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CT_HangMuc_CT_ThongTin_IdCT",
                        column: x => x.IdCT,
                        principalTable: "CT_ThongTin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CT_HangMuc_TangChuaNuoc_IdTangChuaNuoc",
                        column: x => x.IdTangChuaNuoc,
                        principalTable: "TangChuaNuoc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CT_ViTri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCongTrinh = table.Column<int>(type: "int", nullable: false),
                    IdXa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdHuyen = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_ViTri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CT_ViTri_CT_ThongTin_IdCongTrinh",
                        column: x => x.IdCongTrinh,
                        principalTable: "CT_ThongTin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CT_ViTri_Huyen_IdHuyen",
                        column: x => x.IdHuyen,
                        principalTable: "Huyen",
                        principalColumn: "IdHuyen");
                    table.ForeignKey(
                        name: "FK_CT_ViTri_Xa_IdXa",
                        column: x => x.IdXa,
                        principalTable: "Xa",
                        principalColumn: "IdXa");
                });

            migrationBuilder.CreateTable(
                name: "GP_ThongTin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCon = table.Column<int>(type: "int", nullable: true),
                    IdLoaiGP = table.Column<int>(type: "int", nullable: true),
                    IdTCCN = table.Column<int>(type: "int", nullable: true),
                    IdCT = table.Column<int>(type: "int", nullable: true),
                    TenGP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoGP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayKy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayCoHieuLuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayHetHieuLuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiHan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoQuanCapPhep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileGiayPhep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileGiayToLienQuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileDonXinCP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaBiThuHoi = table.Column<bool>(type: "bit", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GP_ThongTin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GP_ThongTin_CT_ThongTin_IdCT",
                        column: x => x.IdCT,
                        principalTable: "CT_ThongTin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GP_ThongTin_GP_Loai_IdLoaiGP",
                        column: x => x.IdLoaiGP,
                        principalTable: "GP_Loai",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GP_ThongTin_ToChuc_CaNhan_IdTCCN",
                        column: x => x.IdTCCN,
                        principalTable: "ToChuc_CaNhan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LuuLuongTheoMucDich",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCT = table.Column<int>(type: "int", nullable: true),
                    IdMucDich = table.Column<int>(type: "int", nullable: true),
                    LuuLuong = table.Column<double>(type: "float", nullable: true),
                    DonViDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuuLuongTheoMucDich", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LuuLuongTheoMucDich_CT_ThongTin_IdCT",
                        column: x => x.IdCT,
                        principalTable: "CT_ThongTin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LuuLuongTheoMucDich_MucDichKT_IdMucDich",
                        column: x => x.IdMucDich,
                        principalTable: "MucDichKT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ThongTinAoHo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHoChua = table.Column<int>(type: "int", nullable: false),
                    IdCLNQC = table.Column<int>(type: "int", nullable: false),
                    CnnBOD = table.Column<double>(type: "float", nullable: true),
                    CnnCOD = table.Column<double>(type: "float", nullable: true),
                    CnnAmoni = table.Column<double>(type: "float", nullable: true),
                    CnnTongN = table.Column<double>(type: "float", nullable: true),
                    CnnTongP = table.Column<double>(type: "float", nullable: true),
                    CnnTSS = table.Column<double>(type: "float", nullable: true),
                    CnnColiform = table.Column<double>(type: "float", nullable: true),
                    MtnBOD = table.Column<double>(type: "float", nullable: true),
                    MtnCOD = table.Column<double>(type: "float", nullable: true),
                    MtnAmoni = table.Column<double>(type: "float", nullable: true),
                    MtnTongN = table.Column<double>(type: "float", nullable: true),
                    MtnTongP = table.Column<double>(type: "float", nullable: true),
                    MtnTSS = table.Column<double>(type: "float", nullable: true),
                    MtnColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinAoHo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongTinAoHo_CT_ThongTin_IdHoChua",
                        column: x => x.IdHoChua,
                        principalTable: "CT_ThongTin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongTinAoHo_ThongSoCLNAo_IdCLNQC",
                        column: x => x.IdCLNQC,
                        principalTable: "ThongSoCLNAo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuTram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTram = table.Column<int>(type: "int", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LuongMua = table.Column<double>(type: "float", nullable: true),
                    NhietDo = table.Column<double>(type: "float", nullable: true),
                    DoAm = table.Column<double>(type: "float", nullable: true),
                    HuongGio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TocDoGio = table.Column<double>(type: "float", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuTram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuTram_Tram_ThongTin_IdTram",
                        column: x => x.IdTram,
                        principalTable: "Tram_ThongTin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KKTNN_NuocMua_TongLuong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTram = table.Column<int>(type: "int", nullable: true),
                    Nam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thang1 = table.Column<double>(type: "float", nullable: true),
                    Thang2 = table.Column<double>(type: "float", nullable: true),
                    Thang3 = table.Column<double>(type: "float", nullable: true),
                    Thang4 = table.Column<double>(type: "float", nullable: true),
                    Thang5 = table.Column<double>(type: "float", nullable: true),
                    Thang6 = table.Column<double>(type: "float", nullable: true),
                    Thang7 = table.Column<double>(type: "float", nullable: true),
                    Thang8 = table.Column<double>(type: "float", nullable: true),
                    Thang9 = table.Column<double>(type: "float", nullable: true),
                    Thang10 = table.Column<double>(type: "float", nullable: true),
                    Thang11 = table.Column<double>(type: "float", nullable: true),
                    Thang12 = table.Column<double>(type: "float", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KKTNN_NuocMua_TongLuong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KKTNN_NuocMua_TongLuong_Tram_ThongTin_IdTram",
                        column: x => x.IdTram,
                        principalTable: "Tram_ThongTin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ThongSoLtd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDoanSong = table.Column<int>(type: "int", nullable: true),
                    pHTd = table.Column<double>(type: "float", nullable: true),
                    BODTd = table.Column<double>(type: "float", nullable: true),
                    CODTd = table.Column<double>(type: "float", nullable: true),
                    TSSTd = table.Column<double>(type: "float", nullable: true),
                    TongPTd = table.Column<double>(type: "float", nullable: true),
                    TongNTd = table.Column<double>(type: "float", nullable: true),
                    TongColiformTd = table.Column<double>(type: "float", nullable: true),
                    AmoniTd = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoLtd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongSoLtd_DoanSong_IdDoanSong",
                        column: x => x.IdDoanSong,
                        principalTable: "DoanSong",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CT_ThongSo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCT = table.Column<int>(type: "int", nullable: true),
                    IdHangMucCT = table.Column<int>(type: "int", nullable: true),
                    CaoTrinhCong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheDoKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaoTrinhDap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheDoXT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguonNuocXT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChieuCaoDap = table.Column<double>(type: "float", nullable: true),
                    ChieuDaiCong = table.Column<double>(type: "float", nullable: true),
                    ChieuDaiDap = table.Column<double>(type: "float", nullable: true),
                    DuongKinhCong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChieuRongDap = table.Column<double>(type: "float", nullable: true),
                    NguongTran = table.Column<double>(type: "float", nullable: true),
                    ChieuSauDoanThuNuocDen = table.Column<double>(type: "float", nullable: true),
                    ChieuSauDoanThuNuocTu = table.Column<double>(type: "float", nullable: true),
                    CongSuatBom = table.Column<double>(type: "float", nullable: true),
                    CongSuatDamBao = table.Column<double>(type: "float", nullable: true),
                    CongSuatLM = table.Column<double>(type: "float", nullable: true),
                    DienTichLuuVuc = table.Column<double>(type: "float", nullable: true),
                    DienTichTuoiThietKe = table.Column<double>(type: "float", nullable: true),
                    DienTichTuoiThucTe = table.Column<double>(type: "float", nullable: true),
                    DungTichChet = table.Column<double>(type: "float", nullable: true),
                    DungTichHuuIch = table.Column<double>(type: "float", nullable: true),
                    DungTichToanBo = table.Column<double>(type: "float", nullable: true),
                    HBeHut = table.Column<double>(type: "float", nullable: true),
                    HDatOngLocDen = table.Column<double>(type: "float", nullable: true),
                    HDatOngLocTu = table.Column<double>(type: "float", nullable: true),
                    HDoanThuNuocDen = table.Column<double>(type: "float", nullable: true),
                    HDoanThuNuocTu = table.Column<double>(type: "float", nullable: true),
                    HDong = table.Column<double>(type: "float", nullable: true),
                    Hgieng = table.Column<double>(type: "float", nullable: true),
                    HGiengKT = table.Column<double>(type: "float", nullable: true),
                    HHaLuu = table.Column<double>(type: "float", nullable: true),
                    HHaThap = table.Column<double>(type: "float", nullable: true),
                    Hlu = table.Column<double>(type: "float", nullable: true),
                    Hmax = table.Column<double>(type: "float", nullable: true),
                    Hmin = table.Column<double>(type: "float", nullable: true),
                    HThuongLuu = table.Column<double>(type: "float", nullable: true),
                    HTinh = table.Column<double>(type: "float", nullable: true),
                    HtoiThieu = table.Column<double>(type: "float", nullable: true),
                    KichThuocCong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KqKf = table.Column<double>(type: "float", nullable: true),
                    LuongNuocKT = table.Column<double>(type: "float", nullable: true),
                    MNC = table.Column<double>(type: "float", nullable: true),
                    MNDBT = table.Column<double>(type: "float", nullable: true),
                    MNLKT = table.Column<double>(type: "float", nullable: true),
                    MNLTK = table.Column<double>(type: "float", nullable: true),
                    MuaTrungBinhNam = table.Column<double>(type: "float", nullable: true),
                    MucNuocDong = table.Column<double>(type: "float", nullable: true),
                    MucNuocTinh = table.Column<double>(type: "float", nullable: true),
                    PhuongThucXT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QBomLonNhat = table.Column<double>(type: "float", nullable: true),
                    QBomThietKe = table.Column<double>(type: "float", nullable: true),
                    QDamBao = table.Column<double>(type: "float", nullable: true),
                    QKhaiThac = table.Column<double>(type: "float", nullable: true),
                    QKTCapNuocSinhHoat = table.Column<double>(type: "float", nullable: true),
                    QKTLonNhat = table.Column<double>(type: "float", nullable: true),
                    QLonNhatTruocLu = table.Column<double>(type: "float", nullable: true),
                    QMaxKT = table.Column<double>(type: "float", nullable: true),
                    QmaxNM = table.Column<double>(type: "float", nullable: true),
                    QMaxXaThai = table.Column<double>(type: "float", nullable: true),
                    QThietKe = table.Column<double>(type: "float", nullable: true),
                    QThucTe = table.Column<double>(type: "float", nullable: true),
                    QTrungBinhNam = table.Column<double>(type: "float", nullable: true),
                    Qtt = table.Column<double>(type: "float", nullable: true),
                    QXaThai = table.Column<double>(type: "float", nullable: true),
                    QXaThaiLonNhat = table.Column<double>(type: "float", nullable: true),
                    QXaThaiTB = table.Column<double>(type: "float", nullable: true),
                    QXaTran = table.Column<double>(type: "float", nullable: true),
                    SoLuongMayBom = table.Column<int>(type: "int", nullable: true),
                    ThoiGianBomLonNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBomNhoNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBomTB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_ThongSo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CT_ThongSo_CT_HangMuc_IdHangMucCT",
                        column: x => x.IdHangMucCT,
                        principalTable: "CT_HangMuc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CT_ThongSo_CT_ThongTin_IdCT",
                        column: x => x.IdCT,
                        principalTable: "CT_ThongTin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GP_TCQ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGP = table.Column<int>(type: "int", nullable: false),
                    IdTCQ = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GP_TCQ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GP_TCQ_GP_ThongTin_IdGP",
                        column: x => x.IdGP,
                        principalTable: "GP_ThongTin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GP_TCQ_TCQ_ThongTin_IdTCQ",
                        column: x => x.IdTCQ,
                        principalTable: "TCQ_ThongTin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CT_HangMuc_IdCT",
                table: "CT_HangMuc",
                column: "IdCT");

            migrationBuilder.CreateIndex(
                name: "IX_CT_HangMuc_IdTangChuaNuoc",
                table: "CT_HangMuc",
                column: "IdTangChuaNuoc");

            migrationBuilder.CreateIndex(
                name: "IX_CT_ThongSo_IdCT",
                table: "CT_ThongSo",
                column: "IdCT",
                unique: true,
                filter: "[IdCT] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CT_ThongSo_IdHangMucCT",
                table: "CT_ThongSo",
                column: "IdHangMucCT",
                unique: true,
                filter: "[IdHangMucCT] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CT_ThongTin_IdLoaiCT",
                table: "CT_ThongTin",
                column: "IdLoaiCT");

            migrationBuilder.CreateIndex(
                name: "IX_CT_ThongTin_IdLuuVuc",
                table: "CT_ThongTin",
                column: "IdLuuVuc");

            migrationBuilder.CreateIndex(
                name: "IX_CT_ThongTin_IdTangChuaNuoc",
                table: "CT_ThongTin",
                column: "IdTangChuaNuoc");

            migrationBuilder.CreateIndex(
                name: "IX_CT_ViTri_IdCongTrinh",
                table: "CT_ViTri",
                column: "IdCongTrinh");

            migrationBuilder.CreateIndex(
                name: "IX_CT_ViTri_IdHuyen",
                table: "CT_ViTri",
                column: "IdHuyen");

            migrationBuilder.CreateIndex(
                name: "IX_CT_ViTri_IdXa",
                table: "CT_ViTri",
                column: "IdXa");

            migrationBuilder.CreateIndex(
                name: "IX_DoanSong_IdSong",
                table: "DoanSong",
                column: "IdSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocNhan_IdPhanDoanSong",
                table: "DuLieuNguonNuocNhan",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiDiem_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiDiem",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiGiaCam_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiGiaCam",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiLon_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiLon",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiSinhHoat_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiSinhHoat",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrauBo_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrauBo",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongCay_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongCay",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongLua_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongLua",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongRung_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongRung",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuTram_IdTram",
                table: "DuLieuTram",
                column: "IdTram");

            migrationBuilder.CreateIndex(
                name: "IX_GP_TCQ_IdGP",
                table: "GP_TCQ",
                column: "IdGP");

            migrationBuilder.CreateIndex(
                name: "IX_GP_TCQ_IdTCQ",
                table: "GP_TCQ",
                column: "IdTCQ");

            migrationBuilder.CreateIndex(
                name: "IX_GP_ThongTin_IdCT",
                table: "GP_ThongTin",
                column: "IdCT");

            migrationBuilder.CreateIndex(
                name: "IX_GP_ThongTin_IdLoaiGP",
                table: "GP_ThongTin",
                column: "IdLoaiGP");

            migrationBuilder.CreateIndex(
                name: "IX_GP_ThongTin_IdTCCN",
                table: "GP_ThongTin",
                column: "IdTCCN");

            migrationBuilder.CreateIndex(
                name: "IX_KKTNN_NuocDuoiDat_SoLuong_IdTangChuaNuoc",
                table: "KKTNN_NuocDuoiDat_SoLuong",
                column: "IdTangChuaNuoc");

            migrationBuilder.CreateIndex(
                name: "IX_KKTNN_NuocDuoiDat_TongLuong_IdTangChuaNuoc",
                table: "KKTNN_NuocDuoiDat_TongLuong",
                column: "IdTangChuaNuoc");

            migrationBuilder.CreateIndex(
                name: "IX_KKTNN_NuocMat_TongLuong_IdLuuVucSong",
                table: "KKTNN_NuocMat_TongLuong",
                column: "IdLuuVucSong");

            migrationBuilder.CreateIndex(
                name: "IX_KKTNN_NuocMua_TongLuong_IdTram",
                table: "KKTNN_NuocMua_TongLuong",
                column: "IdTram");

            migrationBuilder.CreateIndex(
                name: "IX_LuuLuongTheoMucDich_IdCT",
                table: "LuuLuongTheoMucDich",
                column: "IdCT");

            migrationBuilder.CreateIndex(
                name: "IX_LuuLuongTheoMucDich_IdMucDich",
                table: "LuuLuongTheoMucDich",
                column: "IdMucDich");

            migrationBuilder.CreateIndex(
                name: "IX_Song_IdLuuVuc",
                table: "Song",
                column: "IdLuuVuc");

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoLtd_IdDoanSong",
                table: "ThongSoLtd",
                column: "IdDoanSong",
                unique: true,
                filter: "[IdDoanSong] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinAoHo_IdCLNQC",
                table: "ThongTinAoHo",
                column: "IdCLNQC");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinAoHo_IdHoChua",
                table: "ThongTinAoHo",
                column: "IdHoChua");

            migrationBuilder.CreateIndex(
                name: "IX_Tram_ThongTin_IdHuyen",
                table: "Tram_ThongTin",
                column: "IdHuyen");

            migrationBuilder.CreateIndex(
                name: "IX_Tram_ThongTin_IdLoaiTram",
                table: "Tram_ThongTin",
                column: "IdLoaiTram");

            migrationBuilder.CreateIndex(
                name: "IX_Tram_ThongTin_IdXa",
                table: "Tram_ThongTin",
                column: "IdXa");

            migrationBuilder.CreateIndex(
                name: "IX_Xa_IdHuyen",
                table: "Xa",
                column: "IdHuyen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BieuMauMuoiLam");

            migrationBuilder.DropTable(
                name: "BieuMauSoBa");

            migrationBuilder.DropTable(
                name: "BieuMauSoBay");

            migrationBuilder.DropTable(
                name: "BieuMauSoBon");

            migrationBuilder.DropTable(
                name: "BieuMauSoChin");

            migrationBuilder.DropTable(
                name: "BieuMauSoHai");

            migrationBuilder.DropTable(
                name: "BieuMauSoHaiBa");

            migrationBuilder.DropTable(
                name: "BieuMauSoHaiHai");

            migrationBuilder.DropTable(
                name: "BieuMauSoHaiLam");

            migrationBuilder.DropTable(
                name: "BieuMauSoHaiMot");

            migrationBuilder.DropTable(
                name: "BieuMauSoHaiTu");

            migrationBuilder.DropTable(
                name: "BieuMauSoMot");

            migrationBuilder.DropTable(
                name: "BieuMauSoMuoiBay");

            migrationBuilder.DropTable(
                name: "BieuMauSoMuoiChin");

            migrationBuilder.DropTable(
                name: "BieuMauSoMuoiSau");

            migrationBuilder.DropTable(
                name: "BieuMauSoMuoiTam");

            migrationBuilder.DropTable(
                name: "BieuMauSoNam");

            migrationBuilder.DropTable(
                name: "BieuMauSoSau");

            migrationBuilder.DropTable(
                name: "BieuMauSoTam");

            migrationBuilder.DropTable(
                name: "CLN_NDD");

            migrationBuilder.DropTable(
                name: "CLN_NuocMat");

            migrationBuilder.DropTable(
                name: "CT_ThongSo");

            migrationBuilder.DropTable(
                name: "CT_ViTri");

            migrationBuilder.DropTable(
                name: "CTKTSDN_KTNDDCuaHoGD");

            migrationBuilder.DropTable(
                name: "CTKTSDN_PCGP_NDD");

            migrationBuilder.DropTable(
                name: "CTKTSDN_PCGP_NuocBien");

            migrationBuilder.DropTable(
                name: "CTKTSDN_PCGP_NuocMat");

            migrationBuilder.DropTable(
                name: "CTKTSDN_PDK_NDD");

            migrationBuilder.DropTable(
                name: "CTKTSDN_PDK_NuocBien");

            migrationBuilder.DropTable(
                name: "CTKTSDN_PDK_NuocMat");

            migrationBuilder.DropTable(
                name: "DanhMucNN_LienTinh");

            migrationBuilder.DropTable(
                name: "DanhMucNN_NoiTinh_AoHo");

            migrationBuilder.DropTable(
                name: "DanhMucNN_NoiTinh_SongSuoi");

            migrationBuilder.DropTable(
                name: "Dashboards");

            migrationBuilder.DropTable(
                name: "Demo");

            migrationBuilder.DropTable(
                name: "DonViDo");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocNhan");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiDiem");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiGiaCam");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiLon");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiSinhHoat");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiTrauBo");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiTrongCay");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiTrongLua");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiTrongRung");

            migrationBuilder.DropTable(
                name: "DuLieuTram");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "GP_TCQ");

            migrationBuilder.DropTable(
                name: "GS_DuLieu");

            migrationBuilder.DropTable(
                name: "GS_TaiKhoanTruyen");

            migrationBuilder.DropTable(
                name: "HSKTT_NDD");

            migrationBuilder.DropTable(
                name: "HSKTT_NuocMat");

            migrationBuilder.DropTable(
                name: "KKTNN_NuocDuoiDat_SoLuong");

            migrationBuilder.DropTable(
                name: "KKTNN_NuocDuoiDat_TongLuong");

            migrationBuilder.DropTable(
                name: "KKTNN_NuocMat_ChatLuong");

            migrationBuilder.DropTable(
                name: "KKTNN_NuocMat_SoLuong_AoHoDamPha");

            migrationBuilder.DropTable(
                name: "KKTNN_NuocMat_SoLuong_SongSuoi");

            migrationBuilder.DropTable(
                name: "KKTNN_NuocMat_TongLuong");

            migrationBuilder.DropTable(
                name: "KKTNN_NuocMua_TongLuong");

            migrationBuilder.DropTable(
                name: "LuuLuongTheoMucDich");

            migrationBuilder.DropTable(
                name: "MuaHienTai");

            migrationBuilder.DropTable(
                name: "NN_AoHoDamPhaKhongDuocSanLap");

            migrationBuilder.DropTable(
                name: "NN_CNNN_Ho");

            migrationBuilder.DropTable(
                name: "NN_CNNN_SongSuoi");

            migrationBuilder.DropTable(
                name: "NN_CNNN_TangChuaNuoc");

            migrationBuilder.DropTable(
                name: "NN_DCTT_HaDuHoChua");

            migrationBuilder.DropTable(
                name: "NN_DCTT_SongSuoi");

            migrationBuilder.DropTable(
                name: "NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTao");

            migrationBuilder.DropTable(
                name: "NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3");

            migrationBuilder.DropTable(
                name: "NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3");

            migrationBuilder.DropTable(
                name: "NN_HanhLangBaoVeNN_SongSuoi");

            migrationBuilder.DropTable(
                name: "NN_LuuVucSong");

            migrationBuilder.DropTable(
                name: "NN_MatCatSongSuoi");

            migrationBuilder.DropTable(
                name: "NN_NguongKhaiThacNDD");

            migrationBuilder.DropTable(
                name: "NN_NguonNuoc_AoHoDamPha");

            migrationBuilder.DropTable(
                name: "NN_NguonNuoc_SongSuoi");

            migrationBuilder.DropTable(
                name: "NN_NguonNuoc_TangChuaNuoc");

            migrationBuilder.DropTable(
                name: "NN_VungCamHanCheKTNDD");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "RoleDashboards");

            migrationBuilder.DropTable(
                name: "SLDTKTSDN_NDD");

            migrationBuilder.DropTable(
                name: "SLDTKTSDN_NuocMat");

            migrationBuilder.DropTable(
                name: "SLDTKTSDN_XaThai");

            migrationBuilder.DropTable(
                name: "SLN_TongLuongNuocMat");

            migrationBuilder.DropTable(
                name: "ThongSoCLNSong");

            migrationBuilder.DropTable(
                name: "ThongSoLtd");

            migrationBuilder.DropTable(
                name: "ThongTinAoHo");

            migrationBuilder.DropTable(
                name: "TieuVungLuuVuc");

            migrationBuilder.DropTable(
                name: "UserDashboards");

            migrationBuilder.DropTable(
                name: "VHHC_HoChua_ThongSoKT");

            migrationBuilder.DropTable(
                name: "VHHC_LuuVucSong");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CT_HangMuc");

            migrationBuilder.DropTable(
                name: "PhanDoanSong");

            migrationBuilder.DropTable(
                name: "GP_ThongTin");

            migrationBuilder.DropTable(
                name: "TCQ_ThongTin");

            migrationBuilder.DropTable(
                name: "Tram_ThongTin");

            migrationBuilder.DropTable(
                name: "MucDichKT");

            migrationBuilder.DropTable(
                name: "DoanSong");

            migrationBuilder.DropTable(
                name: "ThongSoCLNAo");

            migrationBuilder.DropTable(
                name: "CT_ThongTin");

            migrationBuilder.DropTable(
                name: "GP_Loai");

            migrationBuilder.DropTable(
                name: "ToChuc_CaNhan");

            migrationBuilder.DropTable(
                name: "Tram_LoaiTram");

            migrationBuilder.DropTable(
                name: "Xa");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "CT_Loai");

            migrationBuilder.DropTable(
                name: "TangChuaNuoc");

            migrationBuilder.DropTable(
                name: "Huyen");

            migrationBuilder.DropTable(
                name: "LuuVucSong");
        }
    }
}
