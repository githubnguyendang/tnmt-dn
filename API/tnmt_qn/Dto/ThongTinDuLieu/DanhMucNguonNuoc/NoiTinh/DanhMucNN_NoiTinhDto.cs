namespace tnmt_qn.Dto
{
    public class DanhMucNN_NoiTinh_SongSuoiDto
    {
        public int? Id { get; set; }
        public string? MaSong { get; set; }
        public string? TenSongSuoi { get; set; }
        public string? ChayRa { get; set; }
        public double? XDiemDau { get; set; }
        public double? YDiemDau { get; set; }
        public string? ThonDiemDau { get; set; }
        public string? XaPhuongTTDiemDau { get; set; }
        public string? HuyenTPDiemDau { get; set; }
        public double? XDiemCuoi { get; set; }
        public double? YDiemCuoi { get; set; }
        public string? ThonDiemCuoi { get; set; }
        public string? XaPhuongTTDiemCuoi { get; set; }
        public string? HuyenTPDiemCuoi { get; set; }
        public string? GhiChu { get; set; }
    }
    public class DanhMucNN_NoiTinh_AoHoDto
    {
        public int? Id { get; set; }
        public string? MaHo { get; set; }
        public string? TenHoChua { get; set; }
        public string? XaPhuongTT { get; set; }
        public string? HuyenTP { get; set; }
        public string? NguonNuoc { get; set; }
        public string? ThuocHeThongSong { get; set; }
        public string? GhiChu { get; set; }
    }
}
