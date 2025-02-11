namespace tnmt_qn.Dto
{
    public class TCQ_ThongTinDto
    {
        public int? Id { get; set; }
        public int? IdCon { get; set; }
        public string? SoQDTCQ { get; set; }
        public DateTime? NgayKy { get; set; }
        public string? CoQuanCP { get; set; }
        public double? TongTienCQ { get; set; }
        public string? FilePDF { get; set; }
        public string? GhiChu { get; set; }
        public bool? DaXoa { get; set; }

        public TCQ_ThongTinDto? qd_bosung { get; set; }
        public List<GP_TCQDto>? gp_tcq { get; set; }
        public List<GP_ThongTinDto>? giayphep {  get; set; }
        public List<CT_ThongTinDto>? congtrinh { get; set; }

    }
    public class TCQ_FilterDto
    {
        public double StartYear { get; set; }
        public double EndYear { get; set; }
        public string? coquan_cp { get; set; }
    }
}
