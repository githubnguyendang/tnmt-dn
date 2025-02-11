using tnmt_qn.Data;

namespace tnmt_qn.Dto
{
    public class LuuLuongTheoMucDichDto
    {
        public int? Id { get; set; }
        public int? IdCT { get; set; }
        public int? IdMucDich { get; set; }
        public string? MucDich { get; set; }
        public double? LuuLuong { get; set; }
        public string? DonViDo { get; set; }
        public string? GhiChu { get; set; }
        public bool DaXoa { get; set; } = false;
    }
}
