namespace tnmt_qn.Dto
{
    public class Tram_LoaiTramDto
    {
        public int? Id { get; set; }
        public int? IdCha { get; set; }
        public string? TenLoaiCT { get; set; }
        public string? MaLoaiCT { get; set; }
        public string? ChuThich { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }
    }
}
