namespace tnmt_qn.Dto
{
    public class CT_HangMucDto
    {
        public int? Id { get; set; }
        public int? IdCT { get; set; }
        public int? IdTangChuaNuoc { get; set; }
        public string? TenHangMuc { get; set; }
        public string? VịTriHangMuc { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public string? ChuThich { get; set; }
        public bool? DaXoa { get; set; } = false;
        public CT_ThongSoDto? thongso { get; set; }
    }
}
