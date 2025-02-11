namespace tnmt_qn.Dto
{
    public class DuLieuTramDto
    {
        public int? Id { get; set; }
        public int? IdTram { get; set; }
        public string? TenTram { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public DateTime? ThoiGian { get; set; }
        public double? LuongMua { get; set; }
        public double? NhietDo { get; set; }
        public string? HuongGio { get; set; }
        public double? DoAm { get; set; }
        public double? TocDoGio { get; set; }
        public bool? DaXoa { get; set; }
    }
    public class ApexChartSeriesTramDto
    {
        public string? name { get; set; }
        public List<double>? data { get; set; }
        public DuLieuTramDto? ThoiGian { get; set; }
    }

}