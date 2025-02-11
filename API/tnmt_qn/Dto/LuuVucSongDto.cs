namespace tnmt_qn.Dto
{
    public class LuuVucSongDto
    {
        public int? Id { get; set; }
        public string? TenLVS { get; set; }
        public string? DienTich { get; set; }
        public string? ChieuDaiSongChinh { get; set; }
        public string? BanDo { get; set; }
        public string? SoQuyTrinh { get; set; }
        public string? FileKML { get; set; }
        public string? ChuGiai { get; set; }
        public string? ViTriQT { get; set; }
        public int? NgayBatDau { get; set; }
        public int? NgayKetThuc { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
        public ViTriDto? donvi_hanhchinh { get; set; }
    }
}
