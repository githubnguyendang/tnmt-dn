namespace tnmt_qn.Dto
{
    public class Tram_ThongTinDto
    {
        public int? Id { get; set; }
        public int? IdXa { get; set; }
        public int? IdHuyen { get; set; }
        public int? IdLoaiTram { get; set; }
        public string? MaTram { get; set; }
        public string? TenTram { get; set; }
        public string? DiaChiTram { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public string? NgayBatDau { get; set; }
        public string? NgayKetThuc { get; set; }
        public string? HoSoThanhLap { get; set; }
        public string? HoSoHoatDong { get; set; }
        public string? CameraLine { get; set; }
        public bool? OnlineStatus { get; set; }
        public string? ChuThich { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? TaiKhoanTao { get; set; }
        public DateTime? ThoiGianSua { get; set; }
        public string? TaiKhoanSua { get; set; }
        public bool? DaXoa { get; set; }

        public List<KKTNN_NuocMua_TongLuongDto>? tongluong_nuocmua { get; set; }
        public HuyenDto? huyen { get; set; }
        public XaDto? xa { get; set; }
    }
}
