namespace tnmt_qn.Dto
{
    public class KKTNN_NuocDuoiDat_SoLuongDto
    {
        public int? Id { get; set; }
        public int? IdTangChuaNuoc { get; set; }
        public int? SoLuongGieng { get; set; }
        public double? HmaxKyTruoc { get; set; }
        public double? HmaxBaoCao { get; set; }
        public double? HTBKyTruoc { get; set; }
        public double? HTBBaoCao { get; set; }
        public double? HminKyTruoc { get; set; }
        public double? HminBaoCao { get; set; }
        public string? GhiChu { get; set; }
        public TangChuaNuocDto? TangChuaNuoc { get; set; }
    }
}
