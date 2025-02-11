using tnmt_qn.Data;

namespace tnmt_qn.Dto
{
    public class VHHC_HoChua_ThongSoKTDto
    {
        public int Id { get; set; }
        public int? IdHo { get; set; }
        public string? ThuocLVS { get; set; }
        public double? FLv { get; set; }
        public double? XTbNam { get; set; }
        public double? QoTbNam { get; set; }
        public double? P002 { get; set; }
        public double? P01 { get; set; }
        public double? P02 { get; set; }
        public double? P05 { get; set; }
        public double? MNMaxP002 { get; set; }
        public double? MNMaxP01 { get; set; }
        public double? MNMaxP02 { get; set; }
        public double? MNMaxP05 { get; set; }
        public double? WNam { get; set; }
        public double? WNhieuNam { get; set; }
        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }
        public CT_ThongTin? CT_ThongTin { get; set; }
    }
}
