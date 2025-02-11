namespace tnmt_qn.Dto
{
    public class BieuMauMotDto
    {
        public int? Id { get; set; }
        public string? LuuVucSong { get; set; }
        public double? TongTramQuanTracKyTruoc { get; set; }
        public double? TongTramQuanTracBaoCao { get; set; }
        public double? TramKhiTuongKyTruoc { get; set; }
        public double? TramKhiTuongBaoCao { get; set; }
        public double? TramThuyVanKyTruoc { get; set; }
        public double? TramThuyVanKyBaoCao { get; set; }
        public double? TramTNNKyTruoc { get; set; }
        public double? TramTNNKyBaoCao { get; set; }
        public double? TramQuanTracKyTruoc { get; set; }

        public double? TramQuanTracKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauHaiDto
    {
        public int? Id { get; set; }
        public string? TenTram { get; set; }
        public string? ThoiKyQuanTrac { get; set; }
        public double? MuaNamKyTruoc { get; set; }
        public double? MuaNamBaoCao { get; set; }
        public double? MuaNamThayDoi { get; set; }
        public double? MuaMuaKyTruoc { get; set; }
        public double? MuaMuaBaoCao { get; set; }
        public double? MuaMuaThayDoi { get; set; }
        public double? MuaKhoKyTruoc { get; set; }
        public double? MuaKhoBaoCao { get; set; }
        public double? MuaKhoThayDoi { get; set; }
    }

    public class BieuMauBaDto
    {
        public int? Id { get; set; }
        public string? TenTram { get; set; }
        public string? ThoiKyQuanTrac { get; set; }
        public double? LuongMuaThang1 { get; set; }
        public double? LuongMuaThang2 { get; set; }
        public double? LuongMuaThang3 { get; set; }
        public double? LuongMuaThang4 { get; set; }
        public double? LuongMuaThang5 { get; set; }
        public double? LuongMuaThang6 { get; set; }
        public double? LuongMuaThang7 { get; set; }
        public double? LuongMuaThang8 { get; set; }
        public double? LuongMuaThang9 { get; set; }
        public double? LuongMuaThang10 { get; set; }
        public double? LuongMuaThang11 { get; set; }
        public double? LuongMuaThang12 { get; set; }
        public double? LuongMuaNam { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauBonDto
    {
        public int? Id { get; set; }
        public string? LuuVucSong { get; set; }
        public double? DongChayTBNam { get; set; }
        public double? DongChayKyTruoc { get; set; }
        public double? DongChayKyBaoCao { get; set; }
        public double? DongChayMuaLuTB { get; set; }
        public double? DongChayMuaLuKyTruoc { get; set; }
        public double? DongChayMuaLuKyBaoCao { get; set; }
        public double? DongChayMuaCanTB { get; set; }
        public double? DongChayMuaCanKyTruoc { get; set; }
        public double? DongChayMuaCanKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauNamDto
    {
        public int? Id { get; set; }
        public int? Nam { get; set; }
        public string? TenTram { get; set; }
        public double? LuuLuongThang1 { get; set; }
        public double? LuuLuongThang2 { get; set; }
        public double? LuuLuongThang3 { get; set; }
        public double? LuuLuongThang4 { get; set; }
        public double? LuuLuongThang5 { get; set; }
        public double? LuuLuongThang6 { get; set; }
        public double? LuuLuongThang7 { get; set; }
        public double? LuuLuongThang8 { get; set; }
        public double? LuuLuongThang9 { get; set; }
        public double? LuuLuongThang10 { get; set; }
        public double? LuuLuongThang11 { get; set; }
        public double? LuuLuongThang12 { get; set; }
        public double? LuuLuongNam => Math.Round((double)new[] { LuuLuongThang1, LuuLuongThang2, LuuLuongThang3, LuuLuongThang4, LuuLuongThang5, LuuLuongThang6, LuuLuongThang7, LuuLuongThang8, LuuLuongThang9, LuuLuongThang10, LuuLuongThang11, LuuLuongThang12, }.Average()!, 2);
        public string? GhiChu { get; set; }
    }

    public class BieuMauSauDto
    {
        public int? Id { get; set; }
        public string? LuuVucSong { get; set; }
        public double? SLHoChua { get; set; }
        public double? DungTichToanBo { get; set; }
        public double? DungTichHuuich { get; set; }
        public double? DungTichPhongLu { get; set; }
        public double? DungTichTichDuoc { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauBayDto
    {
        public int? Id { get; set; }
        public string? KhuVuc { get; set; }
        public string? VungDieuTra { get; set; }
        public double? DienTichDuocDieuTra { get; set; }
        public string? TangChuaNuocDieuTra { get; set; }
        public string? TyLeDieuTra { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauTamDto
    {
        public int? Id { get; set; }
        public string? TangChuaNuoc { get; set; }
        public string? SLGieng { get; set; }
        public double? MucNuocMaxKyTruoc { get; set; }
        public double? MucNuocMaxKyBaoCao { get; set; }
        public double? MucNuocMediumKyTruoc { get; set; }
        public double? MucNuocMediumKyBaoCao { get; set; }
        public double? MucNuocMinKyTruoc { get; set; }
        public double? MucNuocMinKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauChinDto
    {
        public int? Id { get; set; }
        public string? LuuVucSong { get; set; }
        public double? TongCongTrinhKyTruoc { get; set; }
        public double? TongCongTrinhKyBaoCao { get; set; }
        public double? CongTrinhNuocMatKyTruoc { get; set; }
        public double? CongTrinhNuocMatKyBaoCao { get; set; }
        public double? CongTrinhNDDKyTruoc { get; set; }
        public double? CongTrinhNDDKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauMuoiDto
    {
        public int? Id { get; set; }
        public string? TenLVS { get; set; }
        public double? TongCongTrinh { get; set; }
        public double? CTTuoiNuocMat { get; set; }
        public double? CTTuoiNuocDuoiDat { get; set; }
        public double? CTThuyDien { get; set; }
        public double? CTMucDichKhacNuocMat { get; set; }
        public double? CTMucDichKhacNuocDuoiDat { get; set; }
    }

    public class BieuMauMuoiMotDto
    {
        public int? Id { get; set; }
        public string? LuuVucSong { get; set; }
        public double? TongSoCongTrinh { get; set; }
        public double? CongTrinhHoChua { get; set; }
        public double? CongTrinhDapDang { get; set; }
        public double? CongTrinhCong { get; set; }
        public double? CongTrinhTramBom { get; set; }
        public double? CongTrinhKhacNuocMat { get; set; }
        public double? CongTrinhGieng { get; set; }
        public double? CongTrinhKhacNDD { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauMuoiHaiDto
    {
        public int? Id { get; set; }
        public string? TenLVS { get; set; }
        public double TongCongTrinh { get; set; }
        public double TuoiNguonNuocMat { get; set; }
        public double TuoiNguonNuocDuoiDat { get; set; }
        public double KhaiThacThuyDien { get; set; }
        public double MucDichKhacNguonNuocMat { get; set; }
        public double MucDichKhacNguonNuocDD { get; set; }
    }

    public class BieuMauMuoiBaDto
    {
        public int? Id { get; set; }
        public string? SongSuoiHoChua { get; set; }
        public string? ViTriQuanTrac { get; set; }
        public string? LuuVucSong { get; set; }
        public double? BOD5LonNhat { get; set; }
        public double? BOD5NhoNhat { get; set; }
        public double? BOD5TrungBinh { get; set; }
        public double? CODLonNhat { get; set; }
        public double? CODNhoNhat { get; set; }
        public double? CODTrungBinh { get; set; }
        public double? DOLonNhat { get; set; }
        public double? DONhoNhat { get; set; }
        public double? DOTrungBinh { get; set; }
    }

    public class BieuMauMuoiBonDto
    {
        public int Id { get; set; }
        public int? ThoiGianQuanTrac { get; set; }
        public string? ViTriQuanTrac { get; set; }
        public string? LuuVucSong { get; set; }
        public string? TangChuaNuoc { get; set; }
        public double? PHlonNhat { get; set; }
        public double? PHNhoNhat { get; set; }
        public double? PHTrungBinh{ get; set; }
        public double? ColiformlonNhat { get; set; }
        public double? ColiformNhoNhat { get; set; }
        public double? ColiformTrungBinh { get; set; }
        public double? NitratelonNhat { get; set; }
        public double? NitrateNhoNhat { get; set; }
        public double? NitrateTrungBinh { get; set; }
        public double? AmonilonNhat { get; set; }
        public double? AmoniNhoNhat { get; set; }
        public double? AmoniTrungBinh { get; set; }
        public double? TDSlonNhat { get; set; }
        public double? TDSNhoNhat { get; set; }
        public double? TDSTrungBinh { get; set; }
        public double? DoCungLonNhat { get; set; }
        public double? DoCungNhoNhat { get; set; }
        public double? DoCungTrungBinh { get; set; }
        public double? ArsenicLonNhat { get; set; }
        public double? ArsenicNhoNhat { get; set; }
        public double? ArsenicTrungBinh { get; set; }
        public double? ChlorideLonNhat { get; set; }
        public double? ChlorideNhoNhat { get; set; }
        public double? ChlorideTrungBinh { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauMuoiLamDto
    {
        public int? Id { get; set; }
        public string? CoQuanPhatHanh { get; set; }
        public double? VanBanKyTruoc { get; set; }
        public double? VanBanKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauMuoiSauDto
    {
        public int? Id { get; set; }
        public string? LoaiGiayPhep { get; set; }
        public double? TongGPCapKyTruoc { get; set; }
        public double? TongGPCapKyBaoCao { get; set; }
        public double? TongGPBoCapKyTruoc { get; set; }
        public double? TongGPBoCapKyBaoCao { get; set; }
        public double? TongGPDiaPhuongCapKyTruoc { get; set; }
        public double? TongGPDiaPhuongCapBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauMuoiBayDto
    {
        public int? Id { get; set; }
        public string? Tinh { get; set; }
        public double? TongCTPheDuyetTCQKyTruoc { get; set; }
        public double? TongCTPheDuyetTCQKyBaoCao { get; set; }
        public double? TongCTPheDuyetTCQBoKyTruoc { get; set; }
        public double? TongCTPheDuyetTCQBoKyBaoCao { get; set; }
        public double? TongCTPheDuyetTCQDiaPhuongKyTruoc { get; set; }
        public double? TongCTPheDuyetTCQDiaPhuongKyBaoCao { get; set; }
        public double? TongTCQpKyTruoc { get; set; }
        public double? TongTCQKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauMuoiTamDto
    {
        public int? Id { get; set; }
        public string? LuuVucSong { get; set; }
        public double? TongSongPheDuyetBoKyTruoc { get; set; }
        public double? TongSongPheDuyetBoKyBaoCao { get; set; }
        public double? TongSongPheDuyetDiaPhuongKyTruoc { get; set; }
        public double? TongSongPheDuyetDiaPhuongKyBaoCao { get; set; }
        public double? TongHoPheDuyetKyTruoc { get; set; }
        public double? TongHoPheDuyetKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauMuoiChinDto
    {
        public int? Id { get; set; }
        public string? Tinh { get; set; }
        public double? SoCuocThanhTraKyTruoc { get; set; }
        public double? SoCuocThanhTraKyBaoCao { get; set; }
        public double? SoDoiTuongThanhTraKyTruoc { get; set; }
        public double? SoDoiTuongThanhTraKyBaoCao { get; set; }
        public double? SoTCCNXuPhatKyTruoc { get; set; }
        public double? SoTCCNXuPhatKyBaoCao { get; set; }
        public double? TongTienXuPhatKyTruoc { get; set; }
        public double? TongTienXuPhatKyBaoCao { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauHaiMotDto
    {
        public int? Id { get; set; }
        public string? ThoiGian { get; set; }
        public double? LuuLuongDenHoLonNhat { get; set; }
        public double? LuuLuongDenHoNhoNhat { get; set; }
        public double? TongLuuLuongXaLonNhat { get; set; }
        public double? TongLuuLuongXaNhoNhat { get; set; }
        public double? DongChayToiThieuLonNhat { get; set; }
        public double? DongChayToiThieuNhoNhat { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauHaiHaiDto
    {
        public int? Id { get; set; }
        public string? ThoiGian { get; set; }
        public double? LuuLuongKhaiThacLonNhat { get; set; }
        public double? LuuLuongKhaiThacNhoNhat { get; set; }
        public double? LuuLuongKTDuocCapPhep { get; set; }
        public string? SoNgayKhaiThac { get; set; }
        public double? TongLuongKhaiThac { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauHaiBaDto
    {
        public int? Id { get; set; }
        public string? ThoiGian { get; set; }
        public double? LuuLuongKhaiThacLonNhat { get; set; }
        public double? LuuLuongKhaiThacNhoNhat { get; set; }
        public double? LuuLuongKTDuocCapPhep { get; set; }
        public string? SoNgayKhaiThac { get; set; }
        public double? MucNuocKhaiThacLonNhat { get; set; }
        public double? MucNuocKhaiThacNhoNhat { get; set; }
        public double? ChieuSauMucNuocDongMax { get; set; }
        public double? TongLuongKhaiThac { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauHaiTuDto
    {
        public int? Id { get; set; }
        public string? ThoiGian { get; set; }
        public double? LuuLuongXaThaiLonNhat { get; set; }
        public double? LuuLuongXaThaiNhoNhat { get; set; }
        public double? LuuLuongXaThaiChoPhep { get; set; }
        public double? SoNgayXaThai { get; set; }
        public double? TongLuongXaThai { get; set; }
        public string? GhiChu { get; set; }
    }

    public class BieuMauHaiLamDto
    {
        public int? Id { get; set; }
        public string? ThongSoQuanTrac { get; set; }
        public double? NongDoLonNhat { get; set; }
        public double? NongDoNhoNhat { get; set; }
        public double? NongDoQuyDinh { get; set; }
        public string? GhiChu { get; set; }
    }
}
