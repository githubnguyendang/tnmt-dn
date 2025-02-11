namespace tnmt_qn.Dto
{
    public class KKTNN_NuocMat_SoLuong_SongSuoiDto
    {
        public int? Id { get; set; }
        public string? MaSong { get; set; }
        public string? TenSong { get; set; }
        public string? ChayRa { get; set; }
        public double? ChieuDai { get; set; }
        public string? ChieuDaiThuocTinh_ThanhPho { get; set; }
        public string? DauSongX { get; set; }
        public string? DauSongY { get; set; }
        public string? DauSongXaHuyenTinh { get; set; }
        public string? CuoiSongX { get; set; }
        public string? CuoiSongY { get; set; }
        public string? CuoiSongXaHuyenTinh { get; set; }
        public string? GhiChu { get; set; }
    }
    public class KKTNN_NuocMat_SoLuong_AoHoDamPhaDto
    {
        public int? Id { get; set; }
        public string? Ten { get; set; }
        public string? NguonNuocKhaiThac { get; set; }
        public string? ThuocHeThongSong { get; set; }
        public double? DienTichMatNuoc { get; set; }
        public double? DungTichToanBo { get; set; }
        public double? DungTichHuuIch { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public string? MucDich { get; set; }

    }
}
