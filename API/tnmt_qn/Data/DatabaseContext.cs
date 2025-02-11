
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;

namespace tnmt_qn.Data
{
    public class DatabaseContext : IdentityDbContext<AspNetUsers, AspNetRoles, string>
    {
        private readonly IConfiguration configuration;
        public DatabaseContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        //
        #region DbSet

        //For Authoright -- assign permission folow dashboard
        public DbSet<Permissions>? Permissions { get; set; }
        public DbSet<Dashboards>? Dashboards { get; set; }
        public DbSet<UserDashboards>? UserDashboards { get; set; }
        public DbSet<RoleDashboards>? RoleDashboards { get; set; }
        public DbSet<Functions>? Functions { get; set; }

        //Other database
        //test
        public DbSet<Test>? Test { get; set; }
        //ChangeHistory
        public DbSet<ChangeHistory>? ChangeHistory { get; set; }

        public DbSet<CT_HangMuc>? CT_HangMuc { get; set; }
        public DbSet<CT_Loai>? CT_Loai { get; set; }
        public DbSet<CT_ThongTin>? CT_ThongTin { get; set; }
        public DbSet<CT_ThongSo>? CT_ThongSo { get; set; }
        public DbSet<CT_ViTri>? CT_ViTri { get; set; }
        public DbSet<TangChuaNuoc>? TangChuaNuoc { get; set; }
        public DbSet<LuuVucSong>? LuuVucSong { get; set; }
        public DbSet<Song>? Song { get; set; }
        public DbSet<TieuVungLuuVuc>? TieuVungLuuVuc { get; set; }
        public DbSet<Tram_LoaiTram>? Tram_LoaiTram { get; set; }
        public DbSet<Tram_ThongTin>? Tram_ThongTin { get; set; }
        public DbSet<LuuLuongTheoMucDich>? LuuLuongTheoMucDich { get; set; }
        public DbSet<DonViDo>? DonViDo { get; set; }
        public DbSet<MucDichKT>? MucDichKT { get; set; }

        //DonViHanhChinh
        //public DbSet<DonViHC>? DonViHC { get; set; }
        public DbSet<Huyen>? Huyen { get; set; }
        public DbSet<Xa>? Xa { get; set; }

        //GiayPhep
        public DbSet<GP_Loai>? GP_Loai { get; set; }
        public DbSet<GP_TCQ>? GP_TCQ { get; set; }
        public DbSet<GP_ThongTin>? GP_ThongTin { get; set; }
        public DbSet<TCQ_ThongTin>? TCQ_ThongTin { get; set; }
        public DbSet<ToChuc_CaNhan>? ToChuc_CaNhan { get; set; }
        public DbSet<ThanhTraKiemTra>? ThanhTraKiemTra { get; set; }

        //GiamSat
        public DbSet<GS_DuLieu>? GS_DuLieu { get; set; }
        public DbSet<GS_TaiKhoanTruyen>? GS_TaiKhoanTruyen { get; set; }

        //KiemKeTaiNguyenNuoc
        //tong hop chi tieu
        public DbSet<ChiTieuLVSTraKhuc>? ChiTieuLVSTraKhuc { get; set; }

        public DbSet<KKTNN_NuocDuoiDat_SoLuong>? KKTNN_NuocDuoiDat_SoLuong { get; set; }
        public DbSet<KKTNN_NuocDuoiDat_TongLuong>? KKTNN_NuocDuoiDat_TongLuong { get; set; }
        public DbSet<LuuVucSong>? KKTNN_NuocDuoiDat_ChatLuong { get; set; }
        public DbSet<KKTNN_NuocMat_SoLuong_SongSuoi>? KKTNN_NuocMat_SoLuong_SongSuoi { get; set; }
        public DbSet<KKTNN_NuocMat_SoLuong_AoHoDamPha>? KKTNN_NuocMat_SoLuong_AoHoDamPha { get; set; }
        public DbSet<KKTNN_NuocMat_ChatLuong>? KKTNN_NuocMat_ChatLuong { get; set; }
        public DbSet<KKTNN_NuocMat_TongLuong>? KKTNN_NuocMat_TongLuong { get; set; }
        public DbSet<KKTNN_NuocMua_TongLuong>? KKTNN_NuocMua_TongLuong { get; set; }

        //ThongTinDuLieu
        public DbSet<NN_LuuVucSong>? NN_LuuVucSong { get; set; }
        public DbSet<NN_NguonNuoc_SongSuoi>? NN_NguonNuoc_SongSuoi { get; set; }
        public DbSet<NN_NguonNuoc_AoHoDamPha>? NN_NguonNuoc_AoHoDamPha { get; set; }
        public DbSet<NN_NguonNuoc_TangChuaNuoc>? NN_NguonNuoc_TangChuaNuoc { get; set; }
        public DbSet<NN_AoHoDamPhaKhongDuocSanLap>? NN_AoHoDamPhaKhongDuocSanLap { get; set; }
        public DbSet<NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTao>? NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTao { get; set; }
        public DbSet<NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3>? NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3 { get; set; }
        public DbSet<NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3>? NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3 { get; set; }
        public DbSet<NN_HanhLangBaoVeNN_SongSuoi>? NN_HanhLangBaoVeNN_SongSuoi { get; set; }
        public DbSet<NN_CNNN_Ho>? NN_CNNN_Ho { get; set; }
        public DbSet<NN_CNNN_SongSuoi>? NN_CNNN_SongSuoi { get; set; }
        public DbSet<NN_CNNN_TangChuaNuoc>? NN_CNNN_TangChuaNuoc { get; set; }
        public DbSet<NN_DCTT_HaDuHoChua>? NN_DCTT_HaDuHoChua { get; set; }
        public DbSet<NN_DCTT_SongSuoi>? NN_DCTT_SongSuoi { get; set; }
        public DbSet<NN_NguongKhaiThacNDD>? NN_NguongKhaiThacNDD { get; set; }
        public DbSet<NN_VungCamHanCheKTNDD>? NN_VungCamHanCheKTNDD { get; set; }
        public DbSet<NN_MatCatSongSuoi>? NN_MatCatSongSuoi { get; set; }
        public DbSet<CLN_NDD>? CLN_NDD { get; set; }
        public DbSet<CLN_NuocMat>? CLN_NuocMat { get; set; }
        public DbSet<SLN_TongLuongNuocMat>? SLN_TongLuongNuocMat { get; set; }
        public DbSet<SLDTKTSDN_NuocMat>? SLDTKTSDN_NuocMat { get; set; }
        public DbSet<SLDTKTSDN_NDD>? SLDTKTSDN_NDD { get; set; }
        public DbSet<SLDTKTSDN_XaThai>? SLDTKTSDN_XaThai { get; set; }
        public DbSet<HSKTT_NDD>? HSKTT_NDD { get; set; }
        public DbSet<HSKTT_NuocMat>? HSKTT_NuocMat { get; set; }
        public DbSet<DanhMucNN_LienTinh>? DanhMucNN_LienTinh { get; set; }
        public DbSet<DanhMucNN_NoiTinh_AoHo>? DanhMucNN_NoiTinh_AoHo { get; set; }
        public DbSet<DanhMucNN_NoiTinh_SongSuoi>? DanhMucNN_NoiTinh_SongSuoi { get; set; }
        public DbSet<CTKTSDN_PCGP_NDD>? CTKTSDN_PCGP_NDD { get; set; }
        public DbSet<CTKTSDN_PCGP_NuocBien>? CTKTSDN_PCGP_NuocBien { get; set; }
        public DbSet<CTKTSDN_PCGP_NuocMat>? CTKTSDN_PCGP_NuocMat { get; set; }
        public DbSet<CTKTSDN_PDK_NDD>? CTKTSDN_PDK_NDD { get; set; }
        public DbSet<CTKTSDN_PDK_NuocBien>? CTKTSDN_PDK_NuocBien { get; set; }
        public DbSet<CTKTSDN_PDK_NuocMat>? CTKTSDN_PDK_NuocMat { get; set; }
        public DbSet<CTKTSDN_KTNDDCuaHoGD>? CTKTSDN_KTNDDCuaHoGD { get; set; }

        // Thong tin du lieu - so luong chat luong nuoc

        // public DbSet<CLN_NuocMat>? CLN_NuocMat { get; set; }



        //VanHanhHoChua
        public DbSet<VHHC_LuuVucSong>? VHHC_LuuVucSong { get; set; }
        public DbSet<VHHC_HoChua_ThongSoKT>? VHHC_HoChua_ThongSoKT { get; set; }
        public DbSet<MuaHienTai>? MuaHienTai { get; set; }


        //BaoCaoBieuMau
        public DbSet<BieuMauSoMot>? BieuMauSoMot { get; set; }
        public DbSet<BieuMauSoHai>? BieuMauSoHai { get; set; }
        public DbSet<BieuMauSoBa>? BieuMauSoBa { get; set; }
        public DbSet<BieuMauSoBon>? BieuMauSoBon { get; set; }
        public DbSet<BieuMauSoNam>? BieuMauSoNam { get; set; }
        public DbSet<BieuMauSoSau>? BieuMauSoSau { get; set; }
        public DbSet<BieuMauSoBay>? BieuMauSoBay { get; set; }
        public DbSet<BieuMauSoTam>? BieuMauSoTam { get; set; }
        public DbSet<BieuMauSoChin>? BieuMauSoChin { get; set; }
        public DbSet<BieuMauSoMuoiLam>? BieuMauMuoiLam { get; set; }
        public DbSet<BieuMauSoMuoiSau>? BieuMauSoMuoiSau { get; set; }
        public DbSet<BieuMauSoMuoiBay>? BieuMauSoMuoiBay { get; set; }
        public DbSet<BieuMauSoMuoiTam>? BieuMauSoMuoiTam { get; set; }
        public DbSet<BieuMauSoMuoiChin>? BieuMauSoMuoiChin { get; set; }
        public DbSet<BieuMauSoHaiMot>? BieuMauSoHaiMot { get; set; }
        public DbSet<BieuMauSoHaiHai>? BieuMauSoHaiHai { get; set; }
        public DbSet<BieuMauSoHaiBa>? BieuMauSoHaiBa { get; set; }
        public DbSet<BieuMauSoHaiTu>? BieuMauSoHaiTu { get; set; }
        public DbSet<BieuMauSoHaiLam>? BieuMauSoHaiLam { get; set; }

        ////KNTNNThai
        public DbSet<ThongSoCLNSong>? ThongSoCLNSong { get; set; }
        public DbSet<ThongSoCLNAo>? ThongSoCLNAo { get; set; }
        public DbSet<DoanSong>? DoanSong { get; set; }
        public DbSet<ThongSoLtd>? ThongSoLtd { get; set; }
        public DbSet<DuLieuNguonNuocNhan>? DuLieuNguonNuocNhan { get; set; }
        //diem quan trac
        public DbSet<DiemQuanTrac>? DiemQuanTrac { get; set; }
        public DbSet<ThongSoDiemQuanTrac>? ThongSoDiemQuanTrac { get; set; }

        public DbSet<PhanDoanSong>? PhanDoanSong { get; set; }
        public DbSet<ThongTinAoHo>? ThongTinAoHo { get; set; }
        public DbSet<KhaNangTiepNhanNuocHo>? KhaNangTiepNhanNuocHo { get; set; }
        public DbSet<NguonThaiDiem>? NguonThaiDiem { get; set; }


        ///Du lieu nguon thai diem song
        public DbSet<DuLieuNguonNuocThaiDiem>? DuLieuNguonNuocThaiDiem { get; set; }
        public DbSet<DuLieuNguonNuocThaiSinhHoat>? DuLieuNguonNuocThaiSinhHoat { get; set; }
        public DbSet<DuLieuNguonNuocThaiTrauBo>? DuLieuNguonNuocThaiTrauBo { get; set; }
        public DbSet<DuLieuNguonNuocThaiLon>? DuLieuNguonNuocThaiLon { get; set; }
        public DbSet<DuLieuNguonNuocThaiGiaCam>? DuLieuNguonNuocThaiGiaCam { get; set; }
        public DbSet<DuLieuNguonNuocThaiTrongLua>? DuLieuNguonNuocThaiTrongLua { get; set; }
        public DbSet<DuLieuNguonNuocThaiTrongCay>? DuLieuNguonNuocThaiTrongCay { get; set; }
        public DbSet<DuLieuNguonNuocThaiTrongRung>? DuLieuNguonNuocThaiTrongRung { get; set; }
        public DbSet<DuLieuNguonNuocThaiThuySan>? DuLieuNguonNuocThaiThuySan { get; set; }

        ///Du lieu nguon thai diem song du bao
        public DbSet<DuLieuNguonNuocNhanDB>? DuLieuNguonNuocNhanDB { get; set; }
        public DbSet<DuLieuNguonNuocThaiDiemDB>? DuLieuNguonNuocThaiDiemDB { get; set; }
        public DbSet<DuLieuNguonNuocThaiSinhHoatDB>? DuLieuNguonNuocThaiSinhHoatDB { get; set; }
        public DbSet<DuLieuNguonNuocThaiTrauBoDB>? DuLieuNguonNuocThaiTrauBoDB { get; set; }
        public DbSet<DuLieuNguonNuocThaiLonDB>? DuLieuNguonNuocThaiLonDB { get; set; }
        public DbSet<DuLieuNguonNuocThaiGiaCamDB>? DuLieuNguonNuocThaiGiaCamDB { get; set; }
        public DbSet<DuLieuNguonNuocThaiTrongLuaDB>? DuLieuNguonNuocThaiTrongLuaDB { get; set; }
        public DbSet<DuLieuNguonNuocThaiTrongCayDB>? DuLieuNguonNuocThaiTrongCayDB { get; set; }
        public DbSet<DuLieuNguonNuocThaiTrongRungDB>? DuLieuNguonNuocThaiTrongRungDB { get; set; }
        public DbSet<DuLieuNguonNuocThaiThuySanDB>? DuLieuNguonNuocThaiThuySanDB { get; set; }
        public DbSet<TaiLuongNuocThaiSongDB>? TaiLuongNuocThaiSongDB { get; set; }

        //dubaoKNTNT
        public DbSet<ThongSoCLNDuBao>? ThongSoCLNDuBao { get; set; }
        public DbSet<DuBaoKhaNangTiepNhanNuocHo>? DuBaoKhaNangTiepNhanNuocHo { get; set; }
        //MoreDatabase
        public DbSet<Demo>? Demo { get; set; }
        ///TramQuangNgai
        public DbSet<DuLieuTram>? DuLieuTram { get; set; }
        public DbSet<HTTT>? HTTT { get; set; }

        //truyendulieuquantrac
        public DbSet<StoragePreData> StoragePreData { get; set; }
        public DbSet<DataTransmissionAccounts> DataTransmissionAccounts { get; set; }


        //vanhanhhochua
        public DbSet<DuLieuLuuVucLHC> DuLieuLuuVucLHC { get; set; }
        //public DbSet<TramBomSanXuat>? TramBomSanXuat { get; set; }
        //public DbSet<ToaDoCongTrinh>? ToaDoCongTrinh { get; set; }
        //public DbSet<ThongTinCongTrinh>? ThongTinCongTrinh { get; set; }
        //public DbSet<ThongSoVanHanhThucTe>? ThongSoVanHanhThucTe { get; set; }
        //public DbSet<ThongSoKyThuatCongTrinh>? ThongSoKyThuatCongTrinh { get; set; }
        //public DbSet<CheDoKhaiThacCongTrinh>? CheDoKhaiThacCongTrinh { get; set; }
        //public DbSet<ThoiGianVanHanhCongTrinh>? ThoiGianVanHanhCongTrinh { get; set; }
        //public DbSet<PhanCapCongTrinhCong>? PhanCapCongTrinhCong { get; set; }

        ////QLC
        //public DbSet<QLC_CongTrinh>? QLC_CongTrinh { get; set; }
        //public DbSet<QLC_LoaiCT>? QLC_LoaiCT { get; set; }
        //public DbSet<QLC_TangChuaNuoc>? QLC_TangChuaNuoc { get; set; }

        ////TLN
        ////TLN > NDD
        //public DbSet<SoLuongNDD>? SoLuongNDD { get; set; }
        //public DbSet<ThongTinVeCacChiTieuPhanTichCLN>? ThongTinVeCacChiTieuPhanTichCLN { get; set; }
        //public DbSet<ThongTinVeChatLuongNuoc>? ThongTinVeChatLuongNuoc { get; set; }
        //public DbSet<ThongTinVeHoatDongCuaCongTrinh>? ThongTinVeHoatDongCuaCongTrinh { get; set; }
        //public DbSet<ThongTinVeMucNuocTinh>? ThongTinVeMucNuocTinh { get; set; }
        //public DbSet<ThongTinVeTruLuongNuoc>? ThongTinVeTruLuongNuoc { get; set; }
        //public DbSet<TongLuongNuocMan>? TongLuongNuocMan { get; set; }

        ////TLN > NMat
        //public DbSet<KKTNN_NuocMat_SoLuong_AoHoDamPha>? AoHoDamPha { get; set; }
        //public DbSet<CLNMatTheoWQI>? CLNMatTheoWQI { get; set; }
        //public DbSet<DacTrungSongSuoi>? DacTrungSongSuoi { get; set; }
        //public DbSet<Song_Suoi_KenhRach>? Song_Suoi_KenhRach { get; set; }
        //public DbSet<TongLuongDongChay>? TongLuongDongChay { get; set; }

        ////TLN > NMua
        //public DbSet<LoaiTramQuanTracLuongMua>? LoaiTramQuanTracLuongMua { get; set; }
        //public DbSet<PhuongPhapTinhMua>? PhuongPhapTinhMua { get; set; }
        //public DbSet<SoLieuMua>? SoLieuMua { get; set; }
        //public DbSet<TongLuongMua>? TongLuongMua { get; set; }
        //public DbSet<TramQuanTracLuongMua>? TramQuanTracLuongMua { get; set; }
        //public DbSet<TrangThaiQuanTrac>? TrangThaiQuanTrac { get; set; }


        ////DKKetNoi
        ////DKKetNoi > CQNN
        //public DbSet<ChuyenVien>? ChuyenVien { get; set; }
        //public DbSet<TaiKhoanKetNoi>? TaiKhoanKetNoi { get; set; }
        //public DbSet<ThongTinCQNN>? ThongTinCQNN { get; set; }
        //public DbSet<TrangThaiTaiKhoan>? TrangThaiTaiKhoan { get; set; }
        ////DKKetNoi > TCCN
        //public DbSet<DuLieuKetNoi>? DuLieuKetNoi { get; set; }
        //public DbSet<LichSuKetNoi>? LichSuKetNoi { get; set; }
        //public DbSet<ThongTinKetNoi>? ThongTinKetNoi { get; set; }
        //public DbSet<ThongTinTCCN>? ThongTinTCCN { get; set; }


        ////Quan Trac
        ////Quan Trac > MucNuoc
        //public DbSet<PhanLoaiHoChuaTheoMDSD>? PhanLoaiHoChuaTheoMDSD { get; set; }
        //public DbSet<CongTrinhHoChua>? CongTrinhHoChua { get; set; }
        //public DbSet<ThongTinCongTrinhHoChua>? ThongTinCongTrinhHoChua { get; set; }
        //public DbSet<ThongSoThietKeCuaMucNuoc>? ThongSoThietKeCuaMucNuoc { get; set; }
        //public DbSet<GiaTriMucNuocQuanTrac>? GiaTriMucNuocQuanTrac { get; set; }
        //public DbSet<CheDoQuanTracMucNuoc>? CheDoQuanTracMucNuoc { get; set; }
        //public DbSet<CacCapBaoDongMucNuocLu>? CacCapBaoDongMucNuocLu { get; set; }

        ////Quan Trac > LuuLuongXaDCTT
        //public DbSet<CongTrinhQuanTracLuuLuongXaDCTT>? CongTrinhQuanTracLuuLuongXaDCTT { get; set; }
        //public DbSet<ThongTinChatLuongNuoc>? ThongTinChatLuongNuoc { get; set; }
        //public DbSet<CheDoQuanTracLuuLuongDongChayToiThieu>? CheDoQuanTracLuuLuongDongChayToiThieu { get; set; }
        //public DbSet<GiaTriQuanTracLuuLuongXa>? GiaTriQuanTracLuuLuongXa { get; set; }
        //public DbSet<ThongTinLuuLuongXaCuaCt>? ThongTinLuuLuongXaCuaCt { get; set; }

        ////Quan Trac > LuuLuongKTNDD
        //public DbSet<DuLieuQuanTracCuaCTKTNDD>? DuLieuQuanTracCuaCTKTNDD { get; set; }
        //public DbSet<DuLieuQuanTracCuaCTXaThai>? DuLieuQuanTracCuaCTXaThai { get; set; }
        //public DbSet<SoLieuQuanTrac>? SoLieuQuanTrac { get; set; }

        ////Quan Trac > LuuLuongXaQuaNM
        //public DbSet<CheDoGiamSatLuuLuongXaQuaNhaMay>? CheDoGiamSatLuuLuongXaQuaNhaMay { get; set; }
        //public DbSet<CheDoQuanTracLuuLuongXaQuaNhaMay>? CheDoQuanTracLuuLuongXaQuaNhaMay { get; set; }
        //public DbSet<GiaTriLuuLuongXaQuaNhaMay>? GiaTriLuuLuongXaQuaNhaMay { get; set; }
        //public DbSet<HangMucNhaMay>? HangMucNhaMay { get; set; }
        //public DbSet<ThongTinNhaMay>? ThongTinNhaMay { get; set; }

        ////Quan Trac > LuuLuongXaTran
        //public DbSet<GiaTriQuanTracLuuLuongXaTran>? GiaTriQuanTracLuuLuongXaTran { get; set; }
        //public DbSet<HangMucDapTran>? HangMucDapTran { get; set; }
        //public DbSet<PhanLoaiDapTran>? PhanLoaiDapTran { get; set; }
        //public DbSet<ThongSoDapTran>? ThongSoDapTran { get; set; }


        ////ThongTin
        //public DbSet<DMSS_AoHo>? DMSS_AoHo { get; set; }
        //public DbSet<DMSS_DiemCuoiSongSuoi>? DMSS_DiemCuoiSongSuoi { get; set; }
        //public DbSet<DMSS_DiemDauSongSuoi>? DMSS_DiemDauSongSuoi { get; set; }
        //public DbSet<DMSS_SongSuoiNoiTinh>? DMSS_SongSuoiNoiTinh { get; set; }
        //public DbSet<HSKTCT_FilePDFHSKTCongTrinh>? HSKTCT_FilePDFHSKTCongTrinh { get; set; }
        //public DbSet<HSKTCT_LoaiHSKTCongTrinh>? HSKTCT_LoaiHSKTCongTrinh { get; set; }
        //public DbSet<HSKTCT_ThongTinTaiLieuHSKTTram>? HSKTCT_ThongTinTaiLieuHSKTTram { get; set; }
        //public DbSet<HSKTCT_ToChucThucHienQuanTrac>? HSKTCT_ToChucThucHienQuanTrac { get; set; }
        //public DbSet<KQCGHTHGPKTSDN_CongTrinh>? KQCGHTHGPKTSDN_CongTrinh { get; set; }
        //public DbSet<KQCGHTHGPKTSDN_FileGiayPhepKTSDN>? KQCGHTHGPKTSDN_FileGiayPhepKTSDN { get; set; }
        //public DbSet<KQCGHTHGPKTSDN_HoSoGiaHanDieuChinhTheoGiayPhep>? KQCGHTHGPKTSDN_HoSoGiaHanDieuChinhTheoGiayPhep { get; set; }
        //public DbSet<KQCGHTHGPKTSDN_QuanLyNgayCapPhepKTSDN>? KQCGHTHGPKTSDN_QuanLyNgayCapPhepKTSDN { get; set; }
        //public DbSet<KQCGHTHGPKTSDN_ThanhTraKiemTraKetQuaThucHienTheoGiayPhep>? KQCGHTHGPKTSDN_ThanhTraKiemTraKetQuaThucHienTheoGiayPhep { get; set; }
        //public DbSet<KQCGHTHGPKTSDN_ThongTinGiayPhepKTSDN>? KQCGHTHGPKTSDN_ThongTinGiayPhepKTSDN { get; set; }
        //public DbSet<NCKTSDN_KhaNangDapUngNguonNuoc>? NCKTSDN_KhaNangDapUngNguonNuoc { get; set; }
        //public DbSet<NCKTSDN_LoaiTaiNguyenNuoc>? NCKTSDN_LoaiTaiNguyenNuoc { get; set; }
        //public DbSet<NCKTSDN_MucNuocLonNhatCoTheKhaiThac>? NCKTSDN_MucNuocLonNhatCoTheKhaiThac { get; set; }
        //public DbSet<NCKTSDN_NhuCauSuDungNuoc>? NCKTSDN_NhuCauSuDungNuoc { get; set; }
        //public DbSet<NCKTSDN_TongLuongNuoc>? NCKTSDN_TongLuongNuoc { get; set; }
        //public DbSet<SLCLNMNDD_LoaiNuoc>? SLCLNMNDD_LoaiNuoc { get; set; }
        //public DbSet<SLCLNMNDD_LuuVuc>? SLCLNMNDD_LuuVuc { get; set; }
        //public DbSet<SLCLNMNDD_SoLuongNuoc>? SLCLNMNDD_SoLuongNuoc { get; set; }
        //public DbSet<SLCLNMNDD_Song>? SLCLNMNDD_Song { get; set; }
        //public DbSet<SLCLNMNDD_ThongSoSong>? SLCLNMNDD_ThongSoSong { get; set; }
        //public DbSet<SLCLNMNDD_TiemNangNuocDuoiDat>? SLCLNMNDD_TiemNangNuocDuoiDat { get; set; }
        //public DbSet<SLCLNMNDD_ViTriDieuTra>? SLCLNMNDD_ViTriDieuTra { get; set; }
        //public DbSet<SLCLNMNDD_WMuaCan>? SLCLNMNDD_WMuaCan { get; set; }
        //public DbSet<SLCLNMNDD_WMuaLu>? SLCLNMNDD_WMuaLu { get; set; }
        //public DbSet<SLCLNMNDD_WNam>? SLCLNMNDD_WNam { get; set; }
        //public DbSet<SLDTKSDCTV_PhanLoaiDieuTra>? SLDTKSDCTV_PhanLoaiDieuTra { get; set; }
        //public DbSet<SLDTKSDCTV_PhuongPhapDieuTraDiaChatThuyVan>? SLDTKSDCTV_PhuongPhapDieuTraDiaChatThuyVan { get; set; }
        //public DbSet<SLDTKSDCTV_SoLieuDieuTraNDD>? SLDTKSDCTV_SoLieuDieuTraNDD { get; set; }
        //public DbSet<SLDTKSDCTV_ThongTinVungDieuTra>? SLDTKSDCTV_ThongTinVungDieuTra { get; set; }
        //public DbSet<SLDTKSDCTV_TieuVungQuyHoach>? SLDTKSDCTV_TieuVungQuyHoach { get; set; }
        //public DbSet<TT_Huyen>? TT_Huyen { get; set; }
        //public DbSet<TT_ThongTinTieuVung>? TT_ThongTinTieuVung { get; set; }
        //public DbSet<TT_TieuVungTNN>? TT_TieuVungTNN { get; set; }
        //public DbSet<TT_Xa>? TT_Xa { get; set; }


        #endregion
    }
}
