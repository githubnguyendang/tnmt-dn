namespace tnmt_qn.Dto
{
    public class NN_CNNN_HoDto
    {
        public int? Id { get; set; }
        public string? TenHoChua { get; set; }
        public string? ThuocLVS { get; set; }
        public string? XaPhuongTT { get; set; }
        public string? HuyenTP { get; set; }
        public double? DienTichMatNuoc { get; set; }
        public double? DungTichToanBo { get; set; }
        public double? DungTichHuuIch { get; set; }
        public int? NamHoanThanh { get; set; }
        public string? DonViQuanLyVanHanh { get; set; }
        public string? ChucNangNguonNuoc { get; set; }
        public string? MucTieuChatLuong { get; set; }
    }

    public class NN_CNNN_SongSuoiDto
    {
        public int Id { get; set; }
        public string? MaSong1 { get; set; }
        public string? MaSong2 { get; set; }
        public string? MaSong3 { get; set; }
        public string? MaSong4 { get; set; }
        public string? MaSong5 { get; set; }
        public string? MaSong6 { get; set; }
        public string? TenSongSuoi { get; set; }
        public string? PhanDoan { get; set; }
        public double? ChayRa { get; set; }
        public double? ChieuDai { get; set; }
        public string? DiaPhanHanhChinh { get; set; }
        public string? Huyen { get; set; }
        public double? XDiemDau { get; set; }
        public double? YDiemDau { get; set; }
        public double? XDiemCuoi { get; set; }
        public double? YDiemCuoi { get; set; }
        public string? ChucNangNguonNuoc { get; set; }
        public string? MucTieuChatLuong { get; set; }
        public DateTime? ThoiGianThucHien { get; set; }
    }

    public class NN_CNNN_TangChuaNuocDto
    {
        public int? Id { get; set; }
        public string? ViTriPhamVi { get; set; }
        public string? XaPhuongTT { get; set; }
        public string? HuyenTP { get; set; }
        public string? TenTCN { get; set; }
        public string? LoaiChuaNuoc { get; set; }
        public double? ChieuSauPhanBo { get; set; }
        public double? ChucNangNguonNuoc { get; set; }
        public string? MucTieuChatLuongNuoc { get; set; }
    }
}
